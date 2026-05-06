using Microsoft.EntityFrameworkCore;
using PsiquiatriaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔥 1. Puerto dinámico (OBLIGATORIO en Railway)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

// 🔥 2. Obtener cadena de conexión (soporta Railway Variables)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("❌ ERROR: No se encontró la cadena de conexión");
}
else
{
    Console.WriteLine("✅ Conectando a PostgreSQL...");
}

// 🔥 3. Configurar DbContext con reintentos
builder.Services.AddDbContext<HospitalContext>(options =>
    options.UseNpgsql(connectionString, o =>
    {
        o.EnableRetryOnFailure();
    }));

builder.Services.AddControllers();

// 🔥 4. Swagger visible en Railway
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔥 5. Manejo de errores global (MUY IMPORTANTE)
AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
{
    Console.WriteLine("❌ ERROR GLOBAL:");
    Console.WriteLine(e.ExceptionObject.ToString());
};

// 🔥 6. Aplicar migraciones automáticamente
using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<HospitalContext>();
        db.Database.Migrate();
        Console.WriteLine("✅ Migraciones aplicadas correctamente");
    }
    catch (Exception ex)
    {
        Console.WriteLine("❌ Error al aplicar migraciones:");
        Console.WriteLine(ex.ToString());
    }
}

// 🔥 7. Swagger en la raíz (para Railway)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PsiquiatriaAPI V1");
    c.RoutePrefix = string.Empty;
});

// 🚫 NO usar en Railway
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();