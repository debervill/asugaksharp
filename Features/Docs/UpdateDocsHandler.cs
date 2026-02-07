using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Docs;

public class UpdateDocsHandler
{
    private readonly AppDbContext _context;
    public UpdateDocsHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(UpdateDocsRequest request, CancellationToken ct = default)
    {
        var entity = await _context.Docs.FirstOrDefaultAsync(d => d.Id == request.Id, ct);
        if (entity == null)
            return false;

        entity.Name = request.Name;
        entity.IsUploaded = request.IsUploaded;
        entity.Data = request.Data;
        entity.PersonId = request.PersonId;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
