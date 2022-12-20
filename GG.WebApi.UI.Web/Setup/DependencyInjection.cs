using GG.CalculoCDB.Domain.Repositories;
using GG.CalculoCDB.Domain.Services;
using GG.CalculoCDB.UI.Web.Services;

namespace GG.CalculoCDB.UI.Web.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Application Services
            services.AddScoped<CalculoImpostoService>();

            //Services
            services.AddScoped<ImpostoPercentualService>();

            //Repositories
            services.AddScoped<ImpostoPercentualRepository>();            
        }
    }
}
