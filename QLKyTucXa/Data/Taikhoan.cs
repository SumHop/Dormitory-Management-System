using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLKyTucXa.Data;

public partial class Taikhoan
{
    public string Iduser { get; set; } = null!;
    [Required(ErrorMessage = "Tên Đăng Nhập không được để trống.")]
    public string? TenDangNhap { get; set; }
    [Required(ErrorMessage = "Mật Khẩu không được để trống.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ cái thường, chữ cái hoa, chữ số và ký tự đặc biệt.")]
    public string? MatKhau { get; set; }
    [Required(ErrorMessage = "Email không được để trống.")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "không được để trống.")]
    [Compare(@"MatKhau", ErrorMessage = "Phải trùng với mật khẩu trên.")]
    public string? ConfirmPassword { get; set; }

    public bool? EmailDaXacMinh { get; set; }

    public string? VaiTro { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();

    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();

    public virtual ICollection<ThongBao> ThongBaos { get; set; } = new List<ThongBao>();
}
