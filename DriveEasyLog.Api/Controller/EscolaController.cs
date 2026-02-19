using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Domain;
using DriveEasyLog.Persistence.Contratos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EscolasController : ControllerBase
{
    private readonly IGeralPersist _geral;
    private readonly IEscolaPersist _escolaPersist;

    public EscolasController(IGeralPersist geral, IEscolaPersist escolaPersist)
    {
        _geral = geral;
        _escolaPersist = escolaPersist;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _escolaPersist.GetAllEscolasAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Escola model)
    {
        _geral.Add(model);
        return await _geral.SaveChangesAsync() ? Ok(model) : BadRequest("Erro ao salvar escola");
    }
}