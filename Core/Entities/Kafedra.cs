namespace asugaksharp.Core.Entities
{
    public class Kafedra
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;



        //от таблицы гак
        public ICollection<Gak>? Gaks { get; set; }
        
        //от таблицы персон
        public ICollection<Person>? Persons { get; set; }

        public ICollection<PeriodZasedania>? Periods { get; set; }

    }

}
