using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyLog.Domain
{
    public class CoordenadasDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime? HoraInicio { get; set; }
    }
}