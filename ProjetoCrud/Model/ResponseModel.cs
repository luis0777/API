namespace ProjetoCrud.Model
{
    //essa clase é resposavel por padronizar as respostas que vamos obter
    // T = Generico
    //Como vamos usar essa classe para as resposta dos autores e livros, vamos usar um tipo generico
    //é tipo generico pq podemos ter dados do tipo autor, tanto do tipo livro 
    
    public class ResponseModel<T> 
    {
        //T? significa que o dado pode ser nulo, exemplo quando não encontrar nada dentro do banco, quando der um erro etc 
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
