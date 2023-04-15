using BioTranan.Core.Services.Contracts;
using BioTranan.Core.Data;
using Microsoft.EntityFrameworkCore;
using BioTranan.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<BioTrananDbContext>(options => options.UseSqlite("Data Source = ../BioTranan.Core/BioTrananDb.db"));
builder.Services.AddScoped<IShowsService, ShowsService>();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub(); // Lägg till SignalR-middleware för Blazor
    endpoints.MapFallbackToPage("/_Host");
});

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();