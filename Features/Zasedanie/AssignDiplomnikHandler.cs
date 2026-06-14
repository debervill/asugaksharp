using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Zasedanie;

public class AssignDiplomnikHandler
{
    private readonly AppDbContext _context;
    public AssignDiplomnikHandler(AppDbContext context) => _context = context;

    public async Task AssignAsync(Guid diplomnikId, Guid zasedanieId, CancellationToken ct = default)
    {
        var d = await _context.Diplomnik.FindAsync([diplomnikId], ct);
        if (d is null) return;
        d.ZasedanieId = zasedanieId;
        await _context.SaveChangesAsync(ct);
    }

    public async Task UnassignAsync(Guid diplomnikId, CancellationToken ct = default)
    {
        var d = await _context.Diplomnik.FindAsync([diplomnikId], ct);
        if (d is null) return;
        d.ZasedanieId = null;
        d.ZasedanieOrder = null;
        await _context.SaveChangesAsync(ct);
    }

    public async Task SaveOrderAsync(Guid zasedanieId, IList<Guid> orderedIds, CancellationToken ct = default)
    {
        var diplomniks = await _context.Diplomnik
            .Where(d => d.ZasedanieId == zasedanieId)
            .ToListAsync(ct);

        for (int i = 0; i < orderedIds.Count; i++)
        {
            var d = diplomniks.FirstOrDefault(x => x.Id == orderedIds[i]);
            if (d is not null) d.ZasedanieOrder = i + 1;
        }
        await _context.SaveChangesAsync(ct);
    }
}
