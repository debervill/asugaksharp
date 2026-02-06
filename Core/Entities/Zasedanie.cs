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

        //связь с персон через PersonZasedanie
        public ICollection<PersonZasedanie>? PersonZasedanies { get; set; }

        //связь с дипломниками
        public ICollection<Diplomnik>? Diplomniks { get; set; }

        //связь с оплатами
        public ICollection<Oplata>? Oplatas { get; set; }
    }
}
