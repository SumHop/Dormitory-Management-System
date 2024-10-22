using System;
using System.Collections.Generic;

namespace QLKyTucXa.Data
{
    public partial class ThongBao
    {
        // Mã thông báo
        public string MaThongBao { get; set; } = null!;

        // Nội dung thông báo
        public string? NoiDung { get; set; }

        // Thời gian thông báo
        public DateTime? ThoiGianThongBao { get; set; }

        // Trạng thái thông báo (đã xử lý hay chưa)
        public bool? TrangThaiThongBao { get; set; }

        // Loại thông báo
        public string? LoaiThongBao { get; set; }

        // ID người dùng liên kết
        public string? Iduser { get; set; }

        // Danh sách hình ảnh liên quan
        public List<string>? HinhAnh { get; set; } // Thay đổi để hỗ trợ nhiều hình ảnh

        // Tham chiếu đến tài khoản người dùng
        public virtual Taikhoan? IduserNavigation { get; set; }

        // Constructor mặc định
        public ThongBao()
        {
            HinhAnh = new List<string>();
        }

        // Constructor với tham số (nếu cần thiết)
        public ThongBao(string maThongBao, string? noiDung, DateTime? thoiGianThongBao, bool? trangThaiThongBao, string? loaiThongBao, string? iduser)
        {
            MaThongBao = maThongBao;
            NoiDung = noiDung;
            ThoiGianThongBao = thoiGianThongBao;
            TrangThaiThongBao = trangThaiThongBao;
            LoaiThongBao = loaiThongBao;
            Iduser = iduser;
            HinhAnh = new List<string>();
        }

        // Phương thức thêm hình ảnh
        public void AddHinhAnh(string hinhAnh)
        {
            if (!string.IsNullOrWhiteSpace(hinhAnh))
            {
                HinhAnh?.Add(hinhAnh);
            }
        }
    }
}
