using System.ComponentModel;

namespace asugaksharp.Features.Oplata;

public class OplataRowDto : INotifyPropertyChanged
{
    public Guid? OplataId { get; set; } // null для новых записей
    public Guid PersonId { get; set; }
    public string PersonName { get; set; } = string.Empty;
    public string RolVGek { get; set; } = string.Empty;

    private int _kolvoBudget;
    public int KolvoBudget
    {
        get => _kolvoBudget;
        set { _kolvoBudget = value; OnPropertyChanged(nameof(KolvoBudget)); OnPropertyChanged(nameof(KolvoStudentov)); }
    }

    private int _kolvoPlatka;
    public int KolvoPlatka
    {
        get => _kolvoPlatka;
        set { _kolvoPlatka = value; OnPropertyChanged(nameof(KolvoPlatka)); OnPropertyChanged(nameof(KolvoStudentov)); }
    }

    public int KolvoStudentov => KolvoBudget + KolvoPlatka;

    private float _koefficient;
    public float Koefficient
    {
        get => _koefficient;
        set { _koefficient = value; OnPropertyChanged(nameof(Koefficient)); }
    }

    private float _akademChasov;
    public float AkademChasov
    {
        get => _akademChasov;
        set
        {
            _akademChasov = value;
            OnPropertyChanged(nameof(AkademChasov));
            OnPropertyChanged(nameof(ObshayaStoimostUslugPoDogovoru));
        }
    }

    private float _astronomChasov;
    public float AstronomChasov
    {
        get => _astronomChasov;
        set { _astronomChasov = value; OnPropertyChanged(nameof(AstronomChasov)); }
    }

    private float _stoimostChasa;
    public float StoimostChasa
    {
        get => _stoimostChasa;
        set
        {
            _stoimostChasa = value;
            OnPropertyChanged(nameof(StoimostChasa));
            OnPropertyChanged(nameof(StoimostAkademChasaSNalogami));
            OnPropertyChanged(nameof(ObshayaStoimostUslugPoDogovoru));
        }
    }

    public float StoimostAkademChasaSNalogami => StoimostChasa * 1.3f;

    private float _summaBezNalogov;
    public float SummaBezNalogov
    {
        get => _summaBezNalogov;
        set { _summaBezNalogov = value; OnPropertyChanged(nameof(SummaBezNalogov)); }
    }

    private float _ndflSumma;
    public float NdflSumma
    {
        get => _ndflSumma;
        set { _ndflSumma = value; OnPropertyChanged(nameof(NdflSumma)); }
    }

    private float _enpSumma;
    public float EnpSumma
    {
        get => _enpSumma;
        set { _enpSumma = value; OnPropertyChanged(nameof(EnpSumma)); }
    }

    private float _summaKVyplate;
    public float SummaKVyplate
    {
        get => _summaKVyplate;
        set { _summaKVyplate = value; OnPropertyChanged(nameof(SummaKVyplate)); }
    }

    private float _obshayaStoimostUslugPoDogovoru;
    public float ObshayaStoimostUslugPoDogovoru
    {
        get => _obshayaStoimostUslugPoDogovoru;
        set { _obshayaStoimostUslugPoDogovoru = value; OnPropertyChanged(nameof(ObshayaStoimostUslugPoDogovoru)); }
    }

    public void Recalculate()
    {
        AkademChasov = KolvoStudentov * Koefficient;
        AstronomChasov = AkademChasov * 0.75f; // 45 мин / 60 мин
        SummaBezNalogov = AkademChasov * StoimostChasa;
        NdflSumma = SummaBezNalogov * 0.13f;
        EnpSumma = SummaBezNalogov * 0.30f;
        SummaKVyplate = SummaBezNalogov - NdflSumma;
        ObshayaStoimostUslugPoDogovoru = StoimostAkademChasaSNalogami * AkademChasov;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public record GakInfoDto(
    Guid Id,
    string NomerPrikaza,
    int KolvoBudget,
    int KolvoPlatka);

public record OplataDto(
    Guid Id,
    Guid PersonId,
    string? PersonName,
    Guid GakId,
    string RolVGek,
    int KolvoBudget,
    int KolvoPlatka,
    float Koefficient,
    float StoimostChasa,
    float StoimostAkademChasaSNalogami,
    float ObshayaStoimostUslugPoDogovoru,
    float AkademChasov,
    float AstronomChasov,
    float SummaBezNalogov,
    float NdflProc,
    float NdflSumma,
    float EnpProc,
    float EnpSumma,
    float SummaKVyplate,
    float SummaSNalogami,
    int DogovorNumber,
    int MoneySource,
    DateTime DataRascheta,
    bool IsDogovorGenerated);

public record CreateOplataRequest(
    Guid PersonId,
    Guid GakId,
    string RolVGek,
    int KolvoBudget,
    int KolvoPlatka,
    float Koefficient,
    float StoimostChasa,
    int DogovorNumber,
    int MoneySource);

public record UpdateOplataRequest(
    Guid Id,
    Guid PersonId,
    Guid GakId,
    string RolVGek,
    int KolvoBudget,
    int KolvoPlatka,
    float Koefficient,
    float StoimostChasa,
    int DogovorNumber,
    int MoneySource);
