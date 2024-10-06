using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RealEstate.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
    new SmtpEmailSender(
        builder.Configuration["EmailSender:Host"],
        builder.Configuration.GetValue<int>("EmailSender:Port"),
        builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
        builder.Configuration["EmailSender:Username"],
        builder.Configuration["EmailSender:Password"])
);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromDays(1);
});
builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail =true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
    //options.Lockout.MaxFailedAccessAttempts = 5;
});



builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization(options =>
{
options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
});
builder.Services.ConfigureApplicationCookie(options =>
{
options.LoginPath = "/Account/Login";
options.AccessDeniedPath = "/Account/AccessDenied";
options.SlidingExpiration = true;
options.ExpireTimeSpan = TimeSpan.FromDays(10);
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



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

app.MapControllers();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}/{id2?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
