using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using User_Empresa.Areas.Identity.Data;
using User_Empresa.Core;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI().AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Authorization

AddAuthorizationPolicies(builder.Services);

#endregion

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

void AddAuthorizationPolicies(IServiceCollection services)
{

    services.AddAuthorization(options =>
    {
        options.AddPolicy(Constants.Policies.Empresa, policy => policy.RequireRole(Constants.Roles.Empresa));
    });

    services.AddAuthorization(options =>
    {
        //options.AddPolicy(Constants.Policies.Empresa, policy => policy.RequireRole("Empresa"));
        options.AddPolicy(Constants.Policies.Aluno, policy => policy.RequireRole(Constants.Roles.Aluno));
    });

    services.AddAuthorization(options =>
    {
        options.AddPolicy(Constants.Policies.RequiredAdmin, policy => policy.RequireRole(Constants.Roles.Admin));
    });
}
