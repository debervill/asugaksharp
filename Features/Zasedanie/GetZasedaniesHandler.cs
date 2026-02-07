using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Zasedanie;

public class GetZasedaniesHandler
{
    private readonly AppDbContext _context;
    public GetZasedaniesHandler(AppDbContext context) => _context = context;

    public async Task<List<ZasedanieDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.Zasedanie
            .AsNoTracking()
            .Include(z => z.Gak)
            .OrderBy(z => z.Date)
            .Select(z => new ZasedanieDto(
                z.Id,
                z.NapravleniePodgotovki,
                z.Kvalificacia,
                z.Date,
                z.GakID,
                z.Gak != null ? z.Gak.NomerPrikaza : null))
            .ToListAsync(ct);
    }
}
