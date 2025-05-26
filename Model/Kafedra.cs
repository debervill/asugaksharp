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
        public string Phone { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Fiozav { get; set; }= string.Empty;

        //от таблицы гак
        public ICollection<Gak>? Gaks { get; set; }
    }
}
