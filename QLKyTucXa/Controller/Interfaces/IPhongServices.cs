using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Interfaces
{
    public interface IPhongServices
    {
        Task AddPhongAsync(Phong phong);
        Task DeletePhongAsync(string id);
        Task<List<Phong>> GetPhongAsync();
        Task<Phong?> GetPhongByIdAsync(string id);
        Task UpdatePhongAsync(Phong phong);
        Task<bool> IsSoGiuongEqualSoNguoiOAsync(string id);
        Task<List<Phong>> GetAvailableRoomsAsync(string currentRoomId);
    }
}