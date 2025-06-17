using System.Net.Http.Json;
using API.Models.DTO;

public class DeGiayService : IDeGiayService
{
    private readonly HttpClient _httpClient;

    public DeGiayService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DeGiayDTO>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<DeGiayDTO>>("api/DeGiays");
    }

    public async Task<DeGiayDTO> GetByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<DeGiayDTO>($"api/DeGiays/{id}");
    }

    public async Task<bool> CreateAsync(DeGiayDTO obj)
    {
        var response = await _httpClient.PostAsJsonAsync("api/DeGiays", obj);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(DeGiayDTO obj)
    {
        var response = await _httpClient.PutAsJsonAsync("api/DeGiays", obj);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/DeGiays/{id}"); // ✅ Sửa lỗi ở đây
        return response.IsSuccessStatusCode;
    }
}
