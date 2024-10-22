using System;
using System.Collections.Generic;

namespace QLKyTucXa.Data;

public partial class Nhanvien
{
    public string IdnhanVien { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public string? ChucVu { get; set; }

    public string? TinhTrang { get; set; }

    public string? Iduser { get; set; }

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();

    public virtual ICollection<Hopdong> Hopdongs { get; set; } = new List<Hopdong>();

    public virtual Taikhoan? IduserNavigation { get; set; }
}
