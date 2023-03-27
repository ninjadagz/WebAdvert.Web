using WebAdvert.Web;

var builder = WebApplication.CreateBuilder(args);
// =-- moved content off into Startup.cs
// Add services to the container.
builder.Services.AddControllersWithViews();

//trying to add AWS code in Program
builder.Services.AddCognitoIdentity(config =>
{
    config.Password = new Microsoft.AspNetCore.Identity.PasswordOptions
    {
        RequireDigit = false,
        RequiredLength = 6,
        RequiredUniqueChars = 0,
        RequireLowercase = false,
        RequireNonAlphanumeric = false,
        RequireUppercase = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

/*
//Code was moved into Startup class
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, builder.Environment);
*/