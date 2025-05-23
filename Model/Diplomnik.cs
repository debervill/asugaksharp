using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asugaksharp.Model
{
    internal class Diplomnik
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public string Sex { get; set; } = String.Empty;
        public int Pages { get; set; }
        public string Tema { get; set; } = String.Empty;                  
        public float OrigVkr { get; set; }
        public float Srball { get; set; }

        //от таблицы Персон 

        public int PersonId { get; set; }   
        public Person? Person { get; set; }

    }
}
