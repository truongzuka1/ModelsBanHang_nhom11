//using API.IService;
//using BlazorAdmin.Service.IService;
//using Data.Models;
//using System.Net.Http.Json;

//namespace BlazorAdmin.Service
//{
//    public class KichCoService : IKichCoService
//    {
//        private readonly HttpClient _httpClient;

//        public KichCoService(IHttpClientFactory httpClientFactory)
//        {
//            _httpClient = httpClientFactory.CreateClient("kichco");
//        }

//        public async Task<IEnumerable<KichCo>> GetAllAsync()
//        {
//            return await _httpClient.GetFromJsonAsync<IEnumerable<KichCo>>("api/KichCo")
//                   ?? new List<KichCo>();
//        }

//        public async Task<KichCo> GetByIdAsync(Guid id)
//        {
//            return await _httpClient.GetFromJsonAsync<KichCo>($"api/KichCo/{id}");
//        }

//        public async Task<KichCo> AddAsync(KichCo kichCo)
//        {
//            var response = await _httpClient.PostAsJsonAsync("api/KichCo", kichCo);
//            response.EnsureSuccessStatusCode();
//            return await response.Content.ReadFromJsonAsync<KichCo>();
//        }

//        public async Task<KichCo> UpdateAsync(KichCo kichCo)
//        {
//            var response = await _httpClient.PutAsJsonAsync($"api/KichCo/{kichCo.KichCoId}", kichCo);
//            response.EnsureSuccessStatusCode();
//            return await response.Content.ReadFromJsonAsync<KichCo>();
//        }

//        public async Task<bool> DeleteAsync(Guid id)
//        {
//            var response = await _httpClient.DeleteAsync($"api/KichCo/{id}");
//            response.EnsureSuccessStatusCode();
//            return true;
//        }

//        public async Task<bool> AddKichCoToGiayChiTiet(Guid giayChiTietId, Guid kichCoId)
//        {
//            var response = await _httpClient.PostAsync($"api/KichCo/{kichCoId}/giaychitiet/{giayChiTietId}", null);
//            response.EnsureSuccessStatusCode();
//            return true;
//        }

//        public async Task<bool> RemoveKichCoFromGiayChiTiet(Guid giayChiTietId, Guid kichCoId)
//        {
//            var response = await _httpClient.DeleteAsync($"api/KichCo/{kichCoId}/giaychitiet/{giayChiTietId}");
//            response.EnsureSuccessStatusCode();
//            return true;
//        }

//        public async Task<IEnumerable<KichCo>> GetKichCosByGiayIdAsync(Guid giayChiTietId)
//        {
//            return await _httpClient.GetFromJsonAsync<IEnumerable<KichCo>>($"api/KichCo/giaychitiet/{giayChiTietId}")
//                   ?? new List<KichCo>();
//        }
//    }
//}