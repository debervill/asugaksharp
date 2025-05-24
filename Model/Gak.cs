namespace asugaksharp.Model
{
    public class Gak
    {
        public int Id { get; set; }
        public string NomerPrikaza { get; set; } = string.Empty;
        public int KolvoBudget { get; set; }
        public int KolvoPlatka { get; set; }


        //от таблицы период заседания
        public int PeriodZasedaniaId { get; set; }
        public PeriodZasedania? PeriodZasedania { get; set; }

        //от таблицы заседания
        public ICollection<Zasedanie>? Zasedanies { get; set; }
        
        //от таблицы кафедра
        public int KafedraID { get; set; }
        public Kafedra? Kafedra { get; set; }

        //от таблицы персона 
        public ICollection<Person>? Persons { get; set; }    
    }
}
