using XpressMart_FrontEnd.Models.Request.BrandRequest;
using XpressMart_FrontEnd.Models.Response;
using XpressMart_FrontEnd.Models.Response.BrandResponse;

namespace XpressMart_FrontEnd.Client.BrandClient
{
    public interface IBrandClient
    {
        Task<BaseResponse<List<BrandResponseModel>>> GetBrandsAsync();
        Task<BaseResponse<BrandResponseModel>> GetBrandAsync(string brandId);
        Task<BaseResponse> CreateBrandAsync(BrandRequestModel request);
    }
}
