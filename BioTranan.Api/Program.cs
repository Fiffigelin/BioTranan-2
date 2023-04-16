
using BioTranan.Core.Helper;
using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Repositories;
using BioTranan.Core.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "BioTranan ADMIN-API", Version = "v1" });
    c.SchemaFilter<EnumSchemaFilter>();
});

builder.Services.AddDbContext<BioTrananDbContext>(options => options.UseSqlite("Data Source = ../BioTranan.Core/BioTrananDb.db"));

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ISalonRepository, SalonRepository>();
builder.Services.AddScoped<IShowRepository, ShowRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMovieDetailsRepository, MovieDetailsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BioTranan ADMIN-API v1");
                });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
