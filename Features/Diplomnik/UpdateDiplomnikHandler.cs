using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Diplomnik;

public class UpdateDiplomnikHandler
{
    private readonly AppDbContext _context;
    public UpdateDiplomnikHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(UpdateDiplomnikRequest request, CancellationToken ct = default)
    {
        var entity = await _context.Diplomnik.FirstOrDefaultAsync(d => d.Id == request.Id, ct);
        if (entity == null)
            return false;

        entity.FioImen = request.FioImen;
        entity.FioRodit = request.FioRodit;
        entity.Sex = request.Sex;
        entity.Pages = request.Pages;
        entity.Tema = request.Tema;
        entity.OrigVkr = request.OrigVkr;
        entity.Srball = request.Srball;
        entity.PersonId = request.PersonId;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
