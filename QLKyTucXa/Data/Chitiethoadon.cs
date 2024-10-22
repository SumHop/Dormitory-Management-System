using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLKyTucXa.Data;

public partial class Chitiethoadon
{
    public string MaHd { get; set; } = null!;

    public string MaDv { get; set; } = null!;
    [Range(1, 100000, ErrorMessage = "phải nằm trong khoảng từ 1 đến 100000.")]
    public int? SoLuong { get; set; }
    [Range(1, 100000, ErrorMessage = "phải nằm trong khoảng từ 1 đến 100000.")]
    public int? ChiSoDau { get; set; }
    [Range(1, 100000, ErrorMessage = "phải nằm trong khoảng từ 1 đến 100000.")]
    public int? ChiSoCuoi { get; set; }

    public virtual Dichvu MaDvNavigation { get; set; } = null!;

    public virtual Hoadon MaHdNavigation { get; set; } = null!;
}
