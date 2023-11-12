using PortalEkoPlay.Infra.Repository;

namespace PortalEkoPlay.Middlewares;

public static class DependenciesMiddleware
{
	public static void AddServicesDependencies(this IServiceCollection services, IConfiguration configuration)
	{
		//repositories
		services.AddScoped<INoticiaRepository, NoticiaRepository>();
		services.AddScoped<IContatoRepository, ContatoRepository>();
        
		services.AddScoped<ISugestaoRepository, SugestaoRepository>();

	}
}