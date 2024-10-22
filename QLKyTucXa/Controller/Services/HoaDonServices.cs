using Microsoft.EntityFrameworkCore;
using QLKyTucXa.Controller.Interfaces;
using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Services
{
    public class HoaDonServices : IHoaDonServices
    {
        private readonly DataQlktxContext _dataQlktxContext;
        public HoaDonServices(DataQlktxContext dataQlktxContext)
        {
            _dataQlktxContext = dataQlktxContext;
        }
        //lấy danh sách hóa đơn bằng mã phòng 
        public async Task<List<Hoadon>> GetHoaDonByMaPhongAsync(string id)
        {
            var pho = await _dataQlktxContext.Hoadons
                .Where(t => t.MaPhong == id)
                .ToListAsync();
            return pho;
        }
        // thêm háo đơn
        public async Task AddHoaDonAsync(Hoadon hoadon)
        {
            _dataQlktxContext.Hoadons.Add(hoadon);
            await _dataQlktxContext.SaveChangesAsync();
        }
        // lấy hóa đơn bằng id 
        public async Task<Hoadon?> GetHoaDonnByIdAsync(string id)
        {
            var hoadon = await _dataQlktxContext.Hoadons.FirstOrDefaultAsync(e => e.MaHd == id);
            return hoadon;
        }
        // lấy danh sách hóa đơn
        public async Task<List<Hoadon>> GetHoaDonAsync()
        {
            var hoadon = await _dataQlktxContext.Hoadons.ToListAsync();
            return hoadon;
        }
        // xóa danh sách háo đơn 
        public async Task DeleteHoaDonAsync(string id)
        {
            var pho = await GetHoaDonnByIdAsync(id);
            if (pho != null)
            {
                _dataQlktxContext.Remove(pho);
                await _dataQlktxContext.SaveChangesAsync();
            }
        }
        // cập nhật hóa đơn 
        public async Task UpdateHoaDonAsync(Hoadon hoadon)
        {
            _dataQlktxContext.Entry(hoadon).State = EntityState.Modified;
            await _dataQlktxContext.SaveChangesAsync();
        }
        //
        public async Task<List<Hoadon>> GetHoaDonByTrangThaiAsync()
        {
            var result = await _dataQlktxContext.Hoadons
                                    .Where(e => e.TrangThai == "Đang thanh toán" && e.MaPhong != null)
                                    .ToListAsync();
            return result;
        }

        public async Task<List<Hoadon>> GetHoaDonByDaThanhToanAsync()
        {
            var result = await _dataQlktxContext.Hoadons
                                    .Where(e => e.TrangThai == "Đã thanh toán" && e.MaPhong != null)
                                    .ToListAsync();
            return result;
        }

        public async Task<List<Hoadon>> GetHoaDonThongThuongAsync()
        {
            var result = await _dataQlktxContext.Hoadons
                                    .Where(e => e.TrangThai == "Đang thanh toán" && e.MaPhong == null)
                                    .ToListAsync();
            return result;
        }

        //CTHD

        public async Task<List<Chitiethoadon>> GetCTHDAsync()
        {
            var cthd = await _dataQlktxContext.Chitiethoadons.ToListAsync();
            return cthd;
        }
        public async Task<Chitiethoadon?> GetChiTietHoaDonByIdAsync(string maHD, string maDV)
        {
            return await _dataQlktxContext.Chitiethoadons
             .FirstOrDefaultAsync(ct => ct.MaHd == maHD && ct.MaDv == maDV);
        }

        public async Task DeleteChiTietHoaDonAsync(string maHD, string maDV)
        {
            var chiTietHoaDon = await GetChiTietHoaDonByIdAsync(maHD, maDV);
            if (chiTietHoaDon != null)
            {
                _dataQlktxContext.Chitiethoadons.Remove(chiTietHoaDon);
                await _dataQlktxContext.SaveChangesAsync();
            }
        }

        public async Task DeleteToanBoCTHDAsync(string maHD)
        {
            var chiTietHoaDon = await GetChiTietHoaDonByMaHDAsync(maHD);
            if (chiTietHoaDon != null)
            {
                _dataQlktxContext.Chitiethoadons.RemoveRange(chiTietHoaDon);
                await _dataQlktxContext.SaveChangesAsync();
            }
        }

        public async Task UpdateChiTietHoaDonAsync(Chitiethoadon chiTietHoaDon)
        {
            _dataQlktxContext.Entry(chiTietHoaDon).State = EntityState.Modified;
            await _dataQlktxContext.SaveChangesAsync();
        }

        public async Task<List<Chitiethoadon>> GetChiTietHoaDonByMaHDAsync(string maHD)
        {
            return await _dataQlktxContext.Chitiethoadons
            .Where(ct => ct.MaHd == maHD)
            .ToListAsync();
        }

        public async Task AddChiTietHoaDonAsync(Chitiethoadon chiTietHoaDon)
        {
            _dataQlktxContext.Chitiethoadons.Add(chiTietHoaDon);
            await _dataQlktxContext.SaveChangesAsync();
        }
    }
}
