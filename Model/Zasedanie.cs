

namespace asugaksharp.Model
{
    public class Zasedanie
    { 
        public int Id { get; set; }
        public string NapravleniePodgotovki { get; set; } =string.Empty;
        public string Kvalificacia { get; set; } =string.Empty;
        public DateOnly Date { get; set; }
        
        //связь с гаком
        public int GakID { get; set; }
        public Gak? Gak { get; set; }

        //связь с персон
        public ICollection<Person>? Persons { get; set; }


        
    }
}
