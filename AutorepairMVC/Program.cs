using AutorepairMVC.Data;
using AutorepairMVC.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AutorepairContext>(options => options.UseSqlServer(connString));

// добавление кэширования
builder.Services.AddMemoryCache();
// добавление поддержки сессии
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
//Использование MVC
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
// добавляем поддержку статических файлов
app.UseStaticFiles();
// добавляем поддержку сессий
app.UseSession();
// добавляем компонент middleware по инициализации базы данных и производим инициализацию базы
app.UseDbInitializer();


app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
