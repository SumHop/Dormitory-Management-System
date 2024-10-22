using Microsoft.EntityFrameworkCore;
using QLKyTucXa.Controller.Interfaces;
using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Services
{
    public class ThongBaoServices : IThongBaoServices
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ThongBaoServices(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<List<ThongBao>> GetthongbaobyisuserAsync(string id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataQlktxContext>();
                return await context.ThongBaos
                    .Where(t => t.Iduser == id)
                    .OrderByDescending(t => t.ThoiGianThongBao)
                    .ToListAsync();
            }
        }

        public async Task DanhDauThongBaoAsync(string maThongBao)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataQlktxContext>();
                var thongBao = await context.ThongBaos.FindAsync(maThongBao);
                if (thongBao != null)
                {
                    thongBao.TrangThaiThongBao = true; // Đánh dấu là đã đọc
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task AddThongBaoAsync(ThongBao tb)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataQlktxContext>();
                context.ThongBaos.Add(tb);
                await context.SaveChangesAsync();
            }
        }

        public async Task GuiThongBaoAsync(List<string> idUsers, string noiDung)
        {
            foreach (var idUser in idUsers)
            {
                var thongBaoMoi = new ThongBao
                {
                    MaThongBao = Guid.NewGuid().ToString(),
                    Iduser = idUser,
                    NoiDung = noiDung,
                    ThoiGianThongBao = DateTime.Now,
                    TrangThaiThongBao = false,
                    LoaiThongBao = "Bình Thường"
                };
                await AddThongBaoAsync(thongBaoMoi);
            }
        }

        public async Task DeletethongbaoForeignKeyAsync(string foreignKey)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataQlktxContext>();
                var hopDongList = await context.ThongBaos.Where(hd => hd.Iduser == foreignKey).ToListAsync();

                if (hopDongList.Any())
                {
                    context.ThongBaos.RemoveRange(hopDongList);
                    await context.SaveChangesAsync();
                }
            }
        }

        // Phương thức mới để lấy tất cả các thông báo
        public async Task<List<ThongBao>> GetAllThongBaosAsync()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataQlktxContext>();
                return await context.ThongBaos.ToListAsync(); // Lấy danh sách tất cả sự cố
            }
        }

        // Phương thức mới để lấy thông báo theo ID
        public async Task<ThongBao?> GetThongBaoByIdAsync(string maThongBao)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataQlktxContext>();

                // Tìm thông báo theo MaThongBao
                var thongBao = await context.ThongBaos
                    .FirstOrDefaultAsync(t => t.MaThongBao == maThongBao);

                return thongBao;
            }
        }


        public async Task<List<ThongBao>> GetLichSuSuCoByUserIdAsync(string idUser)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataQlktxContext>();
                return await context.ThongBaos
                    .Where(t => t.Iduser == idUser && t.LoaiThongBao == "Sự cố")
                    .OrderByDescending(t => t.ThoiGianThongBao)
                    .ToListAsync();
            }
        }
       


    }
}
