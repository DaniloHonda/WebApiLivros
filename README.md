
# WebApiLivros

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET Core 8.0
- **ORM**: Entity Framework Core
- **Banco de Dados**: PostgreSQL

## Funcionamento

A API WebApiLivros é uma aplicação RESTful que gerencia livros e autores, permitindo operações CRUD (Create, Read, Update, Delete) para ambos os recursos. A API utiliza Entity Framework Core para interagir com um banco de dados PostgreSQL e segue o padrão de arquitetura com interfaces e serviços para melhor organização e escalabilidade. Os endpoints estão disponíveis em `https://localhost:7190/api/` e podem ser acessados via métodos HTTP (GET, POST, PUT, DELETE).

Abaixo estão os detalhes dos endpoints disponíveis para livros e autores, incluindo métodos, parâmetros e retornos esperados.

### Endpoints para Livros

Todos os endpoints relacionados a livros estão localizados em `https://localhost:7190/api/Livros`. Eles retornam respostas no formato JSON, encapsuladas em um objeto `ResponseModel<T>`, que inclui informações como `Data` (dados da operação), `Message` (mensagem de status) e `Status` (indicador de sucesso ou falha).

1. ListarLivros()
2. BuscarLivro(int id)
3. BuscarLivroPorIdAutor(int id)
4. CriarLivro(LivroCriacaoDto livro)
5. AtualizarLivro(LivroAtualizarDto livro)
6. DeletarLivro(int id)

### Endpoints para Autores

1. ListarAutores()
2. BuscarAutor(int id)
3. BuscarAutorPorIdLivro(int id)
4. CriarAutor(AutorCriacaoDto autor)
5. AtualizarAutor(AutorAtualizarDto autor)
6. DeletarAutor(int id)

## Instalação e Execução

## 1. Clone o Repositório:
```bash
git clone https://github.com/DaniloHonda/WebApiLivros.git
cd WebApiLivros
```
## 2. Restaure as Dependências:
```bash
dotnet restore
```
## 3. Aplique as Migrations:
```bash
dotnet ef database update
```
## 4. Execute a Aplicação:
```bash
dotnet run
```
### A API estará disponível em https://localhost:7190/api/Livros.
