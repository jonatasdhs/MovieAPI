# Movie API

A **Movie API** é uma API RESTful desenvolvida com **ASP.NET Core** e **Entity Framework Core**, que permite o gerenciamento de filmes e autenticação de usuários. A API oferece funcionalidades para criar, ler, atualizar e excluir filmes, além de realizar o login de usuários com geração de tokens JWT.

## Tecnologias Utilizadas

- **.NET 8.0**: Framework principal para construção da API.
- **Entity Framework Core 8.0.8**: ORM para comunicação com o banco de dados SQL Server.
- **Isopoh.Cryptography.Argon2 2.0.0**: Biblioteca para hashing seguro de senhas.
- **Swashbuckle.AspNetCore 6.4.0**: Para gerar a documentação Swagger da API.
- **SQL Server**: Banco de dados relacional utilizado para persistência dos dados.

## Pacotes NuGet Instalados

- **Isopoh.Cryptography.Argon2** - 2.0.0
- **Microsoft.EntityFrameworkCore.Design** - 8.0.8
- **Microsoft.EntityFrameworkCore.InMemory** - 8.0.8
- **Microsoft.EntityFrameworkCore.SqlServer** - 8.0.8
- **Microsoft.EntityFrameworkCore.Tools** - 8.0.8
- **Microsoft.VisualStudio.Web.CodeGeneration.Design** - 8.0.5
- **Swashbuckle.AspNetCore** - 6.4.0

## Endpoints da API

### 1. **Usuários**
- **POST** `/api/users`: Cria um novo usuário.
- **POST** `/api/login`: Realiza o login de um usuário e gera um token JWT.

### 2. **Filmes**
- **GET** `/api/movies`: Retorna uma lista de filmes.
- **GET** `/api/movies/{id}`: Retorna os detalhes de um filme pelo ID.
- **POST** `/api/movies`: Cria um novo filme.
- **PUT** `/api/movies/{id}`: Atualiza um filme existente.
- **DELETE** `/api/movies/{id}`: Exclui um filme.

## Como Rodar a API

### 1. Configuração do Banco de Dados
No arquivo `appsettings.json`, atualize a string de conexão com seu banco de dados:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data source=DataSource;database=database;Trusted_connection=true;Encrypt=false;TrustServerCertificate=true"
  }
}
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Executar as Migrações

1. **Crie as migrações** e **atualize o banco de dados**:

```bash
dotnet ef migrations add InitialMigration
dotnet ef database update
```

### 4. Iniciar o Servidor

1. **Execute a API localmente**:

```bash
dotnet run
```

## Documentação da API (Swagger)

A documentação da API é gerada automaticamente utilizando o **Swagger**. Para acessá-la, inicie a aplicação e navegue até o seguinte endereço:

- **URL**: [https://localhost:7208/swagger](https://localhost:7208/swagger)

