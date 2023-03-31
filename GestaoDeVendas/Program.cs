using Microsoft.EntityFrameworkCore;
using GestaoDeVendas.Data;
using GestaoDeVendas.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GestaoDeVendasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GestaoDeVendasContext") ?? throw new InvalidOperationException("Connection string 'GestaoDeVendasContext' not found.")));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContext = services.GetService<GestaoDeVendasContext>();
        var seedingService = services.GetService<SeedingService>();

        seedingService.Seed();
    }
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
