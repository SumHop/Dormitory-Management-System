using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLKyTucXa.Data;

public partial class Dichvu
{
    public string MaDv { get; set; } = null!;

    public string? TenDichVuBatBuoc { get; set; }

    public double? DonGia { get; set; }

    public string? Dvt { get; set; }

    public string? LoaiDichVu { get; set; }

    public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; } = new List<Chitiethoadon>();
}
