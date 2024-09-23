using Hospitalpage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
////builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddMediatR(cfg => cfg.
//RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
//builder.Services.AddTransient<IDbConnection>(x => new MySqlConnection(configuration.GetConnectionString("Default")));
builder.Services.RegisterBusinessService(builder.Configuration);

var app = builder.Build();
app.UseRouting();
app.MapControllers();

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
