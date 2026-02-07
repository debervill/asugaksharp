using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;
using asugaksharp.Features.Gak;

namespace asugaksharp.Features.Komissiya;

public class GetGaksByKafedraHandler
{
    private readonly AppDbContext _context;
    public GetGaksByKafedraHandler(AppDbContext context) => _context = context;

    public async Task<List<GakDto>> ExecuteAsync(Guid kafedraId, CancellationToken ct = default)
    {
        return await _context.Gak
            .AsNoTracking()
            .Where(g => g.KafedraID == kafedraId)
            .Include(g => g.PeriodZasedania)
            .Include(g => g.Kafedra)
            .OrderByDescending(g => g.DataPrikaza)
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
