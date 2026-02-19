using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyLog.Application.Contratos
{
    public interface IRotasService
    {
        Task<List<string>> IniciarRotaOtimizada(Guid motoristaId, List<string> destinos, Guid alunosId, Guid presencaId);
        Task<string> CalcularMelhorOrdem(string origem, List<string> destinos, Guid prensencaId);
    }
}