using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Interfaces
{
    public interface ITaiKhoanServices
    {
        Task AddtaikhoanAsync(Taikhoan phong);
        Task DeletetaikhoanAsync(string id);
        Task<List<Taikhoan>> GettaikhoanAsync();
        Task<Taikhoan?> GettaikhoanByIdAsync(string id);
        Task UpdatetaikhoanAsync(Taikhoan phong);
        Task<bool> EmailExistsAsync(string email);
        Task<Taikhoan?> GettaikhoanByEmailAsync(string id);
    }
}