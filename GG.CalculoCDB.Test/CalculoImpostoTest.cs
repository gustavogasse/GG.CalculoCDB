using AutoMapper;
using GG.CalculoCDB.Domain.Exceptions;
using GG.CalculoCDB.UI.Web.ViewModels;

namespace GG.CalculoCDB.Test
{
    public class CalculoImpostoTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ValorInicial_NaoPodeSerMenorOuIgualAZero(double valorInicial)
        {
            CalculoImposto c;
            Action act = () => c = new CalculoImposto(valorInicial);
            DomainException exception = Assert.Throws<DomainException>(act);
            Assert.Equal("Valor não pode ser menor ou igual a zero. Deve ser um valor positivo.", exception.Message);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void ValorInicial_DeveSerMaiorQueZero(double valorInicial)
        {
            CalculoImposto c = new CalculoImposto(valorInicial);
            Assert.Equal(valorInicial, c.GetValorInicial());
        }
    }
}