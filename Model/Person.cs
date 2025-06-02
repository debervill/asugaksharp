
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Model
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Stepen { get; set; } = string.Empty;
        public string Zvanie { get; set; } = string.Empty;
        public string Dolgnost { get; set; } = string.Empty;
        public bool IsPredsed { get; set; }
        public bool IsZavKaf { get; set; }
        public bool IsSecretar { get; set; }
        public bool IsRecenzent { get; set; }
        public bool IsVneshniy { get; set; }





        //от таблицы заседание

        public ICollection<Zasedanie>? Zasedanies { get; set; }
       
        //от таблицы докс
        public ICollection<Docs>? Docs { get; set; }

        //от таблицы Дипломник
        public ICollection<Diplomnik>? Diplomniks { get; set;}

        //от таблицы оплата

        public ICollection<Oplata>? Oplatas { get; set; }
        


     
    }
}
