using Microsoft.EntityFrameworkCore;
using Repository;
using MongoDB.Driver;
using Repositories;
using Services;
using Command;


var builder = WebApplication.CreateBuilder(args);

// Configurar CORS para permitir requisições do localhost:3000 (onde o React está rodando)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("https://localhost:3000")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Adicionar o DbContext para o MySQL (para commands)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

// Configurar MongoDB (para queries)
var mongoClient = new MongoClient(builder.Configuration.GetConnectionString("MongoConnection"));
var mongoDatabase = mongoClient.GetDatabase("ClientesDb");
builder.Services.AddSingleton(mongoDatabase);

// Registrar repositórios de Commands (MySQL) e Queries (MongoDB)
builder.Services.AddScoped<IClienteCommandRepository, ClienteCommandRepository>();
builder.Services.AddScoped<IClienteQueryRepository, Infrastructure.MongoDB.ClienteQueryRepository>(); // Corrigido para refletir namespace correto


// Registrar os Command Handlers
builder.Services.AddScoped<AddClienteCommandHandler>();
builder.Services.AddScoped<UpdateClienteCommandHandler>();
builder.Services.AddScoped<DeleteClienteCommandHandler>();



// Registrar IClienteService
builder.Services.AddScoped<IClienteService, ClienteService>(); // Adicionar esta linha

// Adicionar serviços de controladores
builder.Services.AddControllers();

// Adicionar Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Aplicar a política de CORS
app.UseCors("AllowReactApp");

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CadastroClientesApi v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
