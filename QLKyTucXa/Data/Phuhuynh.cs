using System;
using System.Collections.Generic;

namespace QLKyTucXa.Data;

public partial class Phuhuynh
{
    public string IdphuHuynh { get; set; } = null!;

    public string? HoTen { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? NgheNghiep { get; set; }

    public string? Sdt { get; set; }

    public string? QuanHe { get; set; }

    public string? Mssv { get; set; }

    public virtual Sinhvien? MssvNavigation { get; set; }
}
