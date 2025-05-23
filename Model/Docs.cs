using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asugaksharp.Model
{
    internal class Docs
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsUploaded { get; set; }
        public string Data { get; set; } = string.Empty;

        public int PersonId { get; set; }
        public Person? Person { get; set; }


    }
}
