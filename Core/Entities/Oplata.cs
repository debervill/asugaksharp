using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Core.Entities
{
    public class Oplata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Связи
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }

        public Guid GakId { get; set; }
        public Gak? Gak { get; set; }

        // Базовые данные для расчета
        public string RolVGek { get; set; } = string.Empty; // роль в ГЭК
        public int KolvoBudget { get; set; } // количество бюджетных студентов
        public int KolvoPlatka { get; set; } // количество платных студентов
        public float Koefficient { get; set; } // коэффициент
        public float StoimostChasa { get; set; } // стоимость часа
        public float StoimostAkademChasaSNalogami { get; set; } // стоимость академического часа с налогами
        public float ObshayaStoimostUslugPoDogovoru { get; set; } // общая стоимость услуг по договору

        // Расчётные значения
        public float AkademChasov { get; set; } // академические часы = (KolvoBudget + KolvoPlatka) * Koefficient
        public float AstronomChasov { get; set; } // астрономические часы = AkademChasov * 0.75

        // Хранимые расчетные значения
        public float SummaBezNalogov { get; set; } // = AkademChasov * StoimostChasa
        public float NdflProc { get; set; } // процент НДФЛ (обычно 13)
        public float NdflSumma { get; set; } // = SummaBezNalogov * 0.13
        public float EnpProc { get; set; } // процент ЕНП (обычно 30)
        public float EnpSumma { get; set; } // = SummaBezNalogov * 0.30
        public float SummaKVyplate { get; set; } // = SummaBezNalogov - NdflSumma (на руки)
        public float SummaSNalogami { get; set; } // = SummaBezNalogov + EnpSumma (полная стоимость)
        public float TotalNachisleno { get; set; } // итого начислено по ГАК
        public float TotalNdfl { get; set; } // итого НДФЛ по ГАК
        public float TotalEnp { get; set; } // итого ЕНП по ГАК
        public float TotalKVyplate { get; set; } // итого к выплате по ГАК

        // Дополнительно
        public int DogovorNumber { get; set; } // номер договора
        public int MoneySource { get; set; } // источник финансирования (бюджет/внебюджет)
        public DateTime DataRascheta { get; set; } // когда рассчитано
        public bool IsDogovorGenerated { get; set; } // сгенерирован ли договор
    }
}
