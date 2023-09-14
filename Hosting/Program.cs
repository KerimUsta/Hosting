var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlantý dizesini appsettings.json'dan alýn
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DatabaseContext sýnýfýný ekleyin
builder.Services.AddScoped<DatabaseContext>(_ => new DatabaseContext(connectionString));

builder.Services.AddControllers();// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
