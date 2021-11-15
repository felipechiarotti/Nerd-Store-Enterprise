using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Contratos;


namespace NSE.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
        }
    }
}
