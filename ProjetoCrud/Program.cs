using Microsoft.EntityFrameworkCore;
using ProjetoCrud.Data;
using ProjetoCrud.Services.Autor;
using ProjetoCrud.Services.Livro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//serve para que IAutorInterface entenda que seus metodos est�o implementados dentro de AutorService
//Os metodo que est�o no IAutorInterface est�o implementaos no AutorService
builder.Services.AddScoped<IAutorInterface , AutorService>();

builder.Services.AddScoped<ILivroInterface,  LivroService>();

//antes de contruir o projeto ir� pegar a string conexao do banco que est� no appsettings e mandar para o appDbContext 
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //Informa qual o tipo do meu banco de dados
    //builder.Configuration entra no appsettings, GetConnectionString pega a string de conexao que foi espeficida no seu atributo DefaulConnection
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection")); 
});

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
