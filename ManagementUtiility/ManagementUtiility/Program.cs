using Microsoft.EntityFrameworkCore;
using ManagementRepo;
using Microsoft.AspNetCore.Identity;
using ManagementUtil;
using ManagementRepo.Interfaces;
using ManagementRepo.Implementation;
using Microsoft.AspNetCore.Identity.UI.Services;
using ManagemeantModel;
using ManagementServices;
using ManagementViewModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<AppDBContext>(arg => arg.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<AppDBContext>();



builder.Services.AddScoped<IDbInitializer,DbInitializer>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<ICompanyInfo, CompanyInfoService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<IFacility, FacilityService>();
builder.Services.AddTransient<IContact, ContactService>();
builder.Services.AddTransient<IAppUser, AppUserService>();
builder.Services.AddRazorPages();


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

DataSeeding();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();


app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{Area=Admin}/{controller=Company}/{action=Index}/{id?}");

app.Run();

void DataSeeding()
{
    using (var scope= app.Services.CreateScope())
    {
        var DbIntialilizer = scope.ServiceProvider.
            GetRequiredService<IDbInitializer>();
        DbIntialilizer.Initialize();
    }
}
