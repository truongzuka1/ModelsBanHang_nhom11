using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải dài từ 6 đến 100 ký tự")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
