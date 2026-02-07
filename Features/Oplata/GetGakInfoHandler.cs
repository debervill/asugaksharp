using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Oplata;

public class GetGakInfoHandler
{
    private readonly AppDbContext _context;
    public GetGakInfoHandler(AppDbContext context) => _context = context;

    public async Task<GakInfoDto?> ExecuteAsync(Guid gakId, CancellationToken ct = default)
    {
        return await _context.Gak
            .AsNoTracking()
            .Where(g => g.Id == gakId)
            .Select(g => new GakInfoDto(
                g.Id,
                g.NomerPrikaza,
                g.KolvoBudget,
                g.KolvoPlatka))
            .FirstOrDefaultAsync(ct);
    }
}
