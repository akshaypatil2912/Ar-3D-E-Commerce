using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Login/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Configure static files with custom MIME types
var provider = new FileExtensionContentTypeProvider();
// Add custom MIME types
provider.Mappings[".glb"] = "model/gltf-binary";
provider.Mappings[".gltf"] = "model/gltf+json";

// Enable serving static files with the custom MIME types
app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "myhome",
    pattern: "MyHomePage",
    defaults: new { controller = "MyHomePage", action = "MyHomePage" });

//action is the method name inside controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{returnurl?}");

app.MapControllerRoute(
    name: "LaunchARFurniture",
    pattern: "LaunchARFurniture",
    defaults: new {controller="LaunchARFurniture",action="LaunchARFurniture"});

app.MapControllerRoute(
    name: "LaunchARFashion",
    pattern: "LaunchARFashion",
    defaults: new { controller = "LaunchARFashion", action = "LaunchARFashion" });


app.Run();
