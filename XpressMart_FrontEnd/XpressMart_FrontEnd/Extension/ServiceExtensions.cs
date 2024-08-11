using XpressMart_FrontEnd.Services.FilterService;
using XpressMart_FrontEnd.Services.ImageService;

namespace XpressMart_FrontEnd.Extension
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IFilterService, FilterService>();
			services.AddScoped<IImageService, ImageService>();

			return services;
		}
	}
}
