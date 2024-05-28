using MeetingMinutes.Application;
using MeetingMinutes.Infrastructure;
using MeetingMinutes.Web;
using WebMarkupMin.AspNetCore8;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Host.UseSerilogConfig(builder.Environment);

builder.Services
    .AddAppConfigurations(builder.Environment, builder.Configuration)
    .AddApplication()
    .AddInfrastructure();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseWebOptimizer();
app.UseWebMarkupMin();
app.UseHttpsRedirection();
app.UseRouting();

app.ApplyMigration();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
