using GG.CalculoCDB.Domain.Exceptions;
using GG.CalculoCDB.Domain.Repositories;
using GG.CalculoCDB.Domain.Services;
using GG.CalculoCDB.UI.Web.Services;
using GG.CalculoCDB.UI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG.CalculoCDB.Test
{
    public class CalculoImpostoServiceTest
    {
        private ImpostoPercentualRepository _impostoPercentualRepository;
        private ImpostoPercentualService _impostoPercentualService;
        private CalculoImpostoService _calculoImpostoService;

        public CalculoImpostoServiceTest()
        {
            _impostoPercentualRepository = new ImpostoPercentualRepository();
            _impostoPercentualService = new ImpostoPercentualService(_impostoPercentualRepository);
            _calculoImpostoService = new CalculoImpostoService(_impostoPercentualService);
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(-1, 10)]
        public void ValorMonetario_NaoPodeSerMenorOuIgualAZero(double valorMonetario, int prazoMeses)
        {
            Action act = () => _calculoImpostoService.CalcularInvestimento(valorMonetario, prazoMeses);
            DomainException exception = Assert.Throws<DomainException>(act);
            Assert.Equal("Valor não pode ser menor ou igual a zero. Deve ser um valor positivo.", exception.Message);
        }

        [Theory]
        [InlineData(150000, 10)]
        [InlineData(300000, 20)]
        public void ValorMonetario_CalculoValoresLiquidoEBrutoDevemSerDiferentes(double valorMonetario, int prazoMeses)
        {
            var c = _calculoImpostoService.CalcularInvestimento(valorMonetario, prazoMeses);
            Assert.NotEqual(c.ValorLiquido, c.ValorBruto);
        }
    }
}
