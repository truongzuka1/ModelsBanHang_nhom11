using BlazorAdmin.Components.Pages;
using BlazorAdmin.Service.IService;
using Data.Models;

namespace BlazorAdmin.Service
{
    public class VoucherService : IVoucherService
    {
        private readonly HttpClient _httpClient;

        public VoucherService(HttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        public async Task Add(Voucher voucher)
        {
            await _httpClient.PostAsJsonAsync("/api/Voucher", voucher);
        }

        public async Task Delete(Guid id)
        {
            await _httpClient.DeleteAsync("/api/Voucher/" + id);
        }

        public async Task<List<Voucher>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Voucher>>("/api/Voucher");
        }

        public async Task<Voucher> GetById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Voucher>("/api/Voucher/" + id);
        }

        public async Task Update(Voucher voucher)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Voucher/{voucher.VoucherId}", voucher);
            response.EnsureSuccessStatusCode();
        }
    }
}
