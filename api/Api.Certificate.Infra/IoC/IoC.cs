using Microsoft.Extensions.DependencyInjection;


namespace Api.Certificate.Infra.IoC
{
    public static class IoC
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            var assembly = System.AppDomain.CurrentDomain.Load("Api.Certification.AppDomain");
            services.AddMediatR(ctg => ctg.RegisterServicesFromAssemblies(assembly));
        }
    }
}
