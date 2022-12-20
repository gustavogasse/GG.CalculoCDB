using GG.CalculoCDB.UI.Web.Services;
using GG.CalculoCDB.UI.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GG.CalculoCDB.UI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResgateInvestimentoController : ControllerBase
    {
        private CalculoImpostoService _calculoImpostoService;

        public ResgateInvestimentoController(CalculoImpostoService calculoImpostoService)
        {
            _calculoImpostoService = calculoImpostoService;
        }

        [HttpGet("CalcularInvestimento")]
        public ResultadoInvestimento CalcularInvestimento(double valorMonetario, int prazoMeses)
        {
            return _calculoImpostoService.CalcularInvestimento(valorMonetario, prazoMeses);
        }
    }
}
