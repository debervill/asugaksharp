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

        entity.StudentId = request.StudentId;
        entity.ZasedanieId = request.ZasedanieId;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
