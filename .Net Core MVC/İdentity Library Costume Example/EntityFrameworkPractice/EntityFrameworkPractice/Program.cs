using EntityFrameworkPractice;
using EntityFrameworkPractice.Data.Contexts;
using EntityFrameworkPractice.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<AppUser, AppRole>( x=>
{
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequiredLength= 1;
    x.Password.RequireUppercase= false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireDigit= false;
    x.Password.RequireLowercase = false;
    x.Password.RequireNonAlphanumeric= false;
    //x.SignIn.RequireConfirmedAccount= true; // ikisininde doğrulanmış olmasına bakar biri false ise giriş yapamazsın
    //x.SignIn.RequireConfirmedPhoneNumber= true; // Telefon numaran doğrulanmış ise ilgili işlemi yapabirisn
    //x.SignIn.RequireConfirmedEmail= true; // Email doğrulanmış ise ilgili işlemi yapabirisn


}).AddEntityFrameworkStores<MyContext>();


builder.Services.ConfigureApplicationCookie(x =>
{
    x.Cookie.HttpOnly = true; // document.cookie ile çekilemiyor
    x.Cookie.SameSite = SameSiteMode.Strict;  //Sadece bu domainden erişilebilir.
    x.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Http yada HTTPS ile çalışsın
    x.Cookie.Name = "Berkay"; // verdiğim isim şeklinde cookei adı gözükecek
    x.ExpireTimeSpan = TimeSpan.FromDays(15); // cookie 15 gün ayakta kalacaktır. 
    x.LoginPath = new PathString("Home/Login/"); // giriş yapmamış kişiyi redirect eder
    x.AccessDeniedPath = new PathString("Home/YetkisizErisim");
});

builder.Services.AddDbContext<MyContext>(opt =>
{
    opt.UseSqlServer("server=192.168.1.185;database=IdentityCostumeDb;user id=locallogin;password=Qwerasdf0147;TrustServerCertificate=Yes");
});



var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<CostumeMiddleware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
