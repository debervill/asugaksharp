using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Core.Entities
{
    public class Gak
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string NomerPrikaza { get; set; } = string.Empty;
        public string Osnovanie { get; set; } = string.Empty; // основание (приказ ВПО №1156 от 15.12.2023)
        public DateTime DataPrikaza { get; set; }
        public int KolvoBudget { get; set; }
        public int KolvoPlatka { get; set; }


        //от таблицы период заседания
        public Guid PeriodZasedaniaId { get; set; }
        public PeriodZasedania? PeriodZasedania { get; set; }

        //от таблицы заседания
        public ICollection<Zasedanie>? Zasedanies { get; set; }
        
        //от таблицы кафедра
        public Guid KafedraID { get; set; }
        public Kafedra? Kafedra { get; set; }

        //от таблицы персона - председатель ГАК
        public Guid? PredsedatelId { get; set; }
        public Person? Predsedatel { get; set; }

        //от таблицы персона - секретарь ГАК
        public Guid? SekretarId { get; set; }
        public Person? Sekretar { get; set; }

        //от таблицы персона - члены комиссии
        public ICollection<Person>? Persons { get; set; }
    }
}
