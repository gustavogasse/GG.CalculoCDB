using GG.CalculoCDB.Domain.DomainObjects;

namespace GG.CalculoCDB.Domain.Entities
{
    public class ImpostoPercentual : Entity
    {
        private int Meses { get; set; }
        private double Percentual { get; set; }

        public ImpostoPercentual(int meses, double percentual)
        {
            Meses = meses;
            Percentual = percentual;
        }

        public int GetMeses() => Meses;
        public double GetPercentual() => Percentual;
    }
}
