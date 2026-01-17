using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Kafedra;

public class UpdateKafedraHandler
{
    private readonly AppDbContext _context;
    public UpdateKafedraHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(UpdateKafedraRequest request, CancellationToken ct = default)
    {
        var entity = await _context.Kafedra.FirstOrDefaultAsync(k => k.Id == request.Id, ct);
        if (entity == null)
            return false;

        entity.Name = request.Name;
        entity.ShortName = request.ShortName;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
