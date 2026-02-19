using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyLog.Domain
{
    public class Veiculo
    {
        public Guid Id { get; set; }
        public  string Placa { get; set; } = string.Empty;
        public  string Modelo { get; set; } = string.Empty;
        public  string Marca { get; set; } = string.Empty;
        public Guid MotoristaId { get; set; }
        public  Motorista? Motorista { get; set; }

    }
}