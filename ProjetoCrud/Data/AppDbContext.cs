using Microsoft.EntityFrameworkCore;
using ProjetoCrud.Model;

namespace ProjetoCrud.Data
{
    public class AppDbContext : DbContext
    {
        //Esse construtor recebe informações referente ao banco de dados pois ele faz o meio campo entre o codigo e o banco de dados
        //DbContextOptions basicamente são opções de conexao 
        // e essas opçoes vão ser usadas dentro do AppDbContext
        // e as informações que estamos recebendo damos o nome de options 
        // e como base do contrutor temos options que são as informações recebidas 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Essa parte irá criar a tabela Autores no banco de dados tendo como base os modelos as informações que estão no AutorModel
        public DbSet<AutorModel> Autores { get; set; }

        //Essa parte irá criar a tabela Livros no banco de dados tendo como base os modelos as informações que estão no LivroModel
        public DbSet<LivroModel> Livros { get; set; }
    }
}
