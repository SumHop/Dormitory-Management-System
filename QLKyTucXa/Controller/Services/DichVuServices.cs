using Microsoft.EntityFrameworkCore;
using QLKyTucXa.Controller.Interfaces;
using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Services
{
    public class DichVuServices : IDichVuServices
    {

        private readonly DataQlktxContext _dataQlktxContext;
        public DichVuServices(DataQlktxContext dataQlktxContext)
        {
            _dataQlktxContext = dataQlktxContext;
        }

        /*        public async Task<List<Dichvu>> GetDichvuByMaPhongAsync(string id)
                {
                    var pho = await _dataQlktxContext.Hoadons
                        .Where(t => t.MaPhong == id)
                        .ToListAsync();
                    return pho;
                }*/

        public async Task AddDichvuAsync(Dichvu dichvu)
        {
            _dataQlktxContext.Dichvus.Add(dichvu);
            await _dataQlktxContext.SaveChangesAsync();
        }

        public async Task<Dichvu?> GetDichvuByIdAsync(string id)
        {
            var hoadon = await _dataQlktxContext.Dichvus.FirstOrDefaultAsync(e => e.MaDv == id);
            return hoadon;
        }

        public async Task<List<Dichvu>> GetDichvuAsync()
        {
            var hoadon = await _dataQlktxContext.Dichvus.ToListAsync();
            return hoadon;
        }

        public async Task DeleteDichvuAsync(string id)
        {
            var pho = await GetDichvuByIdAsync(id);
            if (pho != null)
            {
                _dataQlktxContext.Remove(pho);
                await _dataQlktxContext.SaveChangesAsync();
            }
        }

        public async Task UpdateDichvuAsync(Dichvu hoadon)
        {
            _dataQlktxContext.Entry(hoadon).State = EntityState.Modified;
            await _dataQlktxContext.SaveChangesAsync();
        }
    }
}
