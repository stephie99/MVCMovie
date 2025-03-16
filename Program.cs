using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_Agile_Process_with_Agile.Data;
using MVC_Agile_Process_with_Agile.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MVC_Agile_Process_with_AgileContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVC_Agile_Process_with_AgileContext") ?? throw new InvalidOperationException("Connection string 'MVC_Agile_Process_with_AgileContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HelloWorld}/{action=Index}/{id?}");

app.Run();
