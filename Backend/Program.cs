var builder = WebApplication.CreateBuilder(args);

// 🔹 1. Lägg till CORS-policy
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()  // Tillåter alla domäner (React + andra)
                  .AllowAnyMethod()  // Tillåter GET, POST, PUT, DELETE osv.
                  .AllowAnyHeader(); // Tillåter alla headers
        });
});

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

// 🔹 2. Lägg till CORS innan Authorization!
app.UseCors(MyAllowSpecificOrigins);

// Inaktivera HTTPS om du bara vill använda HTTP
// app.UseHttpsRedirection();

app.UseAuthorization();

// Använd Controllers
app.MapControllers();

app.Run();
