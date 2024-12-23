using EComApplication.Services;
using FertiVueWebapi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register services with dependency injection container



// Register DbContext with connection string from appsettings.json
builder.Services.AddDbContext<UserDbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))); // Ensure this matches your appsettings.json key

// Add controllers
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();

app.MapControllers();

app.Run();