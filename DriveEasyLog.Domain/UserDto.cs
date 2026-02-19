using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEasyLog.Domain
{
    public class UserDto
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
       public string Cnh { get; set; } = string.Empty;
        public string Veiculo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Modelo { get; set; }= string.Empty;
    }
}