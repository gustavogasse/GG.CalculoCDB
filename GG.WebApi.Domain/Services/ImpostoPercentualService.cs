using GG.CalculoCDB.Domain.Repositories;

namespace GG.CalculoCDB.Domain.Services
{
    public class ImpostoPercentualService
    {
        private readonly ImpostoPercentualRepository _impostoPercentualRepository;

        public ImpostoPercentualService(ImpostoPercentualRepository impostoPercentualRepository)
        {
            _impostoPercentualRepository = impostoPercentualRepository;
        }

        public double GetTaxa(int periodoMeses)
        {
            return _impostoPercentualRepository.GetTaxa(periodoMeses);
        }
    }
}
