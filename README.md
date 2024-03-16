# ASP.NET Core Web API com Autenticação JWT Bearer e Documentação Swagger

Este repositório contém um projeto ASP.NET Core Web API para uma API CRUD RESTful projetada para gerenciamento financeiro. A API segue uma abordagem de arquitetura em camadas, separando as preocupações em camadas distintas, incluindo Domain, Infrastructure, Application e API.

## Recursos

- Operações CRUD para gerenciamento financeiro
- Arquitetura em camadas (Domain, Infrastructure, Application, API)
- Swagger para documentação da API
- Autenticação baseada em token JWT Bearer
- Fluent Validation para validação de e-mail e senha
- Salt para criptografia de senha
- SQL Server para armazenamento de dados
- Entity Framework Core para acesso ao banco de dados
- AutoMapper para mapeamento de objeto para objeto
- Padrão Repository para acesso aos dados
- ConfigurationModule para gerenciamento de configurações
- Objetos de Transferência de Dados (DTOs) para troca de dados

## Requisitos

- .NET Core SDK
- SQL Server

## Primeiros Passos

1. Clone este repositório:

`git clone https://github.com/aldruin/AspNetCore-WebApi-JWT-Bearer-Swagger.git`


2. Navegue até o diretório do projeto:

`cd AspNetCore-WebApi-JWT-Bearer-Swagger`


3. Atualize o arquivo `appsettings.json` com a string de conexão do seu SQL Server.

4. Execute as migrações do banco de dados para criar as tabelas necessárias:

5. Compile e execute o projeto:

`dotnet build`
`dotnet run`


## Pontos de Extremidade da API

### Usuário (User)

- **POST** `/api/User/create`: Cria um novo usuário. (Necessário ter privilégios de Admin)
- **GET** `/api/User/getall`: Recupera todos os usuários.
- **GET** `/api/User/get/{userId}`: Recupera um usuário específico pelo ID.
- **PUT** `/api/User/update/{userId}`: Atualiza um usuário existente.
- **DELETE** `/api/User/delete/{userId}`: Exclui um usuário pelo ID. (Necessário ter privilégios de Admin)

### Planilha (Sheet)

- **POST** `/api/Sheet/create`: Cria uma nova planilha.
- **GET** `/api/Sheet/getall`: Recupera todas as planilhas.
- **GET** `/api/Sheet/get/{sheetId}`: Recupera uma planilha específica pelo ID.
- **PUT** `/api/Sheet/update/{sheetId}`: Atualiza uma planilha existente.
- **DELETE** `/api/Sheet/delete/{sheetId}`: Exclui uma planilha pelo ID.

### Despesa Financeira (FinancialExpense)

- **POST** `/api/FinancialExpense/create`: Cria uma nova despesa financeira.
- **GET** `/api/FinancialExpense/getall`: Recupera todas as despesas financeiras.
- **GET** `/api/FinancialExpense/get/{expenseId}`: Recupera uma despesa financeira específica pelo ID.
- **PUT** `/api/FinancialExpense/update/{expenseId}`: Atualiza uma despesa financeira existente.
- **DELETE** `/api/FinancialExpense/delete/{expenseId}`: Exclui uma despesa financeira pelo ID.

### Entrada Financeira (FinancialEntry)

- **POST** `/api/FinancialEntry/create`: Cria uma nova entrada financeira.
- **GET** `/api/FinancialEntry/getall`: Recupera todas as entradas financeiras.
- **GET** `/api/FinancialEntry/get/{entryId}`: Recupera uma entrada financeira específica pelo ID.
- **PUT** `/api/FinancialEntry/update/{entryId}`: Atualiza uma entrada financeira existente.
- **DELETE** `/api/FinancialEntry/delete/{entryId}`: Exclui uma entrada financeira pelo ID.

### Autenticação (Authentication)

- **POST** `/api/Authentication/login`: Realiza o login do usuário e retorna um token de autenticação.

### Observações:

- Para executar operações que exigem privilégios de Admin, é necessário estar autenticado como um usuário com a role de Admin.
- Por padrão, a API não cria automaticamente usuários com a role de Admin. Isso deve ser feito manualmente, diretamente no banco de dados, ou já ter um Admin cadastrado no sistema.

## Configuração

Você pode configurar vários aspectos da aplicação usando o arquivo `appsettings.json`. Certifique-se de atualizar as configurações de acordo com o seu ambiente.

## Contribuição

Contribuições são bem-vindas!

## Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).
