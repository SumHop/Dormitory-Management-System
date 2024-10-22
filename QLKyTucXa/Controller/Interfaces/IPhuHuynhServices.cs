using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Interfaces
{
    public interface IPhuHuynhServices
    {
        Task AddphuHuynhAsync(Phuhuynh ph);
        Task DeletePhuHuynhAsync(string id);
        Task<Phuhuynh?> GetPhuhuynhByIdAsync(string id);
        Task<List<Phuhuynh?>> GetPhuHuynhByStudentIdAsync(string? id);
        Task<List<Phuhuynh>> GetPhuhuynhsAsync();
        Task UpdatePhuHuynhAsync(Phuhuynh ph);
        Task DeletephuhuynhForeignKeyAsync(string foreignKey);
    }
}