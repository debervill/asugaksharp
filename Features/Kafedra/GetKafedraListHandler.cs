namespace asugaksharp.Features.Kafedra.GetKafedraList;

using asugaksharp.Core.Common;
using asugaksharp.Core.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class GetKafedraListHandler :
    IRequestHandler<GetKafedraListQuery, System.Collections.Generic.List<KafedraDto>>
{
    private readonly AppDbContext _context;

    public GetKafedraListHandler(AppDbContext context)
    {
        _context = context;
    }

    public async System.Threading.Tasks.Task<Result<System.Collections.Generic.List<KafedraDto>>>
        HandleAsync(
            GetKafedraListQuery request,
            System.Threading.CancellationToken ct = default)
    {
        try
        {
            var kafedras = await _context.Kafedras
                .Select(k => new KafedraDto(k.Id, k.Name))
                .ToListAsync(ct);

            return Result<System.Collections.Generic.List<KafedraDto>>.Success(kafedras);
        }
        catch (System.Exception ex)
        {
            return Result<System.Collections.Generic.List<KafedraDto>>
                .Failure($"Ошибка: {ex.Message}");
        }
    }
}