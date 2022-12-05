using ETrade.Dal;
using ETrade.Entities.Concrete;
using ETrade.Repos.Abstract;
using ETrade.Repos.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ETradeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnect")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IBasketDetailRep, BasketDetailRep<BasketDetail>>();
builder.Services.AddScoped<IBasketMasterRep, BasketMasterRep<BasketMaster>>();
builder.Services.AddScoped<ICategoryRep, CategoryRep<Category>>();
builder.Services.AddScoped<ICityRep, CityRep<City>>();
builder.Services.AddScoped<ICountyRep, CountyRep<County>>();
builder.Services.AddScoped<IProductRep, ProductRep<Product>>();
builder.Services.AddScoped<IUnitRep, UnitRep<Unit>>();
builder.Services.AddScoped<IVatRep, VatRep<Vat>>();
builder.Services.AddScoped<IUserRep, UserRep<User>>();
builder.Services.AddScoped<IUow, Uow>();
//builder.Services.AddScoped<UserModel>();
builder.Services.AddScoped<BasketDetailModel>();
builder.Services.AddScoped<BasketMaster>();
builder.Services.AddScoped<BasketDetail>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
