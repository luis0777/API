//AutorController - IAutorInterface - AutorService
//Controller se conecta com a interface 
// Interface se conecta com o serviço 
// Serviço que se conecta com o banco de dados, faz as solicitações, inserções, remoções etc

using ProjetoCrud.Dto.Autor;
using ProjetoCrud.Model;

namespace ProjetoCrud.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);

    }
}   
