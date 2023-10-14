using DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDbContext>(); 
builder.Services.AddScoped<IUOW, UOW>(); 





var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => {  endpoints.MapDefaultControllerRoute(); });

app.Run();
