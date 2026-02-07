# Архитектура проекта

## Vertical Slice Architecture (VSA)

Проект построен на архитектуре вертикальных срезов. В отличие от классической слоистой архитектуры, код организован по **фичам**, а не по техническим слоям.

### Сравнение подходов

**Слоистая архитектура (Clean Architecture):**
```
Application/
    Services/
        KafedraService.cs
        PersonService.cs
    Interfaces/
        IKafedraService.cs
        IPersonService.cs
Infrastructure/
    Repositories/
        KafedraRepository.cs
        PersonRepository.cs
```

**Вертикальные срезы (VSA):**
```
Features/
    Kafedra/
        KafedraDtos.cs
        GetKafedrasHandler.cs
        CreateKafedraHandler.cs
        UpdateKafedraHandler.cs
        DeleteKafedraHandler.cs
    Person/
        PersonDtos.cs
        GetPersonsHandler.cs
        ...
```

### Преимущества VSA

1. **Изоляция изменений** - изменения в одной фиче не затрагивают другие
2. **Простота навигации** - весь код фичи в одной папке
3. **Отсутствие лишних абстракций** - нет репозиториев и сервисов
4. **Быстрое добавление фич** - копируешь папку, переименовываешь
5. **Независимое тестирование** - каждый handler тестируется отдельно

## Структура слоёв

```
┌─────────────────────────────────────────────────────────┐
│                    Presentation                          │
│              (MainWindows.xaml, WPF Forms)              │
├─────────────────────────────────────────────────────────┤
│                      Features                            │
│    ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐     │
│    │ Kafedra │ │ Person  │ │   Gak   │ │  ...    │     │
│    │  DTOs   │ │  DTOs   │ │  DTOs   │ │         │     │
│    │ Handlers│ │ Handlers│ │ Handlers│ │         │     │
│    └─────────┘ └─────────┘ └─────────┘ └─────────┘     │
├─────────────────────────────────────────────────────────┤
│                   Infrastructure                         │
│                    AppDbContext                          │
├─────────────────────────────────────────────────────────┤
│                       Core                               │
│                     Entities                             │
└─────────────────────────────────────────────────────────┘
```

## Структура фичи

Каждая фича содержит:

```
Features/{Entity}/
├── {Entity}Dtos.cs              # DTO и Request модели
├── Get{Entities}Handler.cs      # Query: получение списка
├── Create{Entity}Handler.cs     # Command: создание
├── Update{Entity}Handler.cs     # Command: обновление
└── Delete{Entity}Handler.cs     # Command: удаление
```

### DTOs

```csharp
namespace asugaksharp.Features.Kafedra;

// Для чтения (отображение в UI)
public record KafedraDto(Guid Id, string Name, string ShortName, string? Description);

// Для создания
public record CreateKafedraRequest(string Name, string ShortName, string? Description);

// Для обновления
public record UpdateKafedraRequest(Guid Id, string Name, string ShortName, string? Description);
```

### Handler (Query)

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

### Handler (Command)

```csharp
public class CreateKafedraHandler
{
    private readonly AppDbContext _context;

    public CreateKafedraHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreateKafedraRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.Kafedra
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ShortName = request.ShortName,
            Description = request.Description
        };

        _context.Kafedra.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
```

## Dependency Injection

Все handlers регистрируются в `App.xaml.cs`:

```csharp
private void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=asugak.db"));

    // Kafedra
    services.AddTransient<GetKafedrasHandler>();
    services.AddTransient<CreateKafedraHandler>();
    services.AddTransient<UpdateKafedraHandler>();
    services.AddTransient<DeleteKafedraHandler>();

    // ... остальные фичи
}
```

## Использование в UI

```csharp
// Получение handler через DI
var handler = App.ServiceProvider.GetRequiredService<GetKafedrasHandler>();

// Выполнение операции
var kafedras = await handler.ExecuteAsync();

// Создание
var createHandler = App.ServiceProvider.GetRequiredService<CreateKafedraHandler>();
var newId = await createHandler.ExecuteAsync(new CreateKafedraRequest("ИВТ", "ИВТ", "Кафедра информатики"));
```

## Принципы

1. **Один handler = одна операция** (Single Responsibility)
2. **Прямой доступ к DbContext** (нет репозиториев)
3. **DTO отделены от Entity** (изоляция слоёв)
4. **AsNoTracking для Query** (оптимизация чтения)
5. **CancellationToken везде** (отмена операций)
