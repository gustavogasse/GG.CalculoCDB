namespace GG.CalculoCDB.UI.Web.ViewModels
{
    public class ResgateAplicacao
    {
        public double ValorMonetario { get; set; }
        public int PrazoMeses { get; set; }

        public ResgateAplicacao(double valorMonetario, int prazoMeses)
        {
            ValorMonetario = valorMonetario;
            PrazoMeses = prazoMeses;
        }
    }
}
