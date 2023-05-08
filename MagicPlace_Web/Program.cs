using MagicPlace_Web;
using MagicPlace_Web.Services.IServices;
using MagicPlace_Web.Services.UseServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddHttpClient<IPlaceService, PlaceService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();

builder.Services.AddHttpClient<ICategoryPlaceService, CategoryPlaceService>();
builder.Services.AddScoped<ICategoryPlaceService, CategoryPlaceService>();

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
