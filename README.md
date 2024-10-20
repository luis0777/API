# Projeto-API

Objetivo: Desenvolver uma API para gerenciamento de livros e autores, permitindo operações como criação, edição, exclusão e busca de livros e autores.

# Estrutura do Projeto:

## Modelos:
LivroModel: Representa os livros, incluindo atributos como ID, título e autor.

AutorModel: Representa os autores, incluindo atributos como ID e nome.

## DTOs (Data Transfer Objects):
LivroCriacaoDto: Utilizado para criar novos livros, contendo dados necessários como título e ID do autor.

LivroEdicaoDto: Utilizado para editar livros existentes, incluindo ID do livro, título e ID do autor.

## Serviços:
IAutorInterface: Define operações para gerenciar autores.

Métodos como ListarAutores, BuscarAutorPorId, CriarAutor, EditarAutor, ExcluirAutor.

AutorService: Implementa IAutorInterface e fornece lógica para as operações relacionadas a autores.

ILivroInterface: Define operações para gerenciar livros.

Métodos como ListarLivros, BuscarLivroPorId, BuscarLivroPorIdAutor, CriarLivro, EditarLivro, ExcluirLivro.

LivroService: Implementa ILivroInterface e fornece lógica para as operações relacionadas a livros.

## Funcionalidades:
Buscar Livros: Permite buscar livros por ID ou por autor.

Criar Livros: Adiciona novos livros ao banco de dados, vinculando-os a um autor existente.

Editar Livros: Atualiza informações de livros existentes.

Excluir Livros: Remove livros do banco de dados.

Listar Livros e Autores: Recupera listas de todos os livros e autores registrados.

## Tecnologias Utilizadas:
Entity Framework Core: Para manipulação de dados e acesso ao banco de dados.

ASP.NET Core: Para construção da API.

## Conclusão
O projeto oferece uma API robusta para o gerenciamento de livros e autores, facilitando operações comuns e permitindo a integração com outras aplicações. Com uma estrutura clara e métodos bem definidos, o sistema é escalável e fácil de manter.
