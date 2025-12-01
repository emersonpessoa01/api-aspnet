using api.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// EF / MySQL
builder.Services.AddDbContext<DataContent>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("conexaoMySQL"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("conexaoMySQL"))
    )
);

// Swagger (Swashbuckle)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();


app.MapControllers();

app.MapGet("/", () => "API rodando...");

app.Run();
