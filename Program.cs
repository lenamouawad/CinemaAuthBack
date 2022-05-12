using cinemas.Config;
using cinemas.Repositories;
using cinemas.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICinemaApiDatabaseSettings>(sp => sp.GetRequiredService<IOptions<CinemaApiDatabaseSettings>>().Value);
// Movie
builder.Services.AddSingleton<MovieRepository, MovieRepository>();
builder.Services.AddSingleton<MovieService, MovieService>();
// Room
builder.Services.AddSingleton<RoomRepository, RoomRepository>();
builder.Services.AddSingleton<RoomService, RoomService>();
// Cinema
builder.Services.AddSingleton<CinemaRepository, CinemaRepository>();
builder.Services.AddSingleton<CinemaService, CinemaService>();
// Screening
builder.Services.AddSingleton<ScreeningRepository, ScreeningRepository>();
builder.Services.AddSingleton<ScreeningService, ScreeningService>();

// Review
builder.Services.AddSingleton<ReviewRepository, ReviewRepository>();
builder.Services.AddSingleton<ReviewService, ReviewService>();
// Login
builder.Services.AddSingleton<LoginRepository, LoginRepository>();
builder.Services.AddSingleton<UsersService, UsersService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Ajouter les claims ?
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7266",
            ValidAudience = "https://localhost:7266",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ma clé super secrète"))
        };
    });

builder.Services.Configure<CinemaApiDatabaseSettings>(
    builder.Configuration.GetSection("CinemaApiDatabaseSettings"));

//builder.Services.AddDbContext<UserContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectingString:Cinema"]));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("EnableCORS");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
