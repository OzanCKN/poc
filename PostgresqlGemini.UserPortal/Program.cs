using PostgresqlGemini.Application;
using PostgresqlGemini.Infrastructure;
using PostgresqlGemini.UserPortal.Extensions;


var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//application ve infra seviyesi injectionlar

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseMigrationsEndPoint();
app.ApplyMigrations();
//if (app.Environment.IsDevelopment())
//{
//    app.UseMigrationsEndPoint();
//    app.ApplyMigrations();
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
