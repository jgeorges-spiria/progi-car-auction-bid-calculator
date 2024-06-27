using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;

namespace Tests.Integration.Resources
{
    public class TestApiFactory
    {
        private WebApplicationFactory<Program> Factory;


        public TestApiFactory()
        {
            Factory = new WebApplicationFactory<Program>();
        }

        public HttpClient CreateClient()
        {
            return Factory.CreateClient();
        }

        public HttpContent CreateRequestBody(object body)
        {
            HttpContent httpContent = new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(body, body.GetType()));
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return httpContent;
        }

        public async Task<T> CreateReponsePayload<T>(HttpResponseMessage responseMessage)
        {
            string json = await responseMessage.Content.ReadAsStringAsync();
            T? result = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (result == null)
            {
                throw new NullReferenceException("failed to deserialize response payload to specified type");
            }

            return result;
        }

        public void CleanUp()
        {
            Factory.Dispose();
        }
    }
}

