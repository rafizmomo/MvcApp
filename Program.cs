using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);

// Add MySQL database provider
builder.Services.AddDbContext<MvcAppContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MvcAppContext"),
        new MySqlServerVersion(new Version(8, 0, 28))
    )
);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddRazorPages();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public class MvcAppContext : DbContext
{
    public MvcAppContext(DbContextOptions<MvcAppContext> options)
        : base(options)
    {
    }

    // DbSet properties for your entities
    // public DbSet<YourEntity> YourEntities { get; set; }

    // DbContext configuration and additional code
}