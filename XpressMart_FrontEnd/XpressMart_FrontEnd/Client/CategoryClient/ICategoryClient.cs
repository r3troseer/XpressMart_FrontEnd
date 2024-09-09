using XpressMart_FrontEnd.Models.Request.CategoryRequest;
using XpressMart_FrontEnd.Models.Response;
using XpressMart_FrontEnd.Models.Response.CategoryResponse;

namespace XpressMart_FrontEnd.Client.CategoryClient
{
    public interface ICategoryClient
    {
        Task<BaseResponse<List<CategoryResponseModel>>> GetCategoriesAsync();
        Task<BaseResponse<CategoryDetailResponseModel>> GetCategoryAsync(int categoryId);
        Task<BaseResponse> CreateCategoryAsync(CategoryRequestModel request);
    }
}
