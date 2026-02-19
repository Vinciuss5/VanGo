using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Domain;
using DriveEasyLog.Persistence;
using DriveEasyLog.Persistence.Contratos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DriveEasyLog.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
        public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IGeralPersist _geral;
    private readonly ITokenService _tokenService; // Vamos criar esse serviço a seguir

    public AccountController(UserManager<User> userManager, IGeralPersist geral, ITokenService tokenService)
    {
        _userManager = userManager;
        _geral = geral;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDto userDto)
    {
        
        var user = new User {
            UserName = userDto.Email,
            Email = userDto.Email,
            NomeCompleto = userDto.NomeCompleto
        };

        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (result.Succeeded)
        {
            
            var motorista = new Motorista {
                Nome = userDto.NomeCompleto,
                Cnh = userDto.Cnh,
                UserId = user.Id, 
                Veiculo = new Veiculo { 
                Placa = userDto.Placa,
                Modelo = userDto.Modelo,
                Marca = userDto.Veiculo, 
                Id = Guid.NewGuid()
                }
            };

            _geral.Add(motorista);
            await _geral.SaveChangesAsync();

            return Ok(new {
                userName = user.UserName,
                token = _tokenService.CreateToken(user)
            });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null) return Unauthorized("E-mail inválido");

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!result) return Unauthorized("Senha inválida");

        return Ok(new {
            userName = user.UserName,
            token = _tokenService.CreateToken(user)
        });
    }
    }
}