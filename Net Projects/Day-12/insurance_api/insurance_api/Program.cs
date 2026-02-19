using insurance_api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ CORS FIX (Angular localhost support)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:4200") // Angular dev server
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// ✅ ORDER MATTERS
app.UseHttpsRedirection();   // good practice
app.UseCors("AllowAngular"); // enable CORS here

app.MapControllers();

app.Run();
