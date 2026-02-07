using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.NapravleniePodgotovki;

public class UpdateNapravleniePodgotovkiHandler
{
    private readonly AppDbContext _context;
    public UpdateNapravleniePodgotovkiHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(UpdateNapravleniePodgotovkiRequest request, CancellationToken ct = default)
    {
        var entity = await _context.NapravleniePodgotovki.FirstOrDefaultAsync(n => n.Id == request.Id, ct);
        if (entity == null)
            return false;

        entity.Nazvanie = request.Nazvanie;
        entity.ShifrNapr = request.ShifrNapr;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
