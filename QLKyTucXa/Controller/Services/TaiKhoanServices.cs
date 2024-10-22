using Microsoft.EntityFrameworkCore;
using QLKyTucXa.Controller.Interfaces;
using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Services
{
    public class TaiKhoanServices : ITaiKhoanServices
    {
        private readonly DataQlktxContext _qlktxContext;
        public TaiKhoanServices(DataQlktxContext qlktxContext)
        {
            _qlktxContext = qlktxContext;
        }
        //thêm danh sách phòng
        public async Task AddtaikhoanAsync(Taikhoan phong)
        {
            _qlktxContext.Taikhoans.Add(phong);
            await _qlktxContext.SaveChangesAsync();
        }
        //xoa phong
        public async Task DeletetaikhoanAsync(string id)
        {
            var pho = await GettaikhoanByIdAsync(id);
            if (pho != null)
            {
                _qlktxContext.Remove(pho);
                await _qlktxContext.SaveChangesAsync();
            }
        }
        //lấy danh sách phòng
        public async Task<List<Taikhoan>> GettaikhoanAsync()
        {
            var pho = await _qlktxContext.Taikhoans.ToListAsync();
            return pho;
        }
        //lấy phòng bằng id
        public async Task<Taikhoan?> GettaikhoanByIdAsync(string id)
        {
            var pho = await _qlktxContext.Taikhoans.FirstOrDefaultAsync(e => e.Iduser == id);
            return pho;
        }
        //cập nhật phòng
        public async Task UpdatetaikhoanAsync(Taikhoan phong)
        {
            _qlktxContext.Entry(phong).State = EntityState.Modified;
            await _qlktxContext.SaveChangesAsync();
        }

        //kiểm tra mail
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _qlktxContext.Taikhoans.AnyAsync(tk => tk.Email == email);
        }
        //lấy tài khoản bằng Email
        public async Task<Taikhoan?> GettaikhoanByEmailAsync(string id)
        {
            var pho = await _qlktxContext.Taikhoans.FirstOrDefaultAsync(e => e.Email == id);
            return pho;
        }
    }
}
