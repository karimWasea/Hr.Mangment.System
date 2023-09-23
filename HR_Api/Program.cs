using DataAcess.layes;

using HR_Api.Irepreatory;
using HR_Api.IrepreatoryServess;
using HR_Api.Seting;
using HR_Api.Utellites;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.IdentityModel.Tokens;

using System.Text;

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

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailingService, MailingService>();
builder.Services.AddScoped<IAuthService, AuthService>();


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
builder.Services.AddScoped<TriningEmpoyeeServsess_Api>();


builder.Services.AddScoped<WorkScheduleCurentWeekServsess_Api>();

// Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    // Set the default authentication scheme for successful authentication
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    // Set the default challenge scheme for authentication challenges
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(o =>
{
    // Set to true in production to require HTTPS for metadata requests
    o.RequireHttpsMetadata = false;

    // Set to true to persist the token after validation
    o.SaveToken = false;

    // Configure token validation parameters
    o.TokenValidationParameters = new TokenValidationParameters
    {
        // Validate the issuer's signing key
        ValidateIssuerSigningKey = true,

        // Validate the issuer of the token
        ValidateIssuer = true,

        // Validate the intended audience of the token
        ValidateAudience = true,

        // Validate the token's expiration time
        ValidateLifetime = true,

        // Set the valid issuer for your application
        ValidIssuer = builder.Configuration["JWT:Issuer"],

        // Set the valid audience for your application
        ValidAudience = builder.Configuration["JWT:Audience"],

        // Set the issuer's signing key generated from your secret key
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),

        // Set the maximum acceptable clock skew for token expiration
        ClockSkew = TimeSpan.Zero
    };
});

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

