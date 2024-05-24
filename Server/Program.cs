using DataModel;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Server;
using Server.Auth;
using Server.Repositories;
using Server.Repositories.Interfaces;
using Server.Service;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb"));
});

builder.Services.AddCors();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IOrdersRepository, OrderRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IProductsInOrdersRepository, ProductsInOrdersRepository>();
builder.Services.AddScoped<IProductsOnShelvesRepository, ProductsOnShelvesRepository>();
builder.Services.AddScoped<IReportsRepository, EfReportRepository>();

builder.Services.AddScoped<UsersService>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy =>
{
    policy
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin();
});
app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict, //���� ����� ������������ ������ � ��� ������, ���� ������ ����������� � ���� �� �����, ��� � ������� URL
    //HttpOnly = HttpOnlyPolicy.Always, //���� ���������� ������ ����� HTTP-�������. ��� ��������, ��� ���� �� ����� �������� ����� JavaScript
    Secure = CookieSecurePolicy.Always //���� ����� ������������ ������ �� ���������� ����������� (HTTPS)
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.MapProductEndpoints();
//app.MapOrderTypesEndpoints();
//app.MapPlacementEndpoints();

app.Run();
