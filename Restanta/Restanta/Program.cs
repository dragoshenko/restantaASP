using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restanta.Data;
using Restanta.Repositories.ActoriFilmeRepository;
using Restanta.Repositories.ActorRepository;
using Restanta.Repositories.FilmRepository;
using Restanta.Services.ActoriFilmeService;
using Restanta.Services.ActorService;
using Restanta.Services.FilmService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-LL8I0QR\\SQLEXPRESS;Database=RestantaDB;Trusted_Connection=True;TrustServerCertificate=True;");
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddTransient<IActorService, ActorService>();

builder.Services.AddTransient<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddTransient<IFilmService, FilmService>();

builder.Services.AddTransient<IActoriFilmeRepository, ActoriFilmeRepository>();
builder.Services.AddScoped<IActoriFilmeRepository, ActoriFilmeRepository>();
builder.Services.AddTransient<IActoriFilmeService, ActoriFilmeService>();

//front end connection
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});

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