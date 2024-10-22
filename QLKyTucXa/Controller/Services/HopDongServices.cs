using Microsoft.EntityFrameworkCore;
using QLKyTucXa.Controller.Interfaces;
using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Services
{
    public class HopDongServices : IHopDongServices
    {
        private readonly DataQlktxContext _qlktxContext;
        public HopDongServices(DataQlktxContext qlktxContext)
        {
            _qlktxContext = qlktxContext;
        }
        //thêm danh sách hợp đồng
        public async Task AddhopdongAsync(Hopdong phong)
        {
            _qlktxContext.Hopdongs.Add(phong);
            await _qlktxContext.SaveChangesAsync();
        }
        //xóa hợp đồng 
        public async Task DeletehopdongAsync(string id)
        {
            var pho = await GetPhongByIdAsync(id);
            if (pho != null)
            {
                _qlktxContext.Remove(pho);
                await _qlktxContext.SaveChangesAsync();
            }
        }
        //lấy danh sách hợp đồng 
        public async Task<List<Hopdong>> GetPhongAsync()
        {
            var pho = await _qlktxContext.Hopdongs.ToListAsync();
            return pho;
        }
        //lấy hợp đồng bằng id 
        public async Task<Hopdong?> GetPhongByIdAsync(string id)
        {
            var pho = await _qlktxContext.Hopdongs.FirstOrDefaultAsync(e => e.SoHopDong == id);
            return pho;
        }
        //lấy hợp đồng bằng MSSV
        public async Task<Hopdong?> GetHopDongByMssvAsync(string id)
        {
            var pho = await _qlktxContext.Hopdongs.FirstOrDefaultAsync(e => e.Mssv == id);
            return pho;
        }
        //câho nhật hợp đồng 
        public async Task UpdatePhongAsync(Hopdong phong)
        {
            _qlktxContext.Entry(phong).State = EntityState.Modified;
            await _qlktxContext.SaveChangesAsync();
        }
        //lấy danh sách HopDong thông qua trạng thái
        public async Task<List<Hopdong>> GetHopDongByTrangThaiAsync()
        {
            var result = await _qlktxContext.Hopdongs
                                    .Where(e => e.TrangThai == "Đang chờ phê duyệt")
                                    .ToListAsync();
            return result;
        }

        //xóa hợp đồng bằng id sinh viên
        public async Task DeleteHopDongForeignKeyAsync(string foreignKey)
        {
            var phList = await _qlktxContext.Hopdongs.Where(p => p.Mssv == foreignKey).ToListAsync();
            if (phList.Any())
            {
                _qlktxContext.Hopdongs.RemoveRange(phList);
                await _qlktxContext.SaveChangesAsync();
            }
        }
    }
}
