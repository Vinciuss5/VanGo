using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyLog.Domain
{
    public class Contrato
    {
        public Guid Id { get; set; }
        public double ValorMensal { get; set; }
        public int DiaVencimento { get; set; }
        public bool Ativo { get; set; }
        public Guid AlunoId { get; set; }
        public Aluno? Aluno { get; set; }

        public ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

    }
}