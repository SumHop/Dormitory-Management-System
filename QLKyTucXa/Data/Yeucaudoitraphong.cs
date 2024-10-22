namespace QLKyTucXa.Data
{
    public class Yeucaudoitraphong
    {
        
            public string MaYeuCau { get; set; } = Guid.NewGuid().ToString();
            public string MaSinhVien { get; set; }

            public string MaPhongHienTai { get; set; }
            public virtual Phong PhongHienTai { get; set; } // Quan hệ 1-n với Phong

            public string? MaPhongMoi { get; set; }
            public virtual Phong? PhongMoi { get; set; } // Quan hệ 1-n với Phong (có thể null)

            public string TrangThai { get; set; } = "Đang chờ";
            public DateTime NgayYeuCau { get; set; } = DateTime.Now;
        public string? LyDoDoiPhong { get; set; } // Thêm lý do đổi phòng
        public string? LyDoTraPhong { get; set; } // Thêm lý do trả phòng

    }
}
