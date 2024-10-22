using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Interfaces
{
    public interface IHopDongServices
    {
        Task AddhopdongAsync(Hopdong phong);
        Task DeletehopdongAsync(string id);
        Task<List<Hopdong>> GetPhongAsync();
        Task<Hopdong?> GetPhongByIdAsync(string id);
        Task UpdatePhongAsync(Hopdong phong);
        Task<Hopdong?> GetHopDongByMssvAsync(string id);
        Task<List<Hopdong>> GetHopDongByTrangThaiAsync();
        Task DeleteHopDongForeignKeyAsync(string foreignKey);
    }
}