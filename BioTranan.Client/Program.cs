using BioTranan.Client.Data;
using BioTranan.Core.Services.Contracts;
using BioTranan.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5133") });
builder.Services.AddScoped<IShowsService, ShowsService>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapFallbackToPage("/_Host");

app.Run();
