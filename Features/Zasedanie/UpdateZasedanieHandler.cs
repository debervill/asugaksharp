using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Zasedanie;

public class UpdateZasedanieHandler
{
    private readonly AppDbContext _context;
    public UpdateZasedanieHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(UpdateZasedanieRequest request, CancellationToken ct = default)
    {
        var entity = await _context.Zasedanie.FirstOrDefaultAsync(z => z.Id == request.Id, ct);
        if (entity == null)
            return false;

        entity.NapravleniePodgotovki = request.NapravleniePodgotovki;
        entity.Kvalificacia = request.Kvalificacia;
        entity.Date = request.Date;
        entity.GakID = request.GakId;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
