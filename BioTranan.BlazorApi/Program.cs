using BioTranan.Core.Repositories;
using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "BioTranan Blazor-API", Version = "v1" });
});

builder.Services.AddDbContext<BioTrananDbContext>(options => options.UseSqlite("Data Source = ../BioTranan.Core/BioTrananDb.db"));
builder.Services.AddScoped<IMovieDetailsRepository, MovieDetailsRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BioTranan Blazor-API v1");
            });
}

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:5152")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
