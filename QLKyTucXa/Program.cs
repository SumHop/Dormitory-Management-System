using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using QLKyTucXa.Components;
using QLKyTucXa.Controller.Interfaces;
using QLKyTucXa.Controller.Services;
using System.Net.Mail;
using System.Net;
using QLKyTucXa.Controller.ViewContro;
using QLKyTucXa.Data;
using MudBlazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/access-denied";
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<LuuDichVuTrung>();

builder.Services.AddDbContext<DataQlktxContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLyKTX")));

builder.Services.AddMudServices();
builder.Services.AddScoped<IPhongServices, PhongServices>();
builder.Services.AddScoped<IPhuHuynhServices, PhuHuynhServices>();
builder.Services.AddScoped<ISinhVienServices, SinhVienServices>();
builder.Services.AddScoped<INhanVienServices, NhanVienServices>();
builder.Services.AddScoped<ITaiKhoanServices, TaiKhoanServices>();
builder.Services.AddScoped<IHopDongServices, HopDongServices>();
builder.Services.AddScoped<IThongBaoServices, ThongBaoServices>();
builder.Services.AddScoped<IHoaDonServices, HoaDonServices>();
builder.Services.AddScoped<IDichVuServices, DichVuServices>();
builder.Services.AddSingleton<LuuBien>();
builder.Services.AddScoped<IYeuCauDoiTraPhongService, YeuCauDoiTraPhongService>();

// Đăng ký dịch vụ Email
builder.Services.AddSingleton(new EmailService(
    smtpServer: "smtp.gmail.com",
    smtpPort: 465,
    smtpUser: "le4569829@gmail.com",
    smtpPass: "c k a q e s t m b y n a k t l i"
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
