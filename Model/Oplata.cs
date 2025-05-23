using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asugaksharp.Model
{
    internal class Oplata
    {
        public int Id { get; set; } 
        public float Stavka { get; set; }
        public float Ndfl { get; set; }
        public float Enp { get; set; }  
        public int MoneySource { get; set; }
        public int DogovorNumber { get; set; }

        //от таблицы person
        public int PersonId { get; set; }   
        public Person? Person { get; set; }



    }
}
