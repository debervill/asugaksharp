using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Oplata;

public class CreateOplataHandler
{
    private readonly AppDbContext _context;
    public CreateOplataHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreateOplataRequest request, CancellationToken ct = default)
    {
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

        var entity = new Core.Entities.Oplata
        {
            Id = Guid.NewGuid(),
            PersonId = request.PersonId,
            GakId = request.GakId,
            RolVGek = request.RolVGek,
            KolvoBudget = request.KolvoBudget,
            KolvoPlatka = request.KolvoPlatka,
            Koefficient = request.Koefficient,
            StoimostChasa = request.StoimostChasa,
            StoimostAkademChasaSNalogami = stoimostAkademChasaSNalogami,
            ObshayaStoimostUslugPoDogovoru = obshayaStoimostUslugPoDogovoru,
            AkademChasov = akademChasov,
            AstronomChasov = astronomChasov,
            SummaBezNalogov = summaBezNalogov,
            NdflProc = ndflProc,
            NdflSumma = ndflSumma,
            EnpProc = enpProc,
            EnpSumma = enpSumma,
            SummaKVyplate = summaKVyplate,
            SummaSNalogami = summaSNalogami,
            TotalNachisleno = 0f,
            TotalNdfl = 0f,
            TotalEnp = 0f,
            TotalKVyplate = 0f,
            DogovorNumber = request.DogovorNumber,
            MoneySource = request.MoneySource,
            DataRascheta = DateTime.Now,
            IsDogovorGenerated = false
        };

        _context.Oplata.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
