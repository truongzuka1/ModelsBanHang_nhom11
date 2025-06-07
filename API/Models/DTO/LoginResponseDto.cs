namespace API.Models.DTO
{
    public class LoginResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Username { get; set; }
        public string Role { get; set; } 
        public string Message { get; set; }
    }
}
