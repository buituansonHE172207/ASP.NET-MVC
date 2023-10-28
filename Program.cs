using first_lesson.Services;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    // default is /View/ControllerName/ActionName.cshtml
    // add one location is /MyView/ControllerName/ActionName.cshtml
    //{1} ten caction
    //{2} ten controller
    //{3} ten area

    //options.ViewLocationFormats.Add("MyView/{1}/{0}.cshtml");
    options.ViewLocationFormats.Add("MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});
builder.Services.AddSingleton<ProductService>();
//builder.Services.AddSingleton<ProductService, ProductService>();
//builder.Services.AddSingleton(typeof(ProductService ));
//builder.Services.AddSingleton(typeof(ProductService ), typeof(ProductService ));

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
app.MapRazorPages();
app.Run();
