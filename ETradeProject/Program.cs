using ETrade.Dal;
using ETrade.DTO;
using ETrade.DTO.Models;
using ETrade.Entities.Concrete;
using ETrade.Repos.Abstract;
using ETrade.Repos.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.UoW;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//add for session
builder.Services.AddDistributedMemoryCache();

//add for session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ETradeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnect")));

builder.Services.AddScoped<IBasketDetailRep, BasketDetailRep<BasketDetail>>();
builder.Services.AddScoped<IBasketMasterRep, BasketMasterRep<BasketMaster>>();
builder.Services.AddScoped<ICategoryRep, CategoryRep<Category>>();
builder.Services.AddScoped<ICityRep, CityRep<City>>();
builder.Services.AddScoped<ICountyRep, CountyRep<County>>();
builder.Services.AddScoped<IProductRep, ProductRep<Product>>();
builder.Services.AddScoped<IUnitRep, UnitRep<Unit>>();
builder.Services.AddScoped<IVatRep, VatRep<Vat>>();
builder.Services.AddScoped<IUserRep, UserRep<User>>();
builder.Services.AddScoped<ISizeRep, SizeRep<Size>>();
builder.Services.AddScoped<IBrandRep, BrandRep<Brand>>();
builder.Services.AddScoped<ISubCategoryRep, SubCategoryRep<SubCategory>>();
builder.Services.AddScoped<IColorRep, ColorRep<Color>>();
builder.Services.AddScoped<IUoW, UoW>();
builder.Services.AddScoped<User>();
builder.Services.AddScoped<Category>();
builder.Services.AddScoped<BasketMaster>();
builder.Services.AddScoped<BasketDetail>();
builder.Services.AddScoped<Response>();
builder.Services.AddScoped<UserDTO>();
builder.Services.AddScoped<ProductDTO>();
builder.Services.AddScoped<ProductModel>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//add for session
app.UseSession();

app.MapControllers();
//Swagger
app.UseDeveloperExceptionPage();

app.Run();
