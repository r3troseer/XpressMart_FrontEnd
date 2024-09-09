using XpressMart_FrontEnd.Client.ImageClient;
using XpressMart_FrontEnd.Models.Response.ProductResponse;

namespace XpressMart_FrontEnd.Services.ImageService
{
    public class ImageService : IImageService
    {
        private Dictionary<string, string> imageLoadingStatus = new Dictionary<string, string>();
        private Dictionary<string, string> imageLoadingErrors = new Dictionary<string, string>();
        private readonly IImageClient _imageClient;


        public ImageService(IImageClient imageClient)
        {
            _imageClient = imageClient;
        }

        public async Task FetchImage(ProductResponseModel product, Action onImageLoaded)
        {
            if (product.MainImageDetail != null && !string.IsNullOrEmpty(product.MainImageDetail.FileString))
            {
                imageLoadingStatus[product.Id] = "loaded";
                onImageLoaded?.Invoke();
                return;
            }

            try
            {
                Console.WriteLine($"Initiating image fetch for product {product.Id}");
                imageLoadingStatus[product.Id] = "loading";
                var imageDetails = await _imageClient.GetImage(product.MainImageFileId);
                if (imageDetails != null && imageDetails.Data != null && !string.IsNullOrEmpty(imageDetails.Data.FileString))
                {
                    product.MainImageDetail = imageDetails.Data;
                    imageLoadingStatus[product.Id] = "loaded";
                    Console.WriteLine($"Image for product {product.Id} loaded successfully");
                }
                else
                {
                    throw new Exception("Image data is null or empty");
                }
            }
            catch (Exception ex)
            {
                imageLoadingStatus[product.Id] = "error";
                imageLoadingErrors[product.Id] = ex.Message;
                Console.WriteLine($"Error fetching image for {product.Id}: {ex.Message}");
            }

            onImageLoaded?.Invoke();
            await Console.Out.WriteLineAsync("got here");
        }

        public string GetImageLoadingStatus(string productId)
        {
            return imageLoadingStatus.ContainsKey(productId) ? imageLoadingStatus[productId] : "not_started";
        }

        public string GetImageLoadingError(string productId)
        {
            return imageLoadingErrors.ContainsKey(productId) ? imageLoadingErrors[productId] : string.Empty;
        }

        public void ClearImageLoadingStatus()
        { imageLoadingStatus.Clear(); }
    }

}
