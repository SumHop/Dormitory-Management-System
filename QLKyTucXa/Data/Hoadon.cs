using System;
using System.Collections.Generic;

namespace QLKyTucXa.Data;

public partial class Hoadon
{
    public string MaHd { get; set; } = null!;

    public DateOnly? NgayLapHd { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public string? TrangThai { get; set; }

    public string? MaPhong { get; set; }

    public string? IdnhanVien { get; set; }

    public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; } = new List<Chitiethoadon>();

    public virtual Nhanvien? IdnhanVienNavigation { get; set; }

    public virtual Phong? MaPhongNavigation { get; set; }
}
