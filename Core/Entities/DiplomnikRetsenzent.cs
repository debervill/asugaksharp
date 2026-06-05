using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Core.Entities
{
    public class DiplomnikRetsenzent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid DiplomnikId { get; set; }
        public Diplomnik? Diplomnik { get; set; }

        public Guid PersonId { get; set; }
        public Person? Person { get; set; }

        public int SortOrder { get; set; }
    }
}
