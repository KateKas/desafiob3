using Domain.Interfaces;
using Domain.Models.CDB.Dto;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CDBController : ControllerBase
{
    private readonly ILogger<CDBController> _logger;
    public readonly ICDBService _cDBService;

    public CDBController(ILogger<CDBController> logger,  ICDBService cDBService)
    {
        _logger = logger;
        _cDBService = cDBService;
    }

    [HttpPost(Name = "ObterCalculoCDB")]
    public async Task<ActionResult> ObterCalculoCDB([FromBody][Required] CDBRequestDto cDBRequest)
    {
        try
        {
            if (cDBRequest.ValorInicial <= 0) {
                return BadRequest("O valor inicial precisa ser um valor positivo.");
            }

            if(cDBRequest.Prazo <= 0)
            {
                return BadRequest("O prazo precisa ser um valor positivo.");
            }

            var resposta = await _cDBService.ObterCalculoCDB(cDBRequest);
            return Ok(resposta);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
