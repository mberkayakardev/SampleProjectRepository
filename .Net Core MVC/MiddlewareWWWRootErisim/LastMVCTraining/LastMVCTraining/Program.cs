using LastMVCTraining.Middlewares;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

#region Services 
builder.Services.AddControllersWithViews();
#endregion

var app = builder.Build();

#region Middlewares 

//app.Use(async (context, next) =>
//{
//    var a = 123;
//    if (!(context.Request.Path.ToString().Contains("/berkay")))
//        await next.Invoke();

//});


app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/berkay",
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules"))
});


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "defaults", pattern: "{Controller=Th}/{Action=Index}/{id?}");
});


#endregion

app.Run();

