using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Docs;

public class GetDocsHandler
{
    private readonly AppDbContext _context;
    public GetDocsHandler(AppDbContext context) => _context = context;

    public async Task<List<DocsDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.Docs
            .AsNoTracking()
            .Include(d => d.Person)
            .OrderBy(d => d.Name)
            .Select(d => new DocsDto(
                d.Id,
                d.Name,
                d.IsUploaded,
                d.Data,
                d.PersonId,
                d.Person != null ? d.Person.Name : null))
            .ToListAsync(ct);
    }
}
