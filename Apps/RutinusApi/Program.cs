using Microsoft.EntityFrameworkCore;
using RutinusApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RutinusDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 34))
    ));
builder.Services.AddScoped<RutinusApi.Repositories.CodeRepository>();
builder.Services.AddScoped<RutinusApi.Repositories.RoutineRepository>();
builder.Services.AddScoped<RutinusApi.Repositories.TrainingRepository>();
builder.Services.AddScoped<RutinusApi.Repositories.UserRepository>();
builder.Services.AddScoped<RutinusApi.Repositories.ScheduleRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
