using Microsoft.EntityFrameworkCore;
using QLKyTucXa.Controller.Interfaces;
using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Services
{
    public class SinhVienServices : ISinhVienServices
    {
        private readonly DataQlktxContext _context;
        public SinhVienServices(DataQlktxContext context)
        {
            _context = context;
        }

        //thêm sinh vien
        public async Task Addsinhviensync(Sinhvien sv)
        {
            _context.Sinhviens.Add(sv);
            await _context.SaveChangesAsync();
        }

        // xóa sinh viên thông qua ID
        public async Task DeleteByIdAsync(string id)
        {
            var sv = await GetByIdAsync(id);
            if (sv != null)
            {
                _context.Remove(sv);
                await _context.SaveChangesAsync();
            }
        }

        //Lấy bằng iD
        public async Task<Sinhvien?> GetByIdAsync(string id)
        {
            var sv = await _context.Sinhviens.FirstOrDefaultAsync(e => e.Mssv == id);
            return sv;
        }

        public async Task<Sinhvien?> GetByIdUserAsync(string id)
        {
            var sv = await _context.Sinhviens.FirstOrDefaultAsync(e => e.Iduser == id);
            return sv;
        }

        //Lấy danh sách sinh viên
        public async Task<List<Sinhvien>> laydssinhvien()
        {
            var sv = await _context.Sinhviens.ToListAsync();
            return sv;
        }

        //cập nhật sinh viên
        public async Task UpdateAsync(Sinhvien sv)
        {
            _context.Entry(sv).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<List<Sinhvien>> GetSinhVienByPhongAsync(string maPhong)
        {
            return await _context.Hopdongs
                .Where(hd => hd.MaPhong == maPhong) // Filter by room in Hopdong
                .Select(hd => hd.MssvNavigation) // Get associated students through MssvNavigation
                .ToListAsync();
        }


    }
}
