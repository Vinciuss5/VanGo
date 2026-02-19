using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyLog.Domain
{
    public class Aluno
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        [StringLength(6)]
        public string CodigoAcesso { get; set; } = string.Empty;
        public bool AppVinculado { get; set; } = false;
        public  string? EnderecoBusca { get; set; }
        public float LatBusca { get; set; }
        public float LngBusca { get; set; }
        public  Periodo Periodo { get; set; }
        public Guid MotoristaId { get; set; }
        public  Motorista? Motorista { get; set; }
        public Guid ResponsavelId { get; set; }
        public  Responsavel? Responsavel { get; set; }
        public Guid EscolaId { get; set; }
        public  Escola? Escola { get; set; }
        public ICollection<PresencaDiaria> Presencas { get; set; } = new List<PresencaDiaria>();
        public  Contrato? Contrato { get; set; }



    }
}