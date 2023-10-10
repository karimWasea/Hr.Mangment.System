using DataAcess.layes;

using HR.Utailites;
using HR.ViewModel;

using IREprestory;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

using ReprestoryServess;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
IServiceCollection serviceCollection =
    builder.Services.AddDbContext<ApplicationDBcontext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<Applicaionuser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDBcontext>();

//builder.Services.AddDefaultIdentity<Applicaionuser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDBcontext>();



builder.Services.AddIdentity<Applicaionuser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
.AddEntityFrameworkStores<ApplicationDBcontext>().AddDefaultTokenProviders();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEmailSender, Emailsender>();
builder.Services.AddRazorPages();
//builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddTransient<EmployeeDeviceVm>();
builder.Services.AddTransient<RoleService>();
builder.Services.AddTransient<Imgoperation>();
builder.Services.AddTransient<UnitOfWork>();
builder.Services.AddTransient<EmployeeServsss>();
builder.Services.AddTransient<DepatmentServsess>();
builder.Services.AddTransient<SalaryTransactionServsess>();
builder.Services.AddTransient<lookupServess>();
builder.Services.AddTransient<SalaryclackServesses>();
builder.Services.AddTransient<TimeShiftServsss>();
builder.Services.AddTransient<VactionServsess>();
builder.Services.AddTransient<TriningServsess>();
builder.Services.AddTransient<DeviceServsess>();
builder.Services.AddTransient<WorkScheduleCurentWeekDayServsess>();
builder.Services.AddTransient<EmployeeWorkScheduleCurentWeekDayServsess>();
builder.Services.AddTransient<EmployeeTriningServsess>();
builder.Services.AddTransient<EmployeeDeviceServsess>();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.AccessDeniedPath = $"/Identity/Account/AccessDenied";
    option.LogoutPath = $"/Identity/Account/Logout";
    option.LoginPath = $"/Identity/Account/Login";

});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapRazorPages();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
       name: "HR",
       pattern: "{area=HR}/{controller=Employee}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


