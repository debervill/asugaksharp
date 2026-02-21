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
├── Core/
│   └── Entities/                    # Доменные сущности (EF Core) — только данные, никакой логики
│       ├── Diplomnik.cs
│       ├── Docs.cs
│       ├── Gak.cs
│       ├── Kafedra.cs
│       ├── NapravleniePodgotovki.cs
│       ├── Normativ.cs
│       ├── Oplata.cs
│       ├── PeriodZasedania.cs
│       ├── Person.cs
│       ├── PersonZasedanie.cs
│       ├── ProfilPodgotovki.cs
│       └── Zasedanie.cs
├── Features/                        # VSA-слайсы — по одной папке на фичу
│   ├── Diplomnik/
│   ├── Docs/
│   ├── Gak/
│   ├── Help/
│   ├── Kafedra/                     # Эталонная реализация — смотри сюда при создании новых фич
│   ├── Komissiya/
│   ├── NapravleniePodgotovki/
│   ├── Oplata/
│   ├── PeriodZasedania/
│   ├── Person/
│   ├── ProfilPodgotovki/
│   ├── TestData/
│   └── Zasedanie/
├── Infrastructure/
│   ├── Persistence/                 # EF Core DbContext
│   │   ├── AppDbContext.cs
│   │   └── AppDbContextFactory.cs
│   └── Common/                      # Общий код — создаётся по мере необходимости
│       ├── Abstractions/            # IFileSystem, IDocumentRenderer, IClock
│       ├── Validators/              # Валидаторы без обращения к БД
│       ├── Mappings/                # IQueryable расширения (ToDto)
│       └── Result.cs               # Result<T>
├── Templates/                       # Шаблоны документов (.docx)
│   └── Dogovor.docx
├── docs/                            # Документация проекта
│   ├── ARCHITECTURE.md
│   ├── DATABASE.md
│   ├── DATABASE_SCHEMA.md
│   ├── DEVELOPMENT.md
│   ├── README.md
│   ├── TEMPLATE_HOWTO.md
│   ├── TEMPLATE_LABELS.md
│   ├── known bugs.md
│   └── todo.md
├── App.xaml                         # Точка входа WPF
├── App.xaml.cs                      # DI-конфигурация
├── MainWindows.xaml                 # Главное окно
├── MainWindows.xaml.cs
├── appsettings.json
├── asugak.db                        # SQLite база данных
├── asugaksharp.csproj
└── CLAUDE.md
```

### VSA Pattern Implementation

Each feature slice contains its own handlers and DTOs. Handlers receive `AppDbContext` directly via constructor injection (no repository layer).

**Query Handler Example:**
```csharp
public class GetKafedrasHandler
{
    private readonly AppDbContext _context;
    public GetKafedrasHandler(AppDbContext context) => _context = context;

    public async Task<Result<List<KafedraDto>>> ExecuteAsync(CancellationToken ct = default)
    {
        var items = await _context.Kafedra
            .AsNoTracking()
            .Select(k => new KafedraDto(k.Id, k.Name, k.ShortName, k.Description))
            .ToListAsync(ct);

        return Result<List<KafedraDto>>.Ok(items);
    }
}
```

**Command Handler Example:**
```csharp
public class CreateKafedraHandler
{
    private readonly AppDbContext _context;
    public CreateKafedraHandler(AppDbContext context) => _context = context;

    public async Task<Result<KafedraDto>> ExecuteAsync(CreateKafedraDto dto, CancellationToken ct = default)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(dto.Name))
            return Result<KafedraDto>.Fail("Название кафедры обязательно");

        if (await _context.Kafedra.AnyAsync(k => k.Name == dto.Name, ct))
            return Result<KafedraDto>.Fail("Кафедра с таким названием уже существует");

        // Mutation
        var entity = new Kafedra { Name = dto.Name, ShortName = dto.ShortName, Description = dto.Description };
        _context.Kafedra.Add(entity);
        await _context.SaveChangesAsync(ct);

        return Result<KafedraDto>.Ok(new KafedraDto(entity.Id, entity.Name, entity.ShortName, entity.Description));
    }
}
```

### Adding New Features

Features are organized by **use-case, not by entity**. Ask "what does this feature do?" not "what entity does it touch?".

1. Create a folder under `Features/[FeatureName]/[Operation]/`
2. Add a single handler class and its DTOs in that folder
3. Add a validator if the operation has format/range/required checks
4. Add or update `Features/[FeatureName]/ServiceCollectionExtensions.cs` to register the handler
5. Ensure the feature's extension method is called from `App.xaml.cs` → `ConfigureServices()`
6. **Before creating any handler** — check if similar logic already exists in another feature

**Examples of correct feature naming:**

```
Features/Kafedra/GetKafedras/       ← CRUD is fine when it's truly just CRUD
Features/Documents/GenerateDogovor/ ← use-case name, not "CreateDocument"
Features/Reports/ExportProtocol/    ← action-oriented
Features/Zasedanie/AssignReviewer/  ← specific operation, not "UpdateZasedanie"
```

### Dependency Registration

Each feature owns its own registration. `App.xaml.cs` only calls feature extension methods — it never registers individual handlers directly.

**Feature extension method** (`Features/Kafedra/ServiceCollectionExtensions.cs`):
```csharp
public static class KafedraServiceCollectionExtensions
{
    public static IServiceCollection AddKafedraFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetKafedrasHandler>();
        services.AddTransient<GetKafedraByIdHandler>();
        services.AddTransient<CreateKafedraHandler>();
        services.AddTransient<UpdateKafedraHandler>();
        services.AddTransient<DeleteKafedraHandler>();
        return services;
    }
}
```

**App.xaml.cs stays clean:**
```csharp
private static IServiceCollection ConfigureServices()
{
    var services = new ServiceCollection();

    // Infrastructure
    services.AddDbContext<AppDbContext>(...);
    services.AddSingleton<IClock, SystemClock>();
    services.AddSingleton<IFileSystem, PhysicalFileSystem>();

    // Features — one line per feature, never per handler
    services.AddKafedraFeatures();
    services.AddDocumentFeatures();
    services.AddZasedanieFeatures();
    services.AddReportFeatures();

    return services;
}
```

Rule: if you find yourself adding `services.AddTransient<SomeHandler>()` directly in `App.xaml.cs`, stop — add it to the feature's extension method instead.

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

---

## VSA Boundaries — What Goes Where

Strict layer separation is the core of VSA. Violating these rules breaks the architecture.

### Layers and their responsibilities

| Layer | Contains | Must NOT contain |
|---|---|---|
| `Core/Entities/` | EF Core entity classes only | Business logic, validation, UI references |
| `Features/[Entity]/` | Handlers, DTOs for one feature | Entities used directly in UI, logic from other features |
| `Infrastructure/Common/` | Shared validators, mappings, extensions | Feature-specific logic |
| `Infrastructure/Persistence/` | AppDbContext, migrations | Business logic |
| WPF (xaml.cs / ViewModel) | UI state, calling handlers, binding DTOs | Business logic, direct EF queries, entity classes |

### The most important rules

**Entities never leave the handler.** ViewModel and code-behind work only with DTOs. Never pass an Entity to the UI layer.

```csharp
// WRONG — entity leaks into UI
public async Task<Kafedra> ExecuteAsync() { ... }

// CORRECT — only DTO crosses the boundary
public async Task<Result<KafedraDto>> ExecuteAsync() { ... }
```

**Features do not call each other.** If two features need shared logic, extract it to `Infrastructure/Common/`, not to one of the features.

```csharp
// WRONG — feature depending on another feature
public class CreateZasedanieHandler
{
    private readonly GetKafedrasHandler _kafedraHandler; // coupling!
}

// CORRECT — compose at the call site (code-behind), or extract shared query to Common
```

---

## WPF Code-Behind and ViewModel Rules

Code-behind (`.xaml.cs`) and ViewModels must stay thin.

### Allowed in code-behind / ViewModel
- Calling a handler via `ExecuteAsync()`
- Binding the returned DTO to UI properties
- Showing error messages from `Result.Error`
- Navigation between windows

### Not allowed in code-behind / ViewModel
- Direct `AppDbContext` usage
- EF queries (`_context.Kafedra.ToList()`)
- Validation logic
- Business rules of any kind

**Example of a correct code-behind call:**
```csharp
private async void SaveButton_Click(object sender, RoutedEventArgs e)
{
    var dto = new CreateKafedraDto(NameBox.Text, ShortNameBox.Text, DescriptionBox.Text);
    var result = await _createHandler.ExecuteAsync(dto);

    if (!result.IsSuccess)
    {
        ErrorText.Text = result.Error;
        return;
    }

    DialogResult = true;
}
```

### Async loading state — prevent double-clicks

Any button that triggers an async handler must disable itself for the duration of the call. Without this a user can submit the same form multiple times before the first request completes.

**Required pattern for every async button:**
```csharp
private async void SaveButton_Click(object sender, RoutedEventArgs e)
{
    // Disable all interactive controls
    SaveButton.IsEnabled = false;
    ErrorText.Text = string.Empty;

    try
    {
        var dto = new CreateKafedraDto(NameBox.Text, ShortNameBox.Text, DescriptionBox.Text);
        var result = await _createHandler.ExecuteAsync(dto);

        if (!result.IsSuccess)
        {
            ErrorText.Text = result.Error;
            return;
        }

        DialogResult = true;
    }
    finally
    {
        // Always re-enable, even if an exception occurs
        SaveButton.IsEnabled = true;
    }
}
```

**If the window has a loading indicator**, show it in the same try/finally block:
```csharp
LoadingOverlay.Visibility = Visibility.Visible;
SaveButton.IsEnabled = false;
try { ... }
finally
{
    LoadingOverlay.Visibility = Visibility.Collapsed;
    SaveButton.IsEnabled = true;
}
```

Rule: **every `async void` event handler must have a `try/finally` that restores button state.** No exceptions.

---

## Error Handling

All handlers return `Result<T>` — never throw exceptions for business logic errors.

### Result<T> contract

Place this class in `Infrastructure/Common/Result.cs`:

```csharp
public class Result<T>
{
    public bool IsSuccess { get; private init; }
    public T? Value { get; private init; }
    public string? Error { get; private init; }

    public static Result<T> Ok(T value) => new() { IsSuccess = true, Value = value };
    public static Result<T> Fail(string error) => new() { IsSuccess = false, Error = error };
}
```

### Rules
- Validation failures → `Result.Fail("message")`, never `throw`
- Not found → `Result.Fail("Запись не найдена")`, never return `null`
- Infrastructure exceptions (DB unavailable, etc.) — let them propagate naturally, catch at the top level in code-behind
- Code-behind always checks `result.IsSuccess` before using `result.Value`

---

## Transactions and SaveChanges

- `SaveChangesAsync()` is called **once per handler**, at the end of all mutations
- Never call `SaveChangesAsync()` in the middle of a handler and again at the end
- If multiple entities must be saved atomically, do all `.Add()` / `.Update()` / `.Remove()` calls first, then one `SaveChangesAsync()`
- Query handlers (`Get*`) never call `SaveChangesAsync()` and always use `.AsNoTracking()`

```csharp
// WRONG — multiple SaveChanges
_context.Zasedanie.Add(zasedanie);
await _context.SaveChangesAsync(ct);
zasedanie.PeriodId = period.Id;
await _context.SaveChangesAsync(ct); // don't do this

// CORRECT — one save at the end
_context.Zasedanie.Add(zasedanie);
zasedanie.PeriodId = period.Id;
await _context.SaveChangesAsync(ct);
```

---

## Dependency Rules

This is the most important rule set. Violations here cause cascading coupling.

### Allowed dependency directions

| Layer | May depend on |
|---|---|
| `Core/Entities/` | Nothing (BCL only) |
| `Features/*/` | `Infrastructure.Persistence` (AppDbContext), `Infrastructure.Common`, BCL |
| `Infrastructure/Common/` | BCL only — no Features, no Persistence |
| `Infrastructure/Persistence/` | `Core/Entities`, BCL |
| WPF UI (xaml.cs / ViewModel) | `Features/*/` handlers, `Infrastructure.Common` (Result, abstractions) |

### Hard rules
- `Core` and `Infrastructure` must never reference anything in `Features/`
- Features must never reference each other
- Shared interfaces (e.g. `IFileSystem`, `IClock`) live in `Infrastructure/Common/Abstractions/`
- Implementations of those interfaces live in `Infrastructure/` (not in Features)
- If you find yourself adding a `using Features.X` inside `Features.Y` — stop and extract to Common

---

## IO, Files, and External Services

Handlers must not perform IO directly. This keeps them testable and prevents them from becoming orchestrators.

### What counts as IO
- File system: `File.*`, `Directory.*`, `Path.*`
- Document generation: Docx/PDF templating libraries
- HTTP / external APIs
- File open/save dialogs (`OpenFileDialog`, `SaveFileDialog`)
- Current time: `DateTime.Now`

### The rule
**Inject an abstraction, never call IO directly from a handler.**

Abstractions live in `Infrastructure/Common/Abstractions/`:

```csharp
public interface IFileSystem
{
    Task WriteAllBytesAsync(string path, byte[] data, CancellationToken ct = default);
    bool Exists(string path);
}

public interface IDocumentRenderer
{
    Task<byte[]> RenderAsync(string templateName, object model, CancellationToken ct = default);
}

public interface IClock
{
    DateTime Now { get; }
}
```

Implementations go in `Infrastructure/Services/` and are registered in `App.xaml.cs`.

**Handler using abstraction:**
```csharp
public class GenerateDogovorHandler
{
    private readonly AppDbContext _context;
    private readonly IDocumentRenderer _renderer;
    private readonly IFileSystem _fileSystem;

    public GenerateDogovorHandler(AppDbContext context, IDocumentRenderer renderer, IFileSystem fileSystem)
    {
        _context = context;
        _renderer = renderer;
        _fileSystem = fileSystem;
    }

    public async Task<Result<string>> ExecuteAsync(GenerateDogovorDto dto, CancellationToken ct = default)
    {
        var data = await _context.Diplomnik.Where(...).FirstOrDefaultAsync(ct);
        if (data is null) return Result<string>.Fail("Дипломник не найден");

        var bytes = await _renderer.RenderAsync("dogovor", data, ct);
        var path = Path.Combine(dto.OutputDir, $"dogovor_{data.Id}.docx");
        await _fileSystem.WriteAllBytesAsync(path, bytes, ct);

        return Result<string>.Ok(path);
    }
}
```

---

## Logging and Observability

### Where logging lives
- Handlers may accept `ILogger<T>` via constructor injection — but only for infrastructure events, not for business logic
- Business failures go through `Result.Fail(...)` — do not log them inside the handler
- Infrastructure exceptions (DB errors, IO errors) — log at the point where they are caught

### Global exception handler
Register in `App.xaml.cs` to catch anything that escapes handlers:

```csharp
DispatcherUnhandledException += (_, e) =>
{
    _logger.LogError(e.Exception, "Unhandled exception");
    MessageBox.Show($"Произошла ошибка: {e.Exception.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
    e.Handled = true;
};
```

### Rules
- Handlers never call `MessageBox.Show()` — that is UI responsibility
- Log infrastructure exceptions before returning or rethrowing
- Do not log `Result.Fail` cases — they are expected control flow, not errors

---

## Validation Policy

Two kinds of validation — keep them separate.

### Format / range / required checks (no DB needed)
- Live in `Infrastructure/Common/Validators/[FeatureName]/`
- Called at the start of the handler before any DB access
- Return `Result.Fail(...)` on first error (or collect all errors if needed)

```csharp
// Infrastructure/Common/Validators/Kafedra/CreateKafedraValidator.cs
public static class CreateKafedraValidator
{
    public static string? Validate(CreateKafedraDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name)) return "Название обязательно";
        if (dto.Name.Length > 200) return "Название не должно превышать 200 символов";
        return null;
    }
}
```

### Invariant checks (require DB)
- Stay inside the handler — they need `AppDbContext`
- Uniqueness, existence, referential integrity checks

```csharp
public async Task<Result<KafedraDto>> ExecuteAsync(CreateKafedraDto dto, CancellationToken ct = default)
{
    // 1. Format checks (no DB)
    var error = CreateKafedraValidator.Validate(dto);
    if (error is not null) return Result<KafedraDto>.Fail(error);

    // 2. Invariant checks (DB)
    if (await _context.Kafedra.AnyAsync(k => k.Name == dto.Name, ct))
        return Result<KafedraDto>.Fail("Кафедра с таким названием уже существует");

    // 3. Mutation
    ...
}
```

### Anti-patterns
- Do not duplicate the same null/empty check in multiple handlers — put it in the validator
- Do not do existence checks in the validator (it has no DB access)

---

## Mapping Rules

### DTOs must be records

```csharp
public record KafedraDto(int Id, string Name, string ShortName, string? Description);
public record CreateKafedraDto(string Name, string ShortName, string? Description);
```

### Query handlers: map inline with `.Select()` or use IQueryable extensions

For simple entities with 3-4 fields, inline projection is fine and more readable:

```csharp
.Select(k => new KafedraDto(k.Id, k.Name, k.ShortName, k.Description))
```

When the same projection is used in **2 or more handlers**, extract it to an `IQueryable` extension in `Infrastructure/Common/Mappings/`:

```csharp
// Infrastructure/Common/Mappings/KafedraQueryExtensions.cs
public static class KafedraQueryExtensions
{
    public static IQueryable<KafedraDto> ToDto(this IQueryable<Kafedra> query) =>
        query.Select(k => new KafedraDto(k.Id, k.Name, k.ShortName, k.Description));
}

// Usage in any handler:
return await _context.Kafedra.AsNoTracking().ToDto().ToListAsync(ct);
```

The rule: **one `.Select()` per entity** — never duplicate the same projection. Extract the moment you need it a second time.

### Command handlers: construct entity inside the handler

```csharp
var entity = new Kafedra { Name = dto.Name, ShortName = dto.ShortName };
```

### Complex mappings
If a mapping requires more than 3-4 fields or conditional logic, extract to `Infrastructure/Common/Mappings/`:

```csharp
// Infrastructure/Common/Mappings/KafedraMapping.cs
public static class KafedraMapping
{
    public static KafedraDetailDto ToDetailDto(this Kafedra k, int diplomnikCount) =>
        new(k.Id, k.Name, k.ShortName, k.Description, diplomnikCount);
}
```

### Hard rule
**Never return an EF entity from a handler — not even "temporarily".** Always map to a DTO before returning.

---

## EF Core Performance Rules

- Always use `.AsNoTracking()` in query handlers
- Always pass `CancellationToken` to every async EF call
- Never call `.ToList()` before `.Where()` or `.Select()` — filter and project first
- Avoid `.Include()` unless navigation property is actually needed in the DTO
- For lists that could be large, add pagination parameters (`int page, int pageSize`) from the start

```csharp
// WRONG
var all = await _context.Diplomnik.ToListAsync(ct);
var filtered = all.Where(d => d.KafedraId == id).ToList();

// CORRECT
var filtered = await _context.Diplomnik
    .AsNoTracking()
    .Where(d => d.KafedraId == id)
    .Select(d => new DiplomnikDto(...))
    .ToListAsync(ct);
```

---

## Testing Policy

### What to test
- **Unit tests** — pure functions: validators, mapping helpers, extension methods
- **Integration tests** — handlers with SQLite in-memory database

### Minimum bar for every new handler
Each new handler must have at minimum:
- 1 happy-path test (operation succeeds, returns correct data)
- 1 fail-path test (validation or not-found returns `Result.Fail`)

### Integration test pattern

```csharp
public class CreateKafedraHandlerTests
{
    private AppDbContext CreateDb()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;
        var db = new AppDbContext(options);
        db.Database.EnsureCreated();
        return db;
    }

    [Fact]
    public async Task Creates_kafedra_successfully()
    {
        using var db = CreateDb();
        var handler = new CreateKafedraHandler(db);
        var dto = new CreateKafedraDto("Кафедра ИТ", "КИТ", null);

        var result = await handler.ExecuteAsync(dto);

        Assert.True(result.IsSuccess);
        Assert.Equal("Кафедра ИТ", result.Value!.Name);
    }

    [Fact]
    public async Task Fails_when_name_is_empty()
    {
        using var db = CreateDb();
        var handler = new CreateKafedraHandler(db);
        var dto = new CreateKafedraDto("", "КИТ", null);

        var result = await handler.ExecuteAsync(dto);

        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Error);
    }
}
```

---

## UI: Code-Behind vs ViewModel

Both approaches are acceptable in this project. Apply these rules regardless of which you use.

### Code-behind limits
- Max 30 lines of logic per event handler method
- No loops over business data
- No conditionals beyond showing/hiding error messages
- All UI state (selected item, loading flag, list data) extracted to a ViewModel if the window has more than 2 interactive elements

### ViewModel rules
- One ViewModel per window or dialog
- ViewModel holds DTOs, not entities
- Commands call handlers and update observable properties
- ViewModel never creates its own `AppDbContext` — handlers are injected

---

These rules exist to prevent large files, high coupling, and duplicate logic — follow them strictly.

### Size Limits
- **Max methods per class:** 10
- **Max lines per handler:** 50
- **Max lines per class:** 150
- **Max cyclomatic complexity per method:** 10 (no deeply nested if/switch chains)

If a handler is growing beyond 50 lines — split the logic into private methods or extract shared logic to `Infrastructure/Common/`.

### Single Responsibility
- One handler = one operation (get list, get by id, create, update, delete)
- Handlers must not contain UI logic or validation beyond basic null checks
- Complex validation → `Infrastructure/Common/Validators/`
- Complex mapping → `Infrastructure/Common/Mappings/`

### No Duplication
- **Never copy-paste logic between handlers.** Extract shared code first.
- Before writing a helper method, search if it already exists in `Infrastructure/Common/`
- Shared query filters (e.g., active records, by department) → extract to static extension methods

### Naming Conventions
Consistent naming prevents duplicate functions with different names.

| Purpose | Pattern | Example |
|---|---|---|
| Query (list) | `Get[Entity]sHandler` | `GetKafedrasHandler` |
| Query (single) | `Get[Entity]ByIdHandler` | `GetKafedraByIdHandler` |
| Create | `Create[Entity]Handler` | `CreateKafedraHandler` |
| Update | `Update[Entity]Handler` | `UpdateKafedraHandler` |
| Delete | `Delete[Entity]Handler` | `DeleteKafedraHandler` |
| Read DTO | `[Entity]Dto` | `KafedraDto` |
| Write DTO | `Create[Entity]Dto` / `Update[Entity]Dto` | `CreateKafedraDto` |

### Coupling Rules
- Handlers must not reference other feature handlers directly
- Cross-feature shared logic goes to `Infrastructure/Common/`, not into another feature's handler
- Avoid making one handler a dependency of another — compose at the call site (ViewModel/code-behind)

---

## Done Criteria

Before considering any task complete, verify:

**Layer boundaries**
- [ ] Handler returns `Result<T>`, not a raw entity or nullable
- [ ] No entity classes used in code-behind or ViewModel — only DTOs
- [ ] No handler calls another handler directly
- [ ] No EF queries in code-behind or ViewModel
- [ ] No `using Features.X` inside `Features.Y`

**IO and abstractions**
- [ ] Handler does not call `File.*`, `Directory.*`, `DateTime.Now`, or dialogs directly
- [ ] External IO goes through an interface from `Infrastructure/Common/Abstractions/`
- [ ] Handler does not call `MessageBox.Show()`

**Size and complexity**
- [ ] Handler is under 50 lines
- [ ] Class has no more than 10 methods
- [ ] No deeply nested conditions (max 2-3 levels)
- [ ] No logic duplicated from existing handlers

**Validation and mapping**
- [ ] Format/required checks are in a validator, not inline
- [ ] DTOs are records
- [ ] Query handlers use `.Select()` or `IQueryable` extension — no AutoMapper
- [ ] Same projection not duplicated across handlers — extracted to `ToDto()` extension if used in 2+ places
- [ ] No entity returned from handler

**Data access**
- [ ] Query handlers use `.AsNoTracking()`
- [ ] `CancellationToken` passed to every async EF call
- [ ] No `.ToList()` before `.Where()` or `.Select()`
- [ ] `SaveChangesAsync()` called exactly once per command handler

**Registration**
- [ ] Handler registered in the feature's `ServiceCollectionExtensions.cs`, not directly in `App.xaml.cs`
- [ ] Feature extension method is called from `App.xaml.cs`

**WPF**
- [ ] Every `async void` event handler has `try/finally` restoring `IsEnabled`
- [ ] No business logic or loops in code-behind methods

**Testing**
- [ ] At least 1 happy-path test exists for the handler
- [ ] At least 1 fail-path test exists for the handler

---

---

## Refactoring Playbook

The project is transitioning from Clean Architecture to VSA (branch: `vsa-refactoring`). The `Kafedra` feature serves as the reference implementation. See `todo.md` for the full task list.

Use this playbook when the static analysis flags issues.

### File has 15+ methods → split by operation type

```
Before: KafedraService.cs (20 methods)
After:
  Features/Kafedra/GetKafedras/GetKafedrasHandler.cs
  Features/Kafedra/GetKafedraById/GetKafedraByIdHandler.cs
  Features/Kafedra/CreateKafedra/CreateKafedraHandler.cs
  Features/Kafedra/UpdateKafedra/UpdateKafedraHandler.cs
  Features/Kafedra/DeleteKafedra/DeleteKafedraHandler.cs
```

Move one operation at a time. Keep the old service compiling until all operations are migrated.

### Duplicate code blocks → extract to Common

1. Identify what the duplicated logic actually does (filter? format? validate?)
2. Decide where it belongs: validator, mapping helper, or query extension
3. Create the shared method in `Infrastructure/Common/`
4. Replace all copies with calls to the shared method
5. Verify no behaviour change

### Highly coupled file (imported by 8+ others) → introduce abstraction

1. Identify what consumers actually need from this file
2. Extract an interface to `Infrastructure/Common/Abstractions/`
3. Keep the implementation where it is (or move to `Infrastructure/Services/`)
4. Consumers depend on the interface, not the concrete class
5. Register the implementation in `App.xaml.cs`

### High complexity method (score > 30) → decompose

1. Find the deepest nested block and extract it to a private method with a descriptive name
2. Replace multi-branch `if/else` chains with early returns
3. If the method is doing multiple distinct things, split into multiple private methods
4. Target: no method deeper than 3 levels of nesting

### General refactoring rules
- Do not introduce new duplication while fixing old duplication
- Refactor one file per commit — makes review and rollback easier
- Run `dotnet build` after every extraction to catch broken references early
- Add a test for the extracted logic before deleting the original
