using DataAcess.layes;

using HR_Api.IrepreatoryServess;
using HR_Api.Utellites;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;

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

builder.Services.AddControllers();



builder.Services.AddScoped<Unitofwork>();
builder.Services.AddScoped<DepatmentServsess_Api>();
builder.Services.AddScoped <DeviceEmployyServsess_Api>();
builder.Services.AddScoped<DeviceServsess_Api>();
builder.Services.AddScoped<VacationServsess_Api>();
builder.Services.AddScoped<trrningServsess_Api>();
builder.Services.AddScoped<TransactionsalaryServess_Api>();
builder.Services.AddTransient< HR_Api.Utellites
.Imgoperation >();
 builder.Services.AddScoped<EmployeeServess>();
//builder.Services.AddSingleton(env => env.GetRequiredService<IWebHostEnvironment>());
builder.Services.AddScoped<HostingEnvironment>();
builder.Services.AddScoped<SalaryclackServesses>();


builder.Services.AddScoped<WorkScheduleCurentWeekServsess_Api>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();


app.MapControllers();
try
{
    app.Run();

}
catch ( Exception ex)
{
     Console.WriteLine(ex.ToString() );
    app.Run();

}

