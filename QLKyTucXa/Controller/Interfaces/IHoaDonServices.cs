using QLKyTucXa.Components.Pages.Hopdong;
using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Interfaces
{
    public interface IHoaDonServices
    {
        Task AddHoaDonAsync(Hoadon hoadon);
        Task<List<Hoadon>> GetHoaDonByMaPhongAsync(string id);
        Task<Hoadon?> GetHoaDonnByIdAsync(string id);
        Task<List<Hoadon>> GetHoaDonAsync();
        Task DeleteHoaDonAsync(string id);
        Task UpdateHoaDonAsync(Hoadon hoadon);
        Task<Chitiethoadon?> GetChiTietHoaDonByIdAsync(string maHD, string maDV);
        Task DeleteChiTietHoaDonAsync(string maHD, string maDV);
        Task UpdateChiTietHoaDonAsync(Chitiethoadon chiTietHoaDon);
        Task<List<Chitiethoadon>> GetChiTietHoaDonByMaHDAsync(string maHD);
        Task AddChiTietHoaDonAsync(Chitiethoadon chiTietHoaDon);
        Task DeleteToanBoCTHDAsync(string maHD);
        Task<List<Hoadon>> GetHoaDonByTrangThaiAsync();
        Task<List<Hoadon>> GetHoaDonThongThuongAsync();
        Task<List<Hoadon>> GetHoaDonByDaThanhToanAsync();
        Task<List<Chitiethoadon>> GetCTHDAsync();
    }
}