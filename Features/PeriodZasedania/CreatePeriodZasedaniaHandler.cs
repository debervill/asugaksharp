using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.PeriodZasedania;

public class CreatePeriodZasedaniaHandler
{
    private readonly AppDbContext _context;
    public CreatePeriodZasedaniaHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreatePeriodZasedaniaRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.PeriodZasedania
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            DateStart = request.DateStart,
            DateEnd = request.DateEnd,
            Primechanie = request.Primechanie,
            KafedraId = request.KafedraId
        };

        _context.PeriodZasedania.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
