namespace GG.CalculoCDB.UI.Web.ViewModels
{
    public class ResultadoInvestimento
    {
        public double ValorBruto { get; set; }
        public double ValorLiquido { get; set; }

        public ResultadoInvestimento(double valorBruto, double valorLiquido)
        {
            ValorBruto = valorBruto;
            ValorLiquido = valorLiquido;
        }
    }
}
