using BlazorAdmin.Service.IService;
using Data.Models;

namespace BlazorAdmin.Service
{
    public class VoucherServiceRepo : IVoucherService
    {
        private readonly HttpClient _httpClient;

        public VoucherServiceRepo(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("voucher");
        }

        public async Task<List<Voucher>> GetAll() =>
            await _httpClient.GetFromJsonAsync<List<Voucher>>("api/Vouchers");

        public async Task<Voucher> GetById(Guid id) =>
            await _httpClient.GetFromJsonAsync<Voucher>($"api/Vouchers/{id}");

        public async Task Add(Voucher voucher)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Vouchers", voucher);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(Voucher voucher)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Vouchers/{voucher.VoucherId}", voucher);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/Vouchers/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
