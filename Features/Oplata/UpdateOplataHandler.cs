using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Oplata;

public class UpdateOplataHandler
{
    private readonly AppDbContext _context;
    public UpdateOplataHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(UpdateOplataRequest request, CancellationToken ct = default)
    {
        var entity = await _context.Oplata.FirstOrDefaultAsync(o => o.Id == request.Id, ct);
        if (entity == null)
            return false;

        entity.Stavka = request.Stavka;
        entity.Ndfl = request.Ndfl;
        entity.Enp = request.Enp;
        entity.MoneySource = request.MoneySource;
        entity.DogovorNumber = request.DogovorNumber;
        entity.PersonId = request.PersonId;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
