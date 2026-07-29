using Dapper;
using Ismocol.Api.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ismocol.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/articles")]
public sealed class ArticlesController(ISqlConnectionFactory connectionFactory) : ControllerBase
{
    [HttpGet("classification-tree")]
    public async Task<IActionResult> ClassificationTree()
    {
        const string sql = """
            SELECT CONCAT('F:', IDFAMILIAMATERIAL) AS Id, CAST(NULL AS nvarchar(30)) AS ParentId,
                'family' AS [Level], LTRIM(RTRIM(CODIGOFAMILIAMATERIAL)) AS Code,
                LTRIM(RTRIM(NOMBREFAMILIAMATERIAL)) AS Name FROM dbo.MA_FAMILIAMATERIAL
            UNION ALL
            SELECT CONCAT('G:', IDGRUPOMATERIAL), CONCAT('F:', IDFAMILIAMATERIAL), 'group',
                LTRIM(RTRIM(CODIGOGRUPOMATERIAL)), LTRIM(RTRIM(NOMBREGRUPOMATERIAL)) FROM dbo.MA_GRUPOMATERIAL
            UNION ALL
            SELECT CONCAT('C:', IDCLASEMATERIAL), CONCAT('G:', IDGRUPOMATERIAL), 'class',
                LTRIM(RTRIM(CODIGOCLASEMATERIAL)), LTRIM(RTRIM(NOMBRECLASEMATERIAL)) FROM dbo.MA_CLASEMATERIAL
            UNION ALL
            SELECT CONCAT('S:', IDSUBCLASEMATERIAL), CONCAT('C:', IDCLASEMATERIAL), 'subclass',
                LTRIM(RTRIM(CODIGOSUBCLASEMATERIAL)), LTRIM(RTRIM(NOMBRESUBCLASEMATERIAL)) FROM dbo.MA_SUBCLASEMATERIAL;
            """;
        await using var connection = connectionFactory.Create();
        var rows = (await connection.QueryAsync<ClassificationRow>(sql)).AsList();
        var byParent = rows.GroupBy(row => row.ParentId ?? string.Empty)
            .ToDictionary(group => group.Key, group => group.OrderBy(row => row.Code).ToArray());

        ArticleTreeNode Map(ClassificationRow row, string parentCode)
        {
            var treeCode = parentCode + row.Code;
            var children = byParent.TryGetValue(row.Id, out var childRows)
                ? childRows.Select(child => Map(child, treeCode)).ToArray()
                : [];
            return new ArticleTreeNode(row.Id, row.Level, row.Code, treeCode, row.Name, children);
        }

        var roots = byParent.TryGetValue(string.Empty, out var rootRows)
            ? rootRows.Select(row => Map(row, string.Empty)).ToArray()
            : [];
        return Ok(roots);
    }

    [HttpGet]
    public async Task<IActionResult> List(
        [FromQuery] string? treeCode, [FromQuery] string? search,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 15)
    {
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 100);
        const string filteredSql = """
            FROM dbo.ARTICULO AR
            INNER JOIN dbo.CATEGORIAMATERIALES CA ON AR.CODIGOCATEGORIA = CA.CODIGOCATEGORIA
            INNER JOIN dbo.MA_FAMILIAMATERIAL FA ON CA.IDFAMILIAMATERIAL = FA.IDFAMILIAMATERIAL
            INNER JOIN dbo.MA_GRUPOMATERIAL GR ON CA.IDGRUPOMATERIAL = GR.IDGRUPOMATERIAL
            INNER JOIN dbo.MA_CLASEMATERIAL CL ON CA.IDCLASEMATERIAL = CL.IDCLASEMATERIAL
            LEFT JOIN dbo.MA_TIPOUNIDAD UN ON AR.CODIGOTIPOUNIDAD = UN.CODIGOTIPOUNIDAD
            WHERE (@TreeCode = '' OR CA.CODIGOARBOL LIKE @TreeCode + '%')
              AND (@Search = '' OR CAST(AR.IDARTICULO AS varchar(20)) LIKE '%' + @Search + '%'
                OR AR.NOMBRE LIKE '%' + @Search + '%' OR AR.NOMBREDESCRIPTIVO LIKE '%' + @Search + '%'
                OR AR.CODIGOBARRAISMOCOL LIKE '%' + @Search + '%' OR AR.CODIGOACCESS LIKE '%' + @Search + '%')
            """;
        var parameters = new
        {
            TreeCode = treeCode?.Trim() ?? string.Empty,
            Search = search?.Trim() ?? string.Empty,
            Offset = (page - 1) * pageSize,
            PageSize = pageSize
        };
        await using var connection = connectionFactory.Create();
        var total = await connection.ExecuteScalarAsync<long>($"SELECT COUNT_BIG(1) {filteredSql}", parameters);
        var items = (await connection.QueryAsync<ArticleSummary>(
            $"""
             SELECT AR.IDARTICULO AS Id, LTRIM(RTRIM(CA.CODIGOARBOL)) AS TreeCode,
                 LTRIM(RTRIM(AR.NOMBRE)) AS Name, LTRIM(RTRIM(AR.NOMBREDESCRIPTIVO)) AS Description,
                 LTRIM(RTRIM(UN.ABREVIATURA)) AS Unit, LTRIM(RTRIM(FA.NOMBREFAMILIAMATERIAL)) AS Family,
                 LTRIM(RTRIM(GR.NOMBREGRUPOMATERIAL)) AS [Group], LTRIM(RTRIM(CL.NOMBRECLASEMATERIAL)) AS Class,
                 LTRIM(RTRIM(AR.CODIGOBARRAISMOCOL)) AS Barcode, LTRIM(RTRIM(AR.CODIGOACCESS)) AS Reference
             {filteredSql}
             ORDER BY AR.NOMBRE OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
             """, parameters)).AsList();
        return Ok(new { items, total, page, pageSize });
    }

    private sealed record ClassificationRow(string Id, string? ParentId, string Level, string Code, string Name);
    public sealed record ArticleTreeNode(string Id, string Level, string Code, string TreeCode, string Name, IReadOnlyList<ArticleTreeNode> Children);
    public sealed record ArticleSummary(int Id, string? TreeCode, string? Name, string? Description, string? Unit, string? Family, string? Group, string? Class, string? Barcode, string? Reference);
}
