using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Shop.ApplicationServices.Services;
using Shop.Core.Domain;
using Shop.Core.ServiceInterface;
using Shop.Data;
using SignalRChat.Hubs;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ShopContext>();
//add dependence interface and service class
builder.Services.AddScoped<ISpaceshipServices, SpaceshipServices>();
//add dependence interface and service class
builder.Services.AddScoped<IFileServices, FileServices>();

//add dependence interface and service class
builder.Services.AddScoped<IRealEstateServices, RealEstatesServices>();

//add dependence interface and service class
builder.Services.AddScoped<IKindergartenServices, KindergartenServices>();

builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();

builder.Services.AddScoped<IChuckNorrisServices, ChuckNorrisServices>();

builder.Services.AddScoped<ICocktailsServices, CocktailsServices>();

builder.Services.AddScoped<IAccuWeatherServices, AccuWeatherServices>();

builder.Services.AddScoped<IEmailServices, EmailServices>();

builder.Services.AddSignalR();

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
//for display pictures in details
app.UseStaticFiles(new StaticFileOptions
   {
    FileProvider=new PhysicalFileProvider

    (Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
    RequestPath="/multipleFileUpload"



    });

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chatHub");

app.Run();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "realstates",
//        pattern: "Realstates/{action=Index}/{id?}",
//        defaults: new { controller = "Realstates" });
//    // Other route configurations...
//});
