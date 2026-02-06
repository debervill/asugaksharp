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

        var kolvoStudentov = request.KolvoBudget + request.KolvoPlatka;
        var akademChasov = kolvoStudentov * request.Koefficient;
        var astronomChasov = akademChasov * 0.75f;
        var summaBezNalogov = akademChasov * request.StoimostChasa;
        var stoimostAkademChasaSNalogami = request.StoimostChasa * 1.3f;
        var obshayaStoimostUslugPoDogovoru = stoimostAkademChasaSNalogami * akademChasov;
        var ndflProc = 13f;
        var ndflSumma = summaBezNalogov * (ndflProc / 100f);
        var enpProc = 30f;
        var enpSumma = summaBezNalogov * (enpProc / 100f);
        var summaKVyplate = summaBezNalogov - ndflSumma;
        var summaSNalogami = summaBezNalogov + enpSumma;

        entity.PersonId = request.PersonId;
        entity.GakId = request.GakId;
        entity.RolVGek = request.RolVGek;
        entity.KolvoBudget = request.KolvoBudget;
        entity.KolvoPlatka = request.KolvoPlatka;
        entity.Koefficient = request.Koefficient;
        entity.StoimostChasa = request.StoimostChasa;
        entity.StoimostAkademChasaSNalogami = stoimostAkademChasaSNalogami;
        entity.ObshayaStoimostUslugPoDogovoru = obshayaStoimostUslugPoDogovoru;
        entity.AkademChasov = akademChasov;
        entity.AstronomChasov = astronomChasov;
        entity.SummaBezNalogov = summaBezNalogov;
        entity.NdflProc = ndflProc;
        entity.NdflSumma = ndflSumma;
        entity.EnpProc = enpProc;
        entity.EnpSumma = enpSumma;
        entity.SummaKVyplate = summaKVyplate;
        entity.SummaSNalogami = summaSNalogami;
        entity.TotalNachisleno = 0f;
        entity.TotalNdfl = 0f;
        entity.TotalEnp = 0f;
        entity.TotalKVyplate = 0f;
        entity.DogovorNumber = request.DogovorNumber;
        entity.MoneySource = request.MoneySource;
        entity.DataRascheta = DateTime.Now;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
