using GG.CalculoCDB.Domain.Exceptions;
using GG.CalculoCDB.Domain.Extensions;

namespace GG.CalculoCDB.UI.Web.ViewModels
{
    public class CalculoImposto
    {
        private double ValorFinal { get; set; }
        private double ValorInicial { get; set; }
        private double CDI { get; set; }
        private double TB { get; set; }
        private double ValorRendimento { get; set; }

        public CalculoImposto(double valorInicial, double cDI = 0.9, double tB = 108)
        {
            if (valorInicial.IsValorNuloOuZero())
                throw new DomainException("Valor não pode ser menor ou igual a zero. Deve ser um valor positivo.");

            ValorInicial = valorInicial;            
            CDI = cDI;
            TB = tB;
        }

        public double GetValorFinal() => ValorFinal;
        public double GetValorInicial() => ValorInicial;        
        public double GetCDI() => CDI;
        public double GetTB() => TB;
        public double GetPercentual() => ((CDI * TB) / 100);
        public double GetValorRendimento() => CalculaRendimento();

        public void SetValorFinal(double valorFinal)
        {
            ValorFinal = valorFinal;
        }

        private double CalculaRendimento()
        {
            ValorRendimento = ValorFinal - ValorInicial;
            return ValorRendimento;
        }
    }
}
