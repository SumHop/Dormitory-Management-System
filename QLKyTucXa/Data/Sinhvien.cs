using System;
using System.Collections.Generic;

namespace QLKyTucXa.Data;

public partial class Sinhvien
{
    public string Mssv { get; set; } = null!;

    public string? TenSinhVien { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? Lop { get; set; }

    public string? Khoa { get; set; }

    public string? SoCccd { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public string? Iduser { get; set; }

    public virtual ICollection<Hopdong> Hopdongs { get; set; } = new List<Hopdong>();

    public virtual Taikhoan? IduserNavigation { get; set; }

    public virtual ICollection<Phuhuynh> Phuhuynhs { get; set; } = new List<Phuhuynh>();
}
