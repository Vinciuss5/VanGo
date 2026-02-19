using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Domain;
using DriveEasyLog.Persistence.Contratos;

namespace DriveEasyLog.Application
{
        public class ViagemService : IViagemService
    {
            private readonly IGeralPersist _geral;
            private readonly IViagemPersist _viagemPersist;
            private readonly IMotoristaPersist _motoristaPersist;

            public ViagemService(IGeralPersist geral, IViagemPersist viagemPersist, IMotoristaPersist motoristaPersist)
        {
                _geral = geral;
                _viagemPersist = viagemPersist;
                _motoristaPersist = motoristaPersist;
        }

            public async Task<Viagem> IniciarViagemAsync(Guid motoristaId, int periodo)
        {
        // 1. Criar a nova viagem
                var novaViagem = new Viagem {
                Id = Guid.NewGuid(),
                MotoristaId = motoristaId,
                Inicio = DateTime.Now,
                Periodo = (Periodo)periodo, // Certifique-se que o enum bate
                Finalizada = false };

        // 2. Buscar alunos do motorista para gerar o checklist (presenças)
                var motorista = await _motoristaPersist.GetMotoristaByIdAsync(motoristaId, true);
                var alunos = motorista?.Alunos;

                if (alunos != null)
                {
                foreach (var aluno in alunos)
                {
                var presenca = new PresencaDiaria {
                    Id = Guid.NewGuid(),
                    AlunoId = aluno.Id,
                    ViagemId = novaViagem.Id,
                    VaiHoje = true // Padrão é ir, o pai desmarca se necessário
                };
                _geral.Add(presenca);
                }
                }

        _geral.Add(novaViagem);

            if (await _geral.SaveChangesAsync())
                return await _viagemPersist.GetViagemByIdAsync(novaViagem.Id, true);

            return null;
        }

        public async Task<Viagem> FinalizarViagemAsync(Guid viagemId)
        {
            var viagem = await _viagemPersist.GetViagemByIdAsync(viagemId, true);
            if (viagem == null) return null;

            viagem.Finalizada = true;
            viagem.Fim = DateTime.Now;

            _geral.Update(viagem);
            return await _geral.SaveChangesAsync() ? viagem : null;
        }

        public async Task<Viagem> GetViagemByIdAsync(Guid viagemId, bool includePresencas = true) =>
        await _viagemPersist.GetViagemByIdAsync(viagemId, includePresencas);
    
        public async Task<Viagem> GetViagemAtivaByMotoristaIdAsync(Guid motoristaId)
        {
        try
        {
            return await _viagemPersist.GetViagemAtivaByMotoristaIdAsync(motoristaId);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        }
    
    }

}