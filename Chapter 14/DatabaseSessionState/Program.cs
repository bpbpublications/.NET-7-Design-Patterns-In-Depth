var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDistributedSqlServerCache(options =>
{
    options.ConnectionString = @"
        Data Source=VAHID-LEGION;
        Initial Catalog=MyDb;
        Integrated Security=True;";
    options.SchemaName = "dbo";
    options.TableName = "SessionStore";
});

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "SessionInfo";
    options.IdleTimeout = TimeSpan.FromMinutes(60);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseSession();

app.Run();
