using Microsoft.EntityFrameworkCore;
using Repository;
using MongoDB.Driver;
using Command;
using Command.Handlers;
using Query.Handlers;
using CadastroCliente;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

var mongoClient = new MongoClient(builder.Configuration.GetConnectionString("MongoConnection"));
var mongoDatabase = mongoClient.GetDatabase("ClientesDb");
builder.Services.AddSingleton(mongoDatabase);


builder.Services.AddScoped<IClienteCommandRepository, ClienteCommandRepository>();
builder.Services.AddScoped<IClienteMongoRepository, Infrastructure.MongoDB.ClienteMongoRepository>();
builder.Services.AddScoped<AddClienteCommandHandler>();
builder.Services.AddScoped<UpdateClienteCommandHandler>();
builder.Services.AddScoped<DeleteClienteCommandHandler>();
builder.Services.AddScoped<GetAllClientesQueryHandler>();
builder.Services.AddScoped<GetClienteByIdQueryHandler>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowReactApp");

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
