using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.PeriodZasedania;

public class UpdatePeriodZasedaniaHandler
{
    private readonly AppDbContext _context;
    public UpdatePeriodZasedaniaHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(UpdatePeriodZasedaniaRequest request, CancellationToken ct = default)
    {
        var entity = await _context.PeriodZasedania.FirstOrDefaultAsync(p => p.Id == request.Id, ct);
        if (entity == null)
            return false;

        entity.Name = request.Name;
        entity.DateStart = request.DateStart;
        entity.DateEnd = request.DateEnd;
        entity.Primechanie = request.Primechanie;
        entity.KafedraId = request.KafedraId;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
