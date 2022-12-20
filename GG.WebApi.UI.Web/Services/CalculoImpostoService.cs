using GG.CalculoCDB.Domain.Extensions;
using GG.CalculoCDB.Domain.Services;
using GG.CalculoCDB.UI.Web.ViewModels;

namespace GG.CalculoCDB.UI.Web.Services
{
    public class CalculoImpostoService
    {
        private ImpostoPercentualService _impostoPercentualService;        

        public CalculoImpostoService(ImpostoPercentualService impostoPercentualService)
        {
            _impostoPercentualService = impostoPercentualService;
        }

        public ResultadoInvestimento CalcularInvestimento(double valorMonetario, int prazoMeses)
        {
            var resgate = new ResgateAplicacao(valorMonetario, prazoMeses);
            var _calculoImposto = new CalculoImposto(resgate.ValorMonetario);

            for (int i = 0; i < resgate.PrazoMeses; i++)
            {
                if (_calculoImposto.GetValorFinal().IsValorNuloOuZero())
                {
                    _calculoImposto.SetValorFinal(resgate.ValorMonetario);
                }

                double valorCalculado = _calculoImposto.GetValorFinal() + ((_calculoImposto.GetValorFinal() * _calculoImposto.GetPercentual()) / 100);
                _calculoImposto.SetValorFinal(valorCalculado);
            }

            double percentualImposto = _impostoPercentualService.GetTaxa(resgate.PrazoMeses);

            var valorBruto = _calculoImposto.GetValorFinal();
            var valorLiquido = _calculoImposto.GetValorFinal() - ((_calculoImposto.GetValorRendimento() * percentualImposto) / 100);

            return new ResultadoInvestimento(valorBruto, valorLiquido);
        }
    }
}
