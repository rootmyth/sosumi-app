using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using sosumi_app.Interfaces;
using sosumi_app.Repositories;

var builder = WebApplication.CreateBuilder(args);

var firebaseProjectId = builder.Configuration.GetValue<string>("Authentication:Firebase:ProjectId");
var googleTokenUrl = $"https://securetoken.google.com/{firebaseProjectId}";
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = googleTokenUrl;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = googleTokenUrl,
            ValidateAudience = true,
            ValidAudience = firebaseProjectId,
            ValidateLifetime = true
        };
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
