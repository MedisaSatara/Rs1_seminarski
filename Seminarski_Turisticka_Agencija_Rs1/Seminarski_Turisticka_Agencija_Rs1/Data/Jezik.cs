using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Data
{
    public class Jezik
    {
        public int Id { get; set; }
        public string NazivJezika { get; set; }
        public IEnumerable<VodicJezik> JezikVodic { get; set; }
    }
}
