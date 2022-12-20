using GG.CalculoCDB.Domain.Entities;

namespace GG.CalculoCDB.Domain.Repositories
{
    public class ImpostoPercentualRepository
    {
        private List<ImpostoPercentual> _impostoPercentuals { get; set; }

        public ImpostoPercentualRepository()
        {
            _impostoPercentuals = IniciarTabela();
        }

        private static List<ImpostoPercentual> IniciarTabela()
        {
            return new List<ImpostoPercentual>()
            {
                new ImpostoPercentual(6, 22.5),
                new ImpostoPercentual(12, 20),
                new ImpostoPercentual(24, 17.5),
                new ImpostoPercentual(25, 15)
            };
        }

        public double GetTaxa(int periodoMeses)
        {
            int periodoSelecionado = 0;
            if (_impostoPercentuals.Any(t => t.GetMeses() >= periodoMeses))
            {
                periodoSelecionado = _impostoPercentuals.Where(t => t.GetMeses() >= periodoMeses).Select(t => t.GetMeses()).Min();
            }
            else
            {
                periodoSelecionado = _impostoPercentuals.Select(t => t.GetMeses()).Max();
            }
            return _impostoPercentuals.Where(t => t.GetMeses() == periodoSelecionado).Select(t => t.GetPercentual()).FirstOrDefault();
        }
    }
}
