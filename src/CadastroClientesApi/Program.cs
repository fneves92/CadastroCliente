using CadastroCliente;
using Microsoft.EntityFrameworkCore;
using Repository;


var builder = WebApplication.CreateBuilder(args);

// Configurar CORS para permitir requisi��es do localhost:3000 (onde o React est� rodando)
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

// Adicionar o DbContext para o MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

// Registrar os reposit�rios e servi�os
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>(); // Utilizando a interface do servi�o

// Adicionar servi�os de controladores
builder.Services.AddControllers();

// Adicionar o servi�o do Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Aplicar a pol�tica de CORS
app.UseCors("AllowReactApp");

// Configura��o do pipeline HTTP
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
