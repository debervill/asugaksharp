# Руководство разработчика

## Добавление новой фичи

### Шаг 1: Создать Entity (если нужно)

Добавить класс сущности в `Core/Entities/`:

```csharp
// Core/Entities/MyEntity.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Core.Entities;

public class MyEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    // ... другие поля
}
```

### Шаг 2: Добавить DbSet в AppDbContext

```csharp
// Infrastructure/Persistence/AppDbContext.cs
public DbSet<MyEntity> MyEntity { get; set; }
```

### Шаг 3: Создать папку фичи

```
Features/
└── MyEntity/
    ├── MyEntityDtos.cs
    ├── GetMyEntitiesHandler.cs
    ├── CreateMyEntityHandler.cs
    ├── UpdateMyEntityHandler.cs
    └── DeleteMyEntityHandler.cs
```

### Шаг 4: Создать DTOs

```csharp
// Features/MyEntity/MyEntityDtos.cs
namespace asugaksharp.Features.MyEntity;

public record MyEntityDto(Guid Id, string Name);

public record CreateMyEntityRequest(string Name);

public record UpdateMyEntityRequest(Guid Id, string Name);
```

### Шаг 5: Создать Handlers

**GetHandler:**
```csharp
// Features/MyEntity/GetMyEntitiesHandler.cs
using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.MyEntity;

public class GetMyEntitiesHandler
{
    private readonly AppDbContext _context;
    public GetMyEntitiesHandler(AppDbContext context) => _context = context;

    public async Task<List<MyEntityDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.MyEntity
            .AsNoTracking()
            .Select(e => new MyEntityDto(e.Id, e.Name))
            .ToListAsync(ct);
    }
}
```

**CreateHandler:**
```csharp
// Features/MyEntity/CreateMyEntityHandler.cs
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.MyEntity;

public class CreateMyEntityHandler
{
    private readonly AppDbContext _context;
    public CreateMyEntityHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreateMyEntityRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.MyEntity
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        _context.MyEntity.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
```

**UpdateHandler:**
```csharp
// Features/MyEntity/UpdateMyEntityHandler.cs
using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.MyEntity;

public class UpdateMyEntityHandler
{
    private readonly AppDbContext _context;
    public UpdateMyEntityHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(UpdateMyEntityRequest request, CancellationToken ct = default)
    {
        var entity = await _context.MyEntity.FirstOrDefaultAsync(e => e.Id == request.Id, ct);
        if (entity == null)
            return false;

        entity.Name = request.Name;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
```

**DeleteHandler:**
```csharp
// Features/MyEntity/DeleteMyEntityHandler.cs
using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.MyEntity;

public class DeleteMyEntityHandler
{
    private readonly AppDbContext _context;
    public DeleteMyEntityHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.MyEntity.FirstOrDefaultAsync(e => e.Id == id, ct);
        if (entity == null)
            return false;

        _context.MyEntity.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
```

### Шаг 6: Зарегистрировать в DI

```csharp
// App.xaml.cs
using asugaksharp.Features.MyEntity;

// В методе ConfigureServices:
services.AddTransient<GetMyEntitiesHandler>();
services.AddTransient<CreateMyEntityHandler>();
services.AddTransient<UpdateMyEntityHandler>();
services.AddTransient<DeleteMyEntityHandler>();
```

### Шаг 7: Создать миграцию (если добавлена Entity)

```bash
dotnet ef migrations add AddMyEntity
dotnet ef database update
```

## Конвенции именования

### Файлы и классы

| Тип | Паттерн | Пример |
|-----|---------|--------|
| Entity | `{Name}` | `Kafedra.cs` |
| DTO | `{Name}Dto` | `KafedraDto` |
| Create Request | `Create{Name}Request` | `CreateKafedraRequest` |
| Update Request | `Update{Name}Request` | `UpdateKafedraRequest` |
| Get Handler | `Get{Names}Handler` | `GetKafedrasHandler` |
| Create Handler | `Create{Name}Handler` | `CreateKafedraHandler` |
| Update Handler | `Update{Name}Handler` | `UpdateKafedraHandler` |
| Delete Handler | `Delete{Name}Handler` | `DeleteKafedraHandler` |

### Namespaces

```
asugaksharp.Core.Entities
asugaksharp.Features.{FeatureName}
asugaksharp.Infrastructure.Persistence
```

## Работа со связями

### Включение связанных данных в DTO

```csharp
public record PersonDto(
    Guid Id,
    string Name,
    Guid KafedraId,
    string? KafedraName  // Данные из связанной таблицы
);
```

### Запрос с Include

```csharp
public async Task<List<PersonDto>> ExecuteAsync(CancellationToken ct = default)
{
    return await _context.Person
        .AsNoTracking()
        .Include(p => p.Kafedra)  // Загружаем связанную сущность
        .Select(p => new PersonDto(
            p.Id,
            p.Name,
            p.KafedraID,
            p.Kafedra != null ? p.Kafedra.Name : null
        ))
        .ToListAsync(ct);
}
```

## Полезные команды

```bash
# Сборка
dotnet build

# Запуск
dotnet run

# Очистка
dotnet clean

# Добавить пакет
dotnet add package <PackageName>

# Список миграций
dotnet ef migrations list

# Удалить последнюю миграцию
dotnet ef migrations remove

# Сгенерировать SQL скрипт
dotnet ef migrations script
```

## Структура проекта

```
asugaksharp2/
├── Core/
│   └── Entities/           # Доменные модели
├── Features/
│   ├── Kafedra/           # Фича: Кафедры
│   ├── Person/            # Фича: Сотрудники
│   ├── Diplomnik/         # Фича: Дипломники
│   ├── Gak/               # Фича: Комиссии
│   ├── Zasedanie/         # Фича: Заседания
│   ├── PeriodZasedania/   # Фича: Периоды
│   ├── NapravleniePodgotovki/  # Фича: Направления
│   ├── ProfilPodgotovki/  # Фича: Профили
│   ├── Oplata/            # Фича: Оплаты
│   └── Docs/              # Фича: Документы
├── Infrastructure/
│   └── Persistence/
│       └── AppDbContext.cs
├── docs/                   # Документация
├── App.xaml               # XAML конфигурация приложения
├── App.xaml.cs            # DI, точка входа
├── MainWindows.xaml       # Главное окно
├── MainWindows.xaml.cs
├── appsettings.json       # Конфигурация
├── asugaksharp.csproj     # Файл проекта
└── asugaksharp.sln        # Solution файл
```

## Список фич

| Фича | Описание | Handlers |
|------|----------|----------|
| Kafedra | Кафедры | Get, Create, Update, Delete |
| Person | Сотрудники | Get, Create, Update, Delete |
| Diplomnik | Дипломники | Get, Create, Update, Delete |
| Gak | Комиссии ГАК | Get, Create, Update, Delete |
| Zasedanie | Заседания | Get, Create, Update, Delete |
| PeriodZasedania | Периоды защит | Get, Create, Update, Delete |
| NapravleniePodgotovki | Направления | Get, Create, Update, Delete |
| ProfilPodgotovki | Профили | Get, Create, Update, Delete |
| Oplata | Оплаты | Get, Create, Update, Delete |
| Docs | Документы | Get, Create, Update, Delete |
