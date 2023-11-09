var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


var app = builder.Build();


app.UseRouting();
app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllerRoute(name: "default", pattern: "product/{action}", defaults: new { controller = "ahmet", action="index"}) ;



    endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}", defaults: new { controller = "product", action = "index" });
    endpoints.MapControllerRoute(name: "api", pattern: "api/{controller}/{action}/{id?}", defaults: new { controller = "DataTransfer", action = "index" });

    //endpoints.MapControllerRoute(name: "default", pattern: "{action}/{controller}", defaults: new { controller = "home", action = "index" });


});

app.Run();
