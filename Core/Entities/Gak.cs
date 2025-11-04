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

        //от таблицы персона 
        public ICollection<Person>? Persons { get; set; }    
    }
}
