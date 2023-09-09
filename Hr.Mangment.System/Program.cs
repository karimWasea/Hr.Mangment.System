using DataAcess.layes;

using HR.Utailites;

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

builder.Services.ConfigureApplicationCookie(options =>
{
    // Set the path for the login page.
    //options.LoginPath = "/Identity/Account/Login";

    // Set the path for the access denied page.
    //options.AccessDeniedPath = "/Identity/Account/AccessDenied";

    //    // Set the path for the logout page.
        //options.LogoutPath = "/Identity/Account/Logout";

    //// Set the cookie expiration time (in this example, it's set to 7 days).
    //options.ExpireTimeSpan = TimeSpan.FromDays(7);

    //    Set whether the cookie is essential for authentication.If set to true,
    //    authentication will fail if the cookie is not present.
    /// options.Cookie.IsEssential = true;

    //    Set the cookie name.
        //options.Cookie.Name = "authratization";

    //    Set the domain for the cookie. If not set, the cookie will be valid for the current domain only.
     //options.Cookie.Domain = ".HR"

    //    Set whether the cookie should only be transmitted over HTTPS.
      // options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;

    //    Set the cookie path.
       //options.Cookie.Path = "/";

    //    Set whether the cookie should be accessible by JavaScript in the browser.
    ///   options.Cookie.Domain = true;
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
app.MapRazorPages();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


