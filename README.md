\#  CadCurriculoMVC



Sistema web para \*\*cadastro, gerenciamento e visualização de currículos\*\*, desenvolvido utilizando \*\*C# e ASP.NET Core MVC\*\*, com integração ao \*\*SQL Server\*\*.



O projeto foi desenvolvido com o objetivo de aplicar conceitos de desenvolvimento web, arquitetura MVC, operações CRUD e integração com banco de dados.



\---



\##  Funcionalidades



\*  Listagem de currículos cadastrados

\*  Cadastro de novos currículos

\*  Edição de currículos

\*  Exclusão de currículos

\*  Cadastro de informações pessoais

\*  Cadastro de cargo pretendido

\*  Cadastro de pretensão salarial

\*  Cadastro de formação acadêmica e cursos

\*  Cadastro de experiências profissionais

\*  Cadastro de idiomas

\*  Cadastro de resumo profissional

\*  Visualização do currículo



\---



\##  Tecnologias utilizadas



\* \*\*C#\*\*

\* \*\*ASP.NET Core MVC\*\*

\* \*\*Razor\*\*

\* \*\*ADO.NET\*\*

\* \*\*SQL Server\*\*

\* \*\*HTML5\*\*

\* \*\*CSS3\*\*

\* \*\*Bootstrap\*\*



\---



\##  Arquitetura



O projeto utiliza o padrão \*\*MVC (Model-View-Controller)\*\*, separando as responsabilidades da aplicação.



\### Model



Responsável pela representação dos dados utilizados pelo sistema.



O projeto utiliza um `CurriculoViewModel` para representar as informações do currículo.



\### View



Responsável pela interface apresentada ao usuário.



As páginas são desenvolvidas utilizando \*\*Razor Views\*\*, HTML, CSS e Bootstrap.



\### Controller



Responsável por receber as requisições e controlar o fluxo da aplicação.



O `CurriculoController` realiza operações relacionadas ao cadastro, consulta, edição e exclusão dos currículos.



\### DAO



A camada DAO é responsável pela comunicação entre a aplicação e o banco de dados SQL Server.



As operações realizadas incluem:



```text

CREATE → Cadastro

READ   → Consulta

UPDATE → Edição

DELETE → Exclusão

```



\---



\##  Estrutura do projeto



```text

CadCurriculoMVC/

│

├── Controllers/

│   ├── HomeController.cs

│   └── CurriculoController.cs

│

├── DAO/

│   ├── ConexaoBD.cs

│   ├── CurriculoDAO.cs

│   └── HelperDAO.cs

│

├── Models/

│   ├── CurriculoViewModel.cs

│   └── ErrorViewModel.cs

│

├── Views/

│   ├── Curriculo/

│   │   ├── Curriculo.cshtml

│   │   ├── Form.cshtml

│   │   └── Index.cshtml

│   │

│   └── Shared/

│

├── wwwroot/

│   ├── css/

│   ├── js/

│   └── ...

│

├── appsettings.json

├── Program.cs

├── Startup.cs

└── CadCurriculoMVC.csproj

```



\---



\##  Banco de dados



O sistema utiliza \*\*Microsoft SQL Server\*\* para armazenar os currículos cadastrados.



A conexão com o banco está configurada no arquivo:



```text

DAO/ConexaoBD.cs

```



Antes de executar o projeto, altere os dados da conexão de acordo com o seu ambiente:



```csharp

string strCon = "Data Source=LOCALHOST;Initial Catalog=NOME\_BD;user id=sa; password=SUA\_SENHA";

```



Substitua:



\* `LOCALHOST` pelo servidor SQL utilizado;

\* `NOME\_BD` pelo nome do banco de dados;

\* `SUA\_SENHA` pela senha do usuário configurado no SQL Server.



> ⚠️ Por segurança, nenhuma senha real de banco de dados é armazenada neste repositório.



\---



\##  Como executar



\### Pré-requisitos



Para executar o projeto, é necessário ter instalado:



\* Visual Studio

\* .NET SDK compatível com o projeto

\* SQL Server

\* SQL Server Management Studio (SSMS)



\### 1. Clone o repositório



```bash

git clone https://github.com/SEU-USUARIO/CadCurriculoMVC.git

```



\### 2. Configure o banco de dados



Crie um banco de dados no SQL Server e configure as tabelas necessárias para o funcionamento da aplicação.



Depois, altere a string de conexão no arquivo:



```text

DAO/ConexaoBD.cs

```



\### 3. Abra o projeto



Abra a solução no \*\*Visual Studio\*\*.



\### 4. Execute a aplicação



Execute o projeto utilizando:



```text

F5

```



ou:



```text

Ctrl + F5

```



A aplicação será iniciada e poderá ser acessada pelo navegador.



\---



\##  Objetivos e aprendizados



O desenvolvimento deste projeto permitiu praticar conceitos importantes de desenvolvimento web, incluindo:



\* Desenvolvimento de aplicações utilizando \*\*ASP.NET Core MVC\*\*

\* Criação e utilização de \*\*Controllers\*\*

\* Desenvolvimento de interfaces com \*\*Razor Views\*\*

\* Utilização de \*\*ViewModels\*\*

\* Implementação de operações \*\*CRUD\*\*

\* Integração de aplicações C# com \*\*SQL Server\*\*

\* Utilização de \*\*ADO.NET\*\*

\* Organização de projetos utilizando separação de responsabilidades

\* Manipulação e validação de dados

\* Desenvolvimento de interfaces utilizando HTML e CSS



\---



\##  Fluxo da aplicação



```text

&#x20;            ┌───────────────┐

&#x20;            │    Usuário    │

&#x20;            └───────┬───────┘

&#x20;                    │

&#x20;                    ▼

&#x20;            ┌───────────────┐

&#x20;            │     View      │

&#x20;            │     Razor     │

&#x20;            └───────┬───────┘

&#x20;                    │

&#x20;                    ▼

&#x20;            ┌───────────────┐

&#x20;            │  Controller   │

&#x20;            └───────┬───────┘

&#x20;                    │

&#x20;                    ▼

&#x20;            ┌───────────────┐

&#x20;            │      DAO      │

&#x20;            └───────┬───────┘

&#x20;                    │

&#x20;                    ▼

&#x20;            ┌───────────────┐

&#x20;            │  SQL Server   │

&#x20;            └───────────────┘

```



\---



