using XpressMart_FrontEnd.Services.FilterService;
using XpressMart_FrontEnd.Services.ImageService;
using XpressMart_FrontEnd.Services.JavaScriptService.Alerts;

namespace XpressMart_FrontEnd.Extension
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IFilterService, FilterService>();
			services.AddScoped<IImageService, ImageService>();
			services.AddScoped<ToastrService>();


			//services.AddScoped<>();

			return services;
		}
	}
}
