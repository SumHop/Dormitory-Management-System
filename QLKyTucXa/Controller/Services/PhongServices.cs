using Microsoft.EntityFrameworkCore;
using QLKyTucXa.Controller.Interfaces;
using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Services
{
    public class PhongServices : IPhongServices
    {
        private readonly DataQlktxContext _qlktxContext;
        public PhongServices(DataQlktxContext qlktxContext)
        {
            _qlktxContext = qlktxContext;
        }
        //thêm danh sách phòng 
        public async Task AddPhongAsync(Phong phong)
        {
            _qlktxContext.Phongs.Add(phong);
            await _qlktxContext.SaveChangesAsync();
        }
        //xóa phòng
        public async Task DeletePhongAsync(string id)
        {
            var pho = await GetPhongByIdAsync(id);
            if (pho != null)
            {
                _qlktxContext.Remove(pho);
                await _qlktxContext.SaveChangesAsync();
            }
        }
        //lấy danh sách phòng 
        public async Task<List<Phong>> GetPhongAsync()
        {
            var pho = await _qlktxContext.Phongs.ToListAsync();
            return pho;
        }
        //lấy phòng bằng id
        public async Task<Phong?> GetPhongByIdAsync(string id)
        {
            var pho = await _qlktxContext.Phongs.FirstOrDefaultAsync(e => e.MaPhong == id);
            return pho;
        }
        //cập nhật phòng 
        public async Task UpdatePhongAsync(Phong phong)
        {
            _qlktxContext.Entry(phong).State = EntityState.Modified;
            await _qlktxContext.SaveChangesAsync();
        }

        // Kiểm tra số giường có bằng số người ở không
        public async Task<bool> IsSoGiuongEqualSoNguoiOAsync(string id)
        {
            var phong = await GetPhongByIdAsync(id);
            if (phong != null)
            {
                return phong.SoGiuong == phong.SoNguoiO;
            }
            return false; // Phòng không tồn tại
        }
        public async Task<List<Phong>> GetAvailableRoomsAsync(string currentRoomId)
        {
            // Fetch all rooms that are not currently occupied (SoNguoiO == 0) and not the current room
            var availableRooms = await _qlktxContext.Phongs
                .Where(r => r.SoNguoiO == 0 && r.MaPhong != currentRoomId)
                .ToListAsync();
            return availableRooms;
        }

    }
}
