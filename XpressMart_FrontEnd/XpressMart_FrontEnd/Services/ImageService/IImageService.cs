using XpressMart_FrontEnd.Models.Response.ProductResponse;

namespace XpressMart_FrontEnd.Services.ImageService
{
	public interface IImageService
	{
		Task FetchImage(ProductResponseModel product, Action onImageLoaded);
		string GetImageLoadingStatus(string productId);
		string GetImageLoadingError(string productId);
		void ClearImageLoadingStatus();
	}

}
