using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyLog.Domain
{
    public class Viagem
    {
        public Guid Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public Periodo? Periodo { get; set; }
        public bool Finalizada { get; set; }
        public Guid MotoristaId { get; set; }
        public Motorista? Motorista { get; set; }
        public ICollection<PresencaDiaria> Presencas { get; set; } = new List<PresencaDiaria>();

    }
}