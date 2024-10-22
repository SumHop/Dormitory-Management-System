using QLKyTucXa.Data;

namespace QLKyTucXa.Controller.Interfaces
{
    public interface IYeuCauDoiTraPhongService
    {
        Task<List<Yeucaudoitraphong>> GetRequestsAsync();
        Task<bool> SubmitRequestAsync(Yeucaudoitraphong yeucau);
        Task<bool> UpdateRequestAsync(Yeucaudoitraphong request);
        Task<List<Yeucaudoitraphong>> GetRequestHistoryAsync();
        Task<List<Yeucaudoitraphong>> GetRoomChangeRequestsAsync();
        Task<List<Yeucaudoitraphong>> GetRoomReturnRequestsAsync();
    }
}