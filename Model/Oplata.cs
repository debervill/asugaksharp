
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Model
{
    public class Oplata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public float Stavka { get; set; }
        public float Ndfl { get; set; }
        public float Enp { get; set; }  
        public int MoneySource { get; set; }
        public int DogovorNumber { get; set; }

        //от таблицы person
        public Guid PersonId { get; set; }   
        public Person? Person { get; set; }



    }
}
