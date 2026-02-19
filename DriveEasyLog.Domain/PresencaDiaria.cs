using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyLog.Domain
{
    public class PresencaDiaria
    {
        public Guid Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public bool VaiHoje { get; set; }
        public DateTime Confirmado { get; set; } = DateTime.MinValue;
        public bool Embarcou { get; set; } = false;
        public DateTime? HorarioEmbarque { get; set; }
        public string Observacao { get; set; } = string.Empty;
        public DateTime ConfirmadoEm { get; set; }
        public Guid AlunoId { get; set; }
        public Aluno? Aluno { get; set; }

        public Guid ViagemId { get; set; }
        public Viagem? Viagem { get; set; }

    }
}