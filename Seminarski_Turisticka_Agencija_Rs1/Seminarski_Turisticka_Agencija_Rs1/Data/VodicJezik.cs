using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Data
{
    public class VodicJezik
    {
        public TuristickiVodic TuristickiVodic { get; set; }
        public int TuristickiVodicId { get; set; }
        public Jezik Jezik { get; set; }
        public int JezikId { get; set; }
    }
}
