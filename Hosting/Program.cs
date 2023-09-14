var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lant� dizesini appsettings.json'dan al�n
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DatabaseContext s�n�f�n� ekleyin
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
