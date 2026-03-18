using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ConexionSql.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no se encontró.");

// Registrar ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registrar ConexionSqlContext
builder.Services.AddDbContext<ConexionSqlContext>(options =>
    options.UseSqlServer(connectionString));

// ✅ Agregar Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Otros servicios
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Usar Session antes de Authorization
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();