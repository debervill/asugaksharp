using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.NapravleniePodgotovki;

public class GetNapravleniePodgotovkisHandler
{
    private readonly AppDbContext _context;
    public GetNapravleniePodgotovkisHandler(AppDbContext context) => _context = context;

    public async Task<List<NapravleniePodgotovkiDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.NapravleniePodgotovki
            .AsNoTracking()
            .OrderBy(n => n.ShifrNapr)
            .Select(n => new NapravleniePodgotovkiDto(
                n.Id,
                n.Nazvanie,
                n.ShifrNapr))
            .ToListAsync(ct);
    }
}
