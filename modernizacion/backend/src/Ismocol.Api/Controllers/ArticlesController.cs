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
            FROM dbo.ListarArticulos(0)
            WHERE (@TreeCode = '' OR CODIGOARBOL LIKE @TreeCode + '%')
              AND (@Search = '' OR CAST(ID AS varchar(20)) LIKE '%' + @Search + '%'
                OR NOMBRE LIKE '%' + @Search + '%' OR DESCRIPCION LIKE '%' + @Search + '%'
                OR CODIGOBARRAS LIKE '%' + @Search + '%' OR REFERENCIA LIKE '%' + @Search + '%')
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
             SELECT ID AS Id, LTRIM(RTRIM(CODIGOARBOL)) AS TreeCode,
                 LTRIM(RTRIM(NOMBRE)) AS Name, LTRIM(RTRIM(DESCRIPCION)) AS Description,
                 LTRIM(RTRIM(UND)) AS Unit, LTRIM(RTRIM(FAMILIA)) AS Family,
                 LTRIM(RTRIM(GRUPO)) AS [Group], LTRIM(RTRIM(CLASE)) AS Class,
                 LTRIM(RTRIM(CODIGOBARRAS)) AS Barcode, LTRIM(RTRIM(REFERENCIA)) AS Reference
             {filteredSql}
             ORDER BY NOMBRE OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
             """, parameters)).AsList();
        return Ok(new { items, total, page, pageSize });
    }

    private sealed record ClassificationRow(string Id, string? ParentId, string Level, string Code, string Name);
    public sealed record ArticleTreeNode(string Id, string Level, string Code, string TreeCode, string Name, IReadOnlyList<ArticleTreeNode> Children);
    public sealed record ArticleSummary(int Id, string? TreeCode, string? Name, string? Description, string? Unit, string? Family, string? Group, string? Class, string? Barcode, string? Reference);
}
