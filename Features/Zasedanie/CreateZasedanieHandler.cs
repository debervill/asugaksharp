using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Zasedanie;

public class CreateZasedanieHandler
{
    private readonly AppDbContext _context;
    public CreateZasedanieHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreateZasedanieRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.Zasedanie
        {
            Id = Guid.NewGuid(),
            NapravleniePodgotovki = request.NapravleniePodgotovki,
            Kvalificacia = request.Kvalificacia,
            Date = request.Date,
            GakID = request.GakId
        };

        _context.Zasedanie.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
