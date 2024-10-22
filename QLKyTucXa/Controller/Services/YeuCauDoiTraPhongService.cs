using QLKyTucXa.Data;
using Microsoft.EntityFrameworkCore;
using QLKyTucXa.Controller.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLKyTucXa.Controller.Services
{
    public class YeuCauDoiTraPhongService : IYeuCauDoiTraPhongService
    {
        private readonly DataQlktxContext _context;

        public YeuCauDoiTraPhongService(DataQlktxContext context)
        {
            _context = context;
        }

        // Thêm mới yêu cầu đổi phòng
        public async Task<bool> SubmitRequestAsync(Yeucaudoitraphong yeucau)
        {
            try
            {
                // Kiểm tra xem phòng hiện tại và phòng mới có giống nhau không
                if (yeucau.MaPhongHienTai == yeucau.MaPhongMoi)
                {
                    throw new ArgumentException("Phòng hiện tại và phòng mới không được giống nhau.");
                }

                // Thêm đối tượng vào DbSet
                _context.YeuCauDoiTraPhongs.Add(yeucau);

                // Lưu các thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();

                return true; // Trả về true khi lưu thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine($"Lỗi khi thêm yêu cầu đổi phòng: {ex.Message}");
                return false; // Trả về false khi lưu thất bại
            }
        }

        // Lấy danh sách tất cả yêu cầu đổi phòng
        public async Task<List<Yeucaudoitraphong>> GetRequestsAsync()
        {
            try
            {
                return await _context.YeuCauDoiTraPhongs
                    .Include(r => r.PhongHienTai) // Lấy thông tin phòng hiện tại
                    .Include(r => r.PhongMoi) // Lấy thông tin phòng mới
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log hoặc xử lý lỗi (consider using a logging framework)
                Console.WriteLine($"Lỗi khi lấy danh sách yêu cầu: {ex.Message}");
                return new List<Yeucaudoitraphong>(); // Trả về danh sách rỗng để tránh lỗi null reference
            }
        }

        // Cập nhật yêu cầu đổi phòng
        public async Task<bool> UpdateRequestAsync(Yeucaudoitraphong request)
        {
            var existingRequest = await _context.YeuCauDoiTraPhongs.FindAsync(request.MaYeuCau);

            if (existingRequest != null)
            {
                existingRequest.TrangThai = request.TrangThai; // Update status
                _context.Entry(existingRequest).State = EntityState.Modified; // Mark as modified
                int result = await _context.SaveChangesAsync(); // Save changes to the database
                return result > 0;
            }
            return false;
        }


        public async Task<List<Yeucaudoitraphong>> GetRequestHistoryAsync()
        {
            return await _context.YeuCauDoiTraPhongs
                .Where(r => r.TrangThai != "Đang chờ") // Filter out pending requests
                .ToListAsync();
        }
        public async Task<List<Yeucaudoitraphong>> GetRoomChangeRequestsAsync()
        {
            // Fetch room change requests and include related room (PhongHienTai and PhongMoi)
            return await _context.YeuCauDoiTraPhongs
                                   .Include(r => r.PhongHienTai) // Eager loading of PhongHienTai
                                   .Include(r => r.PhongMoi) // Eager loading of PhongMoi
                                   .Where(r => r.LyDoDoiPhong != null)
                                   .ToListAsync();
        }

        public async Task<List<Yeucaudoitraphong>> GetRoomReturnRequestsAsync()
        {
            // Fetch room return requests and include related room (PhongHienTai)
            return await _context.YeuCauDoiTraPhongs
                                   .Include(r => r.PhongHienTai) // Eager loading of PhongHienTai
                                   .Where(r => r.LyDoTraPhong != null)
                                   .ToListAsync();
        }


    }
}
