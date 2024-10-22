using System;
using System.Collections.Generic;

namespace QLKyTucXa.Data;

public partial class Phong
{
    public string MaPhong { get; set; } = null!;

    public string? TenPhong { get; set; }

    public string? Khu { get; set; }

    public string? Tang { get; set; }

    public int? SoGiuong { get; set; }

    public int? SoNguoiO { get; set; }

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();
    public virtual ICollection<Yeucaudoitraphong> YeuCauDoiTraPhongs { get; set; }
    public virtual ICollection<Hopdong> Hopdongs { get; set; } = new List<Hopdong>();
}
