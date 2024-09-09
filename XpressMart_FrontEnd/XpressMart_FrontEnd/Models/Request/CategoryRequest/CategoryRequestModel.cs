using XpressMart_FrontEnd.Models.Request.CloudinaryRequest;

namespace XpressMart_FrontEnd.Models.Request.CategoryRequest
{
    public class CategoryRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CloudinaryRequestModel Thumbnail { get; set; }

    }
}
