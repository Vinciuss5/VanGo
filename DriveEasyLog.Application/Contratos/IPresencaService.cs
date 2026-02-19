using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyLog.Application.Contratos
{
    public interface IPresencaService
    {
        Task<bool> MarcarAusenciaAsync(Guid viagemId, Guid alunoId, string observacao);
        Task<bool> RegistrarEmbarqueAsync(Guid viagemId, Guid alunoId);
    }
}