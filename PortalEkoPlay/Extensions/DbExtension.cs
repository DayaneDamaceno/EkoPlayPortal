

using Microsoft.EntityFrameworkCore;
using PortalEkoPlay.Infra;

namespace PortalEkoPlay.Extensions;

public static class DbExtension
{
	public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
	{
		
		services.AddDbContext<EkoPlayContext>(options =>
		{
			options.UseMySql(configuration.GetConnectionString("Default"), new MySqlServerVersion(new Version(8, 0, 26)));
			// options.UseNpgsql(configuration.GetConnectionString("Default"));
		});

	}
}