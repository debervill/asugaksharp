using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Kafedra;

public class GetKafedrasHandler
{
    private readonly AppDbContext _context;
    public GetKafedrasHandler(AppDbContext context) => _context = context;

    public async Task<List<KafedraDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.Kafedra
            .AsNoTracking()
            .OrderBy(k => k.Name)
            .Select(k => new KafedraDto(k.Id, k.Name, k.ShortName, k.Description))
            .ToListAsync(ct);
    }
}