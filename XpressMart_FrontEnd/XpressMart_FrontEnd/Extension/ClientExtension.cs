using XpressMart_FrontEnd.Client.CategoryClient;
using XpressMart_FrontEnd.Client.ImageClient;
using XpressMart_FrontEnd.Client.ProductClient;

namespace XpressMart_FrontEnd.Extension
{
	public static class ClientExtension
	{
		public static IServiceCollection AddClients(this IServiceCollection services)
		{
			services.AddScoped<ICategoryClient, CategoryClient>();
			services.AddScoped<IImageClient, ImageClient>();
			services.AddScoped<IProductClient, ProductClient>();

			return services;
		}
	}
}
