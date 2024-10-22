using System.ComponentModel.DataAnnotations;

namespace QLKyTucXa.Controller.ViewContro
{
    public class LoginViewContro
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "Sai Tên đăng nhập")]
        public string? Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Sai Mật khẩu")]
        public string? Password { get; set; }
    }
}
