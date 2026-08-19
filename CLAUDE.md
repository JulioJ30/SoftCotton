# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

SoftCotton is a Windows Forms desktop application (.NET Framework 4.8, C#) for a textile/logistics
business — it manages purchase orders, service orders, invoices, dispatch control ("guías de remisión"),
warehouse/kardex movements, employees, and security/login. All persistence is via SQL Server stored
procedures; there is no ORM-driven schema (Dapper and raw `SqlCommand` are used only to call procs).

There is a single project (`SoftCotton\SoftCotton.csproj`) in `SoftCotton.sln`. There is no test project.

## Build

This is an old-style (non-SDK) .NET Framework WinForms project using `packages.config` (not PackageReference).
Build with MSBuild, not `dotnet build`:

```
msbuild SoftCotton.sln /p:Configuration=Debug
msbuild SoftCotton.sln /p:Configuration=Release
```

Or open `SoftCotton.sln` in Visual Studio and build/run from there (F5). There are no lint or test commands —
no test project exists in the solution.

NuGet packages are restored the classic (packages.config) way — via Visual Studio's "Restore NuGet Packages"
or `nuget restore SoftCotton.sln` — not `dotnet restore`.

## Architecture

The app follows a strict layered pattern, repeated per business module (PurchaseOrder, ServiceOrder,
Invoices, DispatchControl, ReferralGuide, Kardex, Employee, Maintenance, Security, Movimientos,
Transformacion, Enterprise):

```
Views/<Module>/*View.cs (WinForms)  →  BusinessLogic/<Module>BL.cs  →  Repository/<Module>Repository.cs  →  SQL Server stored proc
                                                                              ↑ uses Model/<Module>/*.cs DTOs
```

- **Views** (`SoftCotton/Views/<Module>/`): WinForms forms (`*View.cs` + `.Designer.cs` + `.resx`). Views
  instantiate their module's `BL` class directly and call into it — there is no DI container.
- **BusinessLogic** (`SoftCotton/BusinessLogic/<Module>BL.cs`): thin pass-through layer between Views and
  Repository. Rarely contains real logic beyond delegating and occasional validation.
- **Repository** (`SoftCotton/Repository/<Module>Repository.cs`): all data access. Opens a connection via
  `SoftCotton.Database.ConnectionBD.GetConnection()`, then either:
  - builds a raw `SqlCommand` with `CommandType.StoredProcedure`, or
  - uses Dapper (`sqlConnection.Query<T>(...)`, `QuerySingleOrDefault<T>(...)`) with `DynamicParameters`.
  Both styles coexist in the same repository file — match whichever style the surrounding methods in that
  file already use.
- **Model** (`SoftCotton/Model/<Module>/`): plain DTOs mapping to stored-proc result sets/params. Naming
  convention follows the proc's option pattern, e.g. `GetGR1_Motivo`, `GetGR2_CabeceraXCod`,
  `SetGRCabParam` — the number matches the `@opcion` value sent to the proc.
- **Stored procedures**: most modules are served by a small number of "god procs" dispatched via an
  `@opcion` (option number) integer parameter plus generic `@filtroTxt1..N` / `@filtroInt1..N` parameters
  (e.g. `uspGetGuiaRemision`, `uspGetOrdenCompra`). When adding a new query/action for an existing module,
  check whether it fits as a new `@opcion` branch on the existing proc before assuming a new proc is needed
  — that's the established pattern (proc definitions live in the database, not in this repo).
- **Reports** (`SoftCotton/Reports/<Module>/`): RDLC report definitions (`.rdlc`) paired with a WinForms
  `Rpt_*.cs` code-behind class that hosts a `ReportViewer` control and binds it to data from the
  corresponding `BL`/`Repository`.

### Cross-cutting utilities

- `SoftCotton/Database/ConnectionBD.cs`: single source of the SQL connection. Picks a connection string
  based on the `ambiente` (environment) key in `app.config`'s `<appSettings>`: `"D"` (dev, local SQL
  Server via `cnxsql`), `"P"` (prod-like, also `cnxsql` but with a password appended), or `"NUBEP"` (cloud
  prod, `cnxsqlproduccion`). Switch environments by editing `ambiente` in `SoftCotton/app.config`, not by
  changing code.
- `SoftCotton/Util/Response.cs` and `ResponseGeneral.cs`: standard return wrappers for repository/BL
  write operations (`idResponse`/`messageResponse`/`typeMessage`, or `state`/`message`/`result`).
- `SoftCotton/Util/UserApplication.cs`: static holder for the currently logged-in user
  (`ID_USUARIO`, `USUARIO`, `COLABORADOR`), set at login and read throughout the app.
- `SoftCotton/VariableGeneral.cs`: static globals used to pass ad-hoc state between forms (e.g. selected
  code/description when a picker form returns to its caller). Legacy pattern predating cleaner form
  communication — follow it for consistency in existing flows rather than introducing a new mechanism.
- `SoftCotton/Util/Constantes.cs` / `ListaConstantes.cs`: shared constant values and option lists.
- Excel export goes through `SoftCotton/Util/ExcelReport.cs` / `ExcelReportTitulo.cs` (ClosedXML /
  DocumentFormat.OpenXml), PDF via iTextSharp.

### Naming conventions

- Business domain code (classes, methods, DB-facing DTOs) is largely in Spanish (e.g. `GuiaRemision`,
  `OrdenCompra`, `Empleado`, `Seguridad`) — match the existing language per module rather than mixing in
  English names.
- Views end in `View` (e.g. `RegistroGuiaRemisionView`, `LoginView`); report code-behind classes are
  prefixed `Rpt_`.
