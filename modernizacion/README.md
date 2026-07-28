# Modernización SIGMA / Ismocol

Migración progresiva del sistema WinForms VB.NET 4.0 a:

- ASP.NET Core Web API sobre .NET 10 LTS.
- Angular 22 y TypeScript.
- SQL Server existente, sin migraciones automáticas de esquema.
- Dapper para conservar consultas y procedimientos almacenados.

## Primera vertical: módulo principal

La primera entrega implementa el acceso mediante el procedimiento heredado
`dbo._ProcCargarDatosUsuarioIngreso`, carga permisos desde `USU_FUNCION` y
`USU_PERMISO`, emite un JWT y presenta el panel principal en Angular.

La función `LegacyCredentialCipher` existe solo para compatibilidad con las
credenciales actuales. No debe emplearse para usuarios nuevos; una fase posterior
debe migrar las contraseñas a un algoritmo de hash moderno.

## Configuración local

No copie contraseñas en `appsettings.json`. Configure la API con secretos de
usuario:

```powershell
cd backend/src/Ismocol.Api
../../../../.tools/dotnet10/dotnet.exe user-secrets init
../../../../.tools/dotnet10/dotnet.exe user-secrets set "ConnectionStrings:LegacySqlServer" "<cadena>"
../../../../.tools/dotnet10/dotnet.exe user-secrets set "Jwt:SigningKey" "<clave-aleatoria-de-64-caracteres>"
```

Ejecute:

```powershell
cd modernizacion
../.tools/dotnet10/dotnet.exe run --project backend/src/Ismocol.Api

$env:Path = (Resolve-Path ../.tools/node24).Path + ';' + $env:Path
cd frontend
npm.cmd start
```

La interfaz queda en `http://localhost:4200`. La URL de la API se configura en
`frontend/src/environments/environment.ts`.
