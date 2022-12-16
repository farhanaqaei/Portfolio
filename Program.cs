using Portfolio2.Models;
using Portfolio2.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PortfolioDBSettings>(
    builder.Configuration.GetSection("PortfolioDatabase"));

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<PortfolioService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();