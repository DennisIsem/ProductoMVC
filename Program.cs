var builder = WebApplication.CreateBuilder(args);

// Instanciar Startup con la configuración
var startup = new Startup(builder.Configuration);

// Registrar servicios
startup.ConfigureServices(builder.Services);

// Construir la app
var app = builder.Build();

// Configurar middleware
startup.Configure(app, app.Environment);

app.Run();
