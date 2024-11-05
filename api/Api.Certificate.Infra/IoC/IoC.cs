using Api.Certification.Infra.ApiSettings.AppSettings;
using Api.Certification.Infra.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.Certification.AppDomain.Interfaces;
using Microsoft.Extensions.Options;


namespace Api.Certification.Infra.IoC
{
    public static class IoC
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region APPSETTINGS
            services.Configure<TemplateConfig>(configuration.GetSection("TemplateConfig"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<TemplateConfig>>().Value);
            #endregion

            #region SERVICES
            services.AddTransient<IGenerateCertificateService, GenerateCertificateService>();
            #endregion

            #region MEDIATOR CONFIG
            var assembly = System.AppDomain.CurrentDomain.Load("Api.Certification.AppDomain");
            services.AddMediatR(ctg => ctg.RegisterServicesFromAssemblies(assembly));

            #endregion
        }
    }
}
