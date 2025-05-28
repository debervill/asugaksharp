using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Model
{
    public class Diplomnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FioImen { get; set; } = string.Empty;
        public string FioRodit { get; set; } = string.Empty;
        public string Sex { get; set; } = String.Empty;
        public int Pages { get; set; }
        public string Tema { get; set; } = String.Empty;                  
        public float OrigVkr { get; set; }
        public float Srball { get; set; }

        //от таблицы Персон 

        public Guid PersonId { get; set; }   
        public Person? Person { get; set; }

    }
}
