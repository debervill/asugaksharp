using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Gak;

public class UpdateGakHandler
{
    private readonly AppDbContext _context;
    public UpdateGakHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(UpdateGakRequest request, CancellationToken ct = default)
    {
        var entity = await _context.Gak.FirstOrDefaultAsync(g => g.Id == request.Id, ct);
        if (entity == null)
            return false;

        entity.NomerPrikaza = request.NomerPrikaza;
        entity.KolvoBudget = request.KolvoBudget;
        entity.KolvoPlatka = request.KolvoPlatka;
        entity.PeriodZasedaniaId = request.PeriodZasedaniaId;
        entity.KafedraID = request.KafedraId;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
