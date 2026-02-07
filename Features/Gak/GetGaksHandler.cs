using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Gak;

public class GetGaksHandler
{
    private readonly AppDbContext _context;
    public GetGaksHandler(AppDbContext context) => _context = context;

    public async Task<List<GakDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.Gak
            .AsNoTracking()
            .Include(g => g.PeriodZasedania)
            .Include(g => g.Kafedra)
            .OrderBy(g => g.NomerPrikaza)
            .Select(g => new GakDto(
                g.Id,
                g.NomerPrikaza,
                g.KolvoBudget,
                g.KolvoPlatka,
                g.PeriodZasedaniaId,
                g.PeriodZasedania != null ? g.PeriodZasedania.Name : null,
                g.KafedraID,
                g.Kafedra != null ? g.Kafedra.Name : null))
            .ToListAsync(ct);
    }
}
