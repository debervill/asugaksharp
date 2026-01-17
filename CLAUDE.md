# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build and Run Commands

```bash
# Build the project
dotnet build

# Run the application
dotnet run

# Add a new EF Core migration
dotnet ef migrations add <MigrationName>

# Apply migrations to database
dotnet ef database update
```

## Architecture Overview

This is a WPF desktop application for managing academic thesis defense processes (ГАК - State Examination Commission). The project uses **Vertical Slice Architecture (VSA)** with feature-based organization.

**Tech Stack:** .NET 8, WPF, Entity Framework Core 9, SQLite

### Project Structure

```
asugaksharp2/
├── Core/Entities/          # Domain entities (Kafedra, Person, Diplomnik, etc.)
├── Features/               # VSA feature slices (handlers + DTOs per feature)
│   └── Kafedra/           # Example: GetKafedrasHandler, CreateKafedraHandler, KafedraDtos
├── Infrastructure/
│   └── Persistence/       # AppDbContext (EF Core)
├── MainWindows.xaml       # WPF main window
└── App.xaml.cs            # Application entry point with DI setup
```

### VSA Pattern Implementation

Each feature slice contains its own handlers and DTOs. Handlers receive `AppDbContext` directly via constructor injection (no repository layer).

**Query Handler Example:**
```csharp
public class GetKafedrasHandler
{
    private readonly AppDbContext _context;
    public GetKafedrasHandler(AppDbContext context) => _context = context;

    public async Task<List<KafedraDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.Kafedra
            .AsNoTracking()
            .Select(k => new KafedraDto(k.Id, k.Name, k.ShortName, k.Description))
            .ToListAsync(ct);
    }
}
```

### Adding New Features

1. Create a folder under `Features/` named after the entity
2. Add handler classes (e.g., `GetXxxHandler`, `CreateXxxHandler`)
3. Add DTO records in the same folder
4. Register handlers in `App.xaml.cs` → `ConfigureServices()`

### Domain Entities

Key entities in `Core/Entities/`:
- **Kafedra** - Department
- **Person** - Staff/reviewer with role flags (IsChairman, IsSecretary, IsReviewer, IsExternal)
- **Diplomnik** - Graduate student with thesis info
- **Gak** - Academic council
- **Zasedanie** - Defense session
- **PeriodZasedania** - Session period linked to department

### Database

SQLite database at `asugak.db` in project root. Connection configured in `App.xaml.cs`.

## Refactoring Notes

The project is transitioning from Clean Architecture to VSA (branch: `vsa-refactoring`). The Kafedra feature serves as the reference implementation. See `todo.md` for detailed refactoring guidance.
