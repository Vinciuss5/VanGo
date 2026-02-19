using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyLog.Domain
{
    public class Pagamento
    {
        public Guid Id { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public double Valor { get; set; }
        public StatusPagamento? Status { get; set; }
        public Guid ContratoId { get; set; }
        public Contrato? Contrato { get; set; }

    }
}