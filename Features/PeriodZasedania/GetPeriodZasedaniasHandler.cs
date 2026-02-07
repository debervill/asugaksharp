using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.PeriodZasedania;

public class GetPeriodZasedaniasHandler
{
    private readonly AppDbContext _context;
    public GetPeriodZasedaniasHandler(AppDbContext context) => _context = context;

    public async Task<List<PeriodZasedaniaDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.PeriodZasedania
            .AsNoTracking()
            .Include(p => p.Kafedra)
            .OrderBy(p => p.DateStart)
            .Select(p => new PeriodZasedaniaDto(
                p.Id,
                p.Name,
                p.DateStart,
                p.DateEnd,
                p.Primechanie,
                p.KafedraId,
                p.Kafedra != null ? p.Kafedra.Name : null))
            .ToListAsync(ct);
    }
}
