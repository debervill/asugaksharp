using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Core.Entities
{
    public class Zasedanie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string NapravleniePodgotovki { get; set; } =string.Empty;
        public string Kvalificacia { get; set; } =string.Empty;
        public DateOnly Date { get; set; }
        
        //связь с гаком
        public Guid GakID { get; set; }
        public Gak? Gak { get; set; }

        //связь с персон
        public ICollection<Person>? Persons { get; set; }


        
    }
}
