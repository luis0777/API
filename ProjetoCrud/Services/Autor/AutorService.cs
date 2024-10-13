//AutorController - IAutorInterface - AutorService
//Controller se conecta com a interface 
// Interface se conecta com o serviço 
// Serviço que se conecta com o banco de dados, faz as solicitações, inserções, remoções etc

using Microsoft.EntityFrameworkCore;
using ProjetoCrud.Data;
using ProjetoCrud.Dto.Autor;
using ProjetoCrud.Model;

namespace ProjetoCrud.Services.Autor
{
    public class AutorService : IAutorInterface //AutorService ela é referenciada e respeita as regras  que estão no IAutorInterface
    {
        //propriedade privada apenas de leitura     
        //atraves do _dbContext consigo entrar no banco 
        private readonly AppDbContext _context;

        //recebe o metodo AppDbContext
        public AutorService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync<AutorModel>(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor Localizado";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = true;
                return resposta;

            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor localizado";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = new AutorModel()
                {
                    Nome = autorCriacaoDto.Nome,
                    Sobrenome = autorCriacaoDto.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor criado com sucesso!!!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async  Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEdicaoDto.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado";
                    return resposta;
                }

                autor.Nome = autorEdicaoDto.Nome;
                autor.Sobrenome = autorEdicaoDto.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Alterações feitas com sucesso!!!";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado";
                    return resposta;
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor removido com sucessso!!!";

                return resposta;

            }   
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        //usamos async que é um metodo assincrono pois não sabemos a quantidade de autores que irá ter na tabela do banco e 
        //queremos ir para a proxima fase somente que dizer coletados e feito a lista de todos os autores que estão na tabela
        //esperar que o processo de coleta de dados dentro do banco ocorra antes de eu dar continuidade no codigo
        //e para esperar usamos o METODO ASSINCRONO ASYNC

        //quando você usa Task, está dizendo ao compilador: "Estou iniciando uma operação, mas pode demorar um pouco,
        //então continue executando outras coisas e me avise quando a operação estiver pronta.
        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await _context.Autores.ToListAsync();

                resposta.Dados = autores;
                resposta.Mensagem = "Todos os autores foram listados";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
