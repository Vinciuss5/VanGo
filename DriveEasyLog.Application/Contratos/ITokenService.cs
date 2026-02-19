using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Domain;

namespace DriveEasyLog.Application.Contratos
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}