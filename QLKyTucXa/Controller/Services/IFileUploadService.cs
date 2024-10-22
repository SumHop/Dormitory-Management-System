using Microsoft.AspNetCore.Components.Forms;

namespace QLKyTucXa.Controller.Services
{
    public interface IFileUploadService
    {
        Task SaveFileAsync(IBrowserFile file);
    }
}