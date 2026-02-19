using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyLog.Domain
{
    public class Escola
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public float Lat { get; set; }
        public float Lng { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

    }
}