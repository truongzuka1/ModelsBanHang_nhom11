using BlazorAdmin.Service.IService;
using Data.Models;

namespace BlazorAdmin.Service
{
    public class ChatLieuService : IChatLieuService
    {
        private readonly HttpClient _httpClient;

        public ChatLieuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ChatLieu>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ChatLieu>>("/api/ChatLieus");
        }

        public async Task<ChatLieu> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ChatLieu>($"/api/ChatLieus/{id}");
        }

        public async Task CreateAsync(ChatLieu obj)
        {
            await _httpClient.PostAsJsonAsync("/api/ChatLieus", obj);
        }

        public async Task UpdateAsync(ChatLieu obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/ChatLieus/{obj.ChatLieuId}", obj);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/api/ChatLieus/{id}");
        }
    }
}
