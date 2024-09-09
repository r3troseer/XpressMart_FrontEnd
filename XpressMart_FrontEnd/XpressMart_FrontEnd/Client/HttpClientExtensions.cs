using System.Collections;
using System.Net.Http.Headers;

namespace XpressMart_FrontEnd.Client
{

    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostAsMultipartAsync<T>(this HttpClient httpClient, string url, T request) where T : class
        {
            using var content = new MultipartFormDataContent();

            await AddPropertiesAsync(content, request);

            return await httpClient.PostAsync(url, content);
        }

        private static async Task AddPropertiesAsync<T>(MultipartFormDataContent content, T request, string prefix = null) where T : class
        {
            var type = request.GetType();

            var props = type.GetProperties();

            foreach (var property in props)
            {
                var value = property.GetValue(request);
                var propertyName = string.IsNullOrEmpty(prefix) ? property.Name : $"{prefix}.{property.Name}";

                if (value != null)
                {
                    if (value is IFormFile formFile)
                    {
                        try
                        {
                            var fileContent = new StreamContent(formFile.OpenReadStream());
                            fileContent.Headers.ContentType = new MediaTypeHeaderValue(formFile.ContentType);
                            content.Add(fileContent, propertyName, formFile.FileName);
                        }
                        catch (Exception ex)
                        {
                            await Console.Out.WriteLineAsync(ex.Message);
                        }
                    }
                    else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
                    {
                        var index = 0;
                        foreach (var item in (IEnumerable)value)
                        {
                            await AddPropertiesAsync(content, item, $"{propertyName}[{index++}]");
                        }
                    }
                    else if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                    {
                        await AddPropertiesAsync(content, value, propertyName);
                    }
                    else
                    {
                        content.Add(new StringContent(value.ToString()), propertyName);
                    }
                }
            }
        }

    }
}
