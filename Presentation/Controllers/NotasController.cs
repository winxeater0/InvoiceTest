using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class NotasController : ControllerBase
{
    private readonly INotaFiscalService _notaFiscalService;

    public NotasController(INotaFiscalService notaFiscalService)
    {
        _notaFiscalService = notaFiscalService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _notaFiscalService.ObterNotasAsync();
        if (!result.Success)
            return BadRequest(result.Error);

        return Ok(result.Data);
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import([FromBody] string xml)
    {
        var result = await _notaFiscalService.ImportarXmlAsync(xml);
        if (!result.Success)
            return BadRequest(result.Error);

        return Ok(result.Data);
    }
}
