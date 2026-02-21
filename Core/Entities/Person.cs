using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Core.Entities
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

        // Персональные данные
        public string? PassportSeria { get; set; }
        public string? PassportNomer { get; set; }
        public string? PassportIssuedBy { get; set; }
        public string? RegistrationAddress { get; set; }
        public string? Snils { get; set; }
        public string? Inn { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        //от таблицы кафедра

        public Guid KafedraID { get; set; }
        public Kafedra? Kafedra { get; set; }


        //от таблицы заседание через PersonZasedanie
        public ICollection<PersonZasedanie>? PersonZasedanies { get; set; }

        //от таблицы докс
        public ICollection<Docs>? Docs { get; set; }

        //от таблицы Студент
        public ICollection<Student>? Students { get; set;}

        //от таблицы оплата

        public ICollection<Oplata>? Oplatas { get; set; }


        public ICollection<Gak>? Gaks { get; set; }





    }
}
