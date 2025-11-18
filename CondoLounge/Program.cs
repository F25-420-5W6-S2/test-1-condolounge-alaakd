using CondoLounge.Data;
using CondoLounge.Data.Entities;
using CondoLounge.Data.Repositories.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// ----------------------------------------------
// Show detailed database error pages during development
builder.Services.AddDatabaseDeveloperPageExceptionFilter(); // Helps you debug issues like migrations or bad SQL queries

// -----------------------------------------------------------
// Configure ASP.NET Identity (authentication + authorization)
// -----------------------------------------------------------
builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
    options.SignIn.RequireConfirmedAccount = true) // Require users to confirm their email before they can log in
    .AddEntityFrameworkStores<ApplicationDbContext>() // Store Identity users + roles inside our SQL database using ApplicationDbContext
    .AddDefaultUI() // Adds the default pre-built login/register UI pages
    .AddDefaultTokenProviders(); // Adds token providers


// Add services to the container.
builder.Services.AddControllersWithViews();

// -------------------------------------------------------------
// Register DutchSeeder (used to seed sample data into the DB)
// -------------------------------------------------------------
// AddTransient = create a new DutchSeeder every time it's needed
builder.Services.AddTransient<CondoSeeder>();

// -------------------------------------------------------------
// Register UnitOfWork pattern (controls transactions + DB access)
// -------------------------------------------------------------
// AddScoped = one instance per HTTP request.
// This is required for anything that works with the database.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// -------------------------------------------------------------
// Register RepositoryProvider (creates repositories on demand)
// -------------------------------------------------------------
// Also scoped so its lifetime matches the UnitOfWork and DbContext.
builder.Services.AddScoped<IRepositoryProvider, RepositoryProvider>();

var app = builder.Build();

//Call seeding on startuP
await RunSeeding(app);

async Task RunSeeding(WebApplication app)
{
    var scopeFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopeFactory.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetService<CondoSeeder>();
        await seeder.Seed();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//tells the app to check who the user is.
app.UseAuthentication();
//tells the app to check what the user is allowed to do
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();