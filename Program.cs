using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp;
using WebApp.Models;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:ProductConnection"]);
    opts.EnableSensitiveDataLogging(true);
});

builder.Services.Configure<MvcOptions>(opts => opts.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value => "Geef een niet null waarde in"));

//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(opts =>/
//{
//    opts.Cookie.IsEssential = true;
//});

//builder.Services.Configure<RazorPagesOptions>(opts =>
//{
//    opts.Conventions.AddPageRoute("/index", "/extra/page/{id:long?}");
//});

builder.Services.AddSingleton<CitiesData>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<AntiforgeryOptions>(opts =>
opts.HeaderName = "X-XSRF-TOKEN");

var app = builder.Build();

app.UseStaticFiles();
app.UseMiddleware<AntiForgery>();


//app.UseSession();
app.MapDefaultControllerRoute().WithOrder(0);

app.MapRazorPages().WithOrder(1);

var context = app.Services.CreateScope().ServiceProvider
.GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);




app.Run();
