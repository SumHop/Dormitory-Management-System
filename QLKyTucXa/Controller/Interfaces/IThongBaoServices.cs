using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Interfaces
{
    public interface IThongBaoServices
    {
        Task<List<ThongBao>> GetthongbaobyisuserAsync(string id);
        Task DanhDauThongBaoAsync(string maThongBao);
        Task AddThongBaoAsync(ThongBao tb);
        Task GuiThongBaoAsync(List<string> idUsers, string noiDung);
        Task DeletethongbaoForeignKeyAsync(string foreignKey);
        Task<List<ThongBao>> GetAllThongBaosAsync(); // Thêm phương thức này
        Task<ThongBao> GetThongBaoByIdAsync(string maThongBao); // Thêm phương thức này
         Task<List<ThongBao>> GetLichSuSuCoByUserIdAsync(string idUser);
    }
}
