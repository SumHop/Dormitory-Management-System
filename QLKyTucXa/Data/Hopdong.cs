using System;
using System.Collections.Generic;

namespace QLKyTucXa.Data;

public partial class Hopdong
{
    public string SoHopDong { get; set; } = null!;

    public DateOnly? NgayLap { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianKetThuc { get; set; }

    public string? TrangThai { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public string? IdnhanVien { get; set; }

    public string? Mssv { get; set; }

    public string? MaPhong { get; set; }

    public virtual Nhanvien? IdnhanVienNavigation { get; set; }

    public virtual Phong? MaPhongNavigation { get; set; }

    public virtual Sinhvien? MssvNavigation { get; set; }
}
