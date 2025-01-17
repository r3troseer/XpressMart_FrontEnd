﻿using XpressMart_FrontEnd.Models.Request.CategoryRequest;
using XpressMart_FrontEnd.Models.Response;
using XpressMart_FrontEnd.Models.Response.CategoryResponse;

namespace XpressMart_FrontEnd.Client.CategoryClient
{
    public class CategoryClient : ICategoryClient
    {
        private readonly HttpClient httpClient;

        public CategoryClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<BaseResponse> CreateCategoryAsync(CategoryRequestModel request)
        {
            var response = await httpClient.PostAsMultipartAsync("api/Categories", request);

            return await response.Content.ReadFromJsonAsync<BaseResponse>();
        }

        public async Task<BaseResponse<List<CategoryResponseModel>>> GetCategoriesAsync()
            => await httpClient.GetFromJsonAsync<BaseResponse<List<CategoryResponseModel>>>("api/Categories");

        public async Task<BaseResponse<CategoryDetailResponseModel>> GetCategoryAsync(int categoryId)
            => await httpClient.GetFromJsonAsync<BaseResponse<CategoryDetailResponseModel>>($"api/Categories/{categoryId}");

    }
}
