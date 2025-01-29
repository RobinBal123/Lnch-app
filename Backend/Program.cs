var builder = WebApplication.CreateBuilder(args);

// Lägg till stöd för Controllers
builder.Services.AddControllers();

// Lägg till Swagger (OpenAPI) för dokumentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Aktivera Swagger endast i utvecklingsmiljö
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Inaktivera HTTPS om du bara vill använda HTTP
// app.UseHttpsRedirection();

app.UseAuthorization();

// Använd Controllers
app.MapControllers();

app.Run();
