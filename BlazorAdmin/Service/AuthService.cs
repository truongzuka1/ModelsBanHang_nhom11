

using API.Models.DTO;

namespace BlazorAdmin.Service
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponseDto> Login(LoginModel loginModel)
        {
            try
            {
 
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginModel);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
                    return result;
                }
                else
                {

                    var errorContent = await response.Content.ReadAsStringAsync();
                    return new LoginResponseDto
                    {
                        IsSuccess = false,
                        Message = $"Login failed: {response.StatusCode} - {errorContent}"
                    };
                }
            }
            catch (HttpRequestException ex)
            {

                return new LoginResponseDto
                {
                    IsSuccess = false,
                    Message = $"Network error during login: {ex.Message}"
                };
            }
            catch (Exception ex)
            {

                return new LoginResponseDto
                {
                    IsSuccess = false,
                    Message = $"An unexpected error occurred: {ex.Message}"
                };
            }
        }
    }
}
