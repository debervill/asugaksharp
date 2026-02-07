using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Person;

public class UpdatePersonHandler
{
    private readonly AppDbContext _context;
    public UpdatePersonHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(UpdatePersonRequest request, CancellationToken ct = default)
    {
        var entity = await _context.Person.FirstOrDefaultAsync(p => p.Id == request.Id, ct);
        if (entity == null)
            return false;

        entity.Name = request.Name;
        entity.Stepen = request.Stepen;
        entity.Zvanie = request.Zvanie;
        entity.Dolgnost = request.Dolgnost;
        entity.IsPredsed = request.IsPredsed;
        entity.IsZavKaf = request.IsZavKaf;
        entity.IsSecretar = request.IsSecretar;
        entity.IsRecenzent = request.IsRecenzent;
        entity.IsVneshniy = request.IsVneshniy;
        entity.KafedraID = request.KafedraId;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
