using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Domain;
using DriveEasyLog.Persistence.Contratos; // Onde moram as interfaces

namespace DriveEasyLog.Application
{
    public class AlunoService : IAlunosService
    {
        private readonly IAlunoPersist _alunoPersist;
        private readonly IGeralPersist _geralPersist;

        // CORREÇÃO 1: Adicionado o Construtor para injeção de dependência
        public AlunoService(IAlunoPersist alunoPersist, IGeralPersist geralPersist)
        {
            _alunoPersist = alunoPersist;
            _geralPersist = geralPersist;
        }

        public async Task<Aluno> AddAlunoAsync(Aluno model)
        {
            try
            {
                _geralPersist.Add(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    // Busca o aluno recém criado com os relacionamentos
                    return await _alunoPersist.GetAlunoByIdAsync(model.Id,true);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Aluno> UpdateAlunoAsync(Guid alunoId, Aluno model)
        {
            try
            {
                var aluno = await _alunoPersist.GetAlunoByIdAsync(alunoId);
                if (aluno == null) return null;

                model.Id = aluno.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _alunoPersist.GetAlunoByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // CORREÇÃO 2: Alterado para Task<bool> para bater com o SaveChanges e a Interface
        public async Task<bool> DeleteAlunoAsync(Guid alunoId)
        {
            try
            {
                var aluno = await _alunoPersist.GetAlunoByIdAsync(alunoId);
                if (aluno == null) throw new Exception("Aluno para delete não encontrado.");

                _geralPersist.Delete(aluno);
                return await _geralPersist.SaveChangesAsync(); // Retorna true ou false
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Aluno[]> GetAllAlunosAsync(bool includeEscola = false, bool includeMotorista = false, bool includeResponsavel = false)
        {
            try
            {
                return await _alunoPersist.GetAllAlunosAsync(includeEscola, includeMotorista, includeResponsavel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Aluno[]> GetAllAlunosByMotoristaIdAsync(Guid motoristaId)
        {
            try
            {
                return await _alunoPersist.GetAllAlunosByMotoristaIdAsync(motoristaId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Aluno[]> GetAllAlunosByPeriodoAsync(Periodo periodo, bool includeEscola = false, bool includeMotorista = false, bool includeResponsavel = false)
        {
            try
            {
                return await _alunoPersist.GetAllAlunosByPeriodoAsync(periodo, includeEscola, includeMotorista, includeResponsavel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Aluno> GetAlunoByIdAsync(Guid alunoId, bool includeEscola = false, bool includeMotorista = false, bool includeResponsavel = false)
        {
            try
            {
                return await _alunoPersist.GetAlunoByIdAsync(alunoId, includeEscola || includeMotorista || includeResponsavel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}