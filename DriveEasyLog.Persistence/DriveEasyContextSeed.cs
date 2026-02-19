using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;
using DriveEasyLog.Persistence.Contexto;

namespace DriveEasyLog.Persistence
{
    public static class DriveEasyContextSeed
{
    public static void Seed(DriveEasyContext context)
    {
        if (!context.Escolas.Any())
        {
            var escola = new Escola { Id = Guid.NewGuid(), Nome = "Escola Padrão", Endereco = "Rua Exemplo, 123" };
            context.Escolas.Add(escola);
            
            var veiculo = new Veiculo { Id = Guid.NewGuid(), Placa = "ABC-1234", Modelo = "Van", Marca = "Peugeot", Motorista =  null };
            context.Veiculos.Add(veiculo);

            var motorista = new Motorista { Id = Guid.NewGuid(), Nome = "Motorista Teste", Cpf = "12345678900", Cnh = "CNH123456", Telefone = "11999999999", Veiculo = veiculo };
            context.Motoristas.Add(motorista);

            context.SaveChanges();
        }
    }
}
}