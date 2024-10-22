using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Interfaces
{
    public interface IDichVuServices
    {
        Task AddDichvuAsync(Dichvu dichvu);
        Task DeleteDichvuAsync(string id);
        Task<List<Dichvu>> GetDichvuAsync();
        Task<Dichvu?> GetDichvuByIdAsync(string id);
        Task UpdateDichvuAsync(Dichvu hoadon);
    }
}