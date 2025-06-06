using BlazorAdmin.Service.IService;
using API.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;
using API.IService;

namespace BlazorAdmin.Service
{
    public class AnhService : IAnhService
    {
        private readonly HttpClient _httpClient;

        public AnhService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("anh");
        }

        public async Task<List<Anh>> GetAllAsync() =>
            await _httpClient.GetFromJsonAsync<List<Anh>>("api/Anh");

        public async Task<Anh> GetByIdAsync(Guid id) =>
            await _httpClient.GetFromJsonAsync<Anh>($"api/Anh/{id}");

        public async Task<Anh> UploadAsync(IBrowserFile file, string tenAnh)
        {
            var content = new MultipartFormDataContent();
            var streamContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024));
            streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
            content.Add(streamContent, "file", file.Name);
            content.Add(new StringContent(tenAnh ?? ""), "tenAnh");

            var response = await _httpClient.PostAsync("api/Anh/upload", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Anh>();
        }

        public async Task<Anh> UpdateAsync(Anh anh)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Anh/{anh.AnhId}", anh);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Anh>();
        }

        public async Task<Anh> UpdateFileAsync(Guid id, IBrowserFile file, string tenAnh)
        {
            var content = new MultipartFormDataContent();
            var streamContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024));
            streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
            content.Add(streamContent, "file", file.Name);
            content.Add(new StringContent(tenAnh ?? ""), "tenAnh");

            var response = await _httpClient.PutAsync($"api/Anh/update-file/{id}", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Anh>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/Anh/{id}");
            response.EnsureSuccessStatusCode();
            return true;
        }

        
    }
}