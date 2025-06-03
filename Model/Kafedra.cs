using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Model
{
    public class Kafedra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;



        //от таблицы гак
        public ICollection<Gak>? Gaks { get; set; }
        
        //от таблицы персон
        public ICollection<Person>? Persons { get; set; }

    }

}
