

\# Portfolio Admin CRUD (.NET 8)



Um projeto profissional desenvolvido em \*\*.NET 8\*\*, com arquitetura limpa (Domain/Infrastructure/WebApp), autenticação via \*\*ASP.NET Core Identity\*\*, autorização baseada em \*\*Roles + Claims\*\*, painel administrativo moderno e responsivo, e integração com \*\*PostgreSQL hospedado no Railway\*\*.



Este projeto foi criado para servir como \*\*portfólio profissional\*\*, demonstrando domínio de:



\* Arquitetura de software

\* ASP.NET MVC

\* Identity + Claims + Roles

\* Entity Framework Core

\* PostgreSQL

\* Boas práticas no design de APIs e WebApps

\* Sistema de CRUD completo

\* Painel administrativo profissional

\* Pattern Domain-Driven Design (DDD) simplificado



---



\## Tecnologias Utilizadas



\### \*\*Backend\*\*



\* .NET 8

\* ASP.NET Core MVC

\* ASP.NET Identity (com Roles, Claims e UI)

\* Entity Framework Core 8

\* PostgreSQL (via Npgsql)

\* Railway (Hosting do banco)

\* Dependency Injection nativo



\### \*\*Frontend\*\*



\* Razor Views (MVC)

\* Bootstrap 5.3

\* Bootstrap Icons

\* Layout Admin customizado (Dark Sidebar + Light Content)



\### \*\*Arquitetura\*\*



\* \*\*Domain\*\* → Entidades, regras básicas, permissões

\* \*\*Infrastructure\*\* → Banco de dados, Migrations, Repositórios

\* \*\*WebApp\*\* → MVC, Identity, Controllers, Views, Layouts



---



\# Arquitetura do Projeto



```

portfolio-admin-crud-dotnet/

│

├── Domain/

│   ├── Entities/

│   │   └── Project.cs

│   └── Authorization/

│       ├── Permissions/

│       │   ├── DashboardPermissions.cs

│       │   ├── ProjectPermissions.cs

│       │   └── PermissionNames.cs

│       └── Attributes/

│           └── PermissionAttribute.cs

│

├── Infrastructure/

│   ├── Data/

│   │   └── ApplicationDbContext.cs

│   ├── Migrations/

│   └── Services/

│

└── WebApp/

&nbsp;   ├── Areas/

&nbsp;   │   ├── Admin/

&nbsp;   │   │   ├── Controllers/

&nbsp;   │   │   │   └── DashboardController.cs

&nbsp;   │   │   ├── Views/

&nbsp;   │   │   │   ├── Dashboard/

&nbsp;   │   │   │   └── Shared/

&nbsp;   │   │   │       └── \_LayoutAdmin.cshtml

&nbsp;   │   │   └── Attributes/

&nbsp;   │   │       └── AdminAreaAttribute.cs

&nbsp;   │   └── Identity/

&nbsp;   │       └── (UI gerado automaticamente)

&nbsp;   │

&nbsp;   ├── Controllers/

&nbsp;   ├── Views/

&nbsp;   │   ├── Home/

&nbsp;   │   │   └── Index.cshtml

&nbsp;   │   └── Shared/

&nbsp;   │       └── \_Layout.cshtml

&nbsp;   │

&nbsp;   ├── Extensions/

&nbsp;   │   └── ClaimsPrincipalExtensions.cs

&nbsp;   │

&nbsp;   ├── Program.cs

&nbsp;   └── appsettings.json

```



---



\# Sistema de Autenticação e Autorização



\## ✔ ASP.NET Identity



A aplicação usa o \*\*Identity completo\*\*, incluindo:



\* Login

\* Logout

\* Registro

\* Recuperação de senha

\* UI padrão integrada ao projeto



\##  Controle de Acesso por Roles



Um usuário administrador é criado automaticamente:



| Email                                     | Senha    | Role  |

| ----------------------------------------- | -------- | ----- |

| \[admin@admin.com](mailto:admin@admin.com) | Admin123 | Admin |



Criado via:



```csharp

await DbInitializer.SeedUsersAndRolesAsync(services);

```



\## Controle Avançado por Claims (Permissões)



O sistema usa \*\*Claims personalizadas\*\* para determinar:



\* O que aparece no menu

\* Quais módulos o usuário pode acessar

\* Qual controller/action é permitida



Exemplo:



```csharp

\[Permission(DashboardPermissions.View)]

public IActionResult Index()

```



---



\# Painel Administrativo



O painel administrativo possui:



\* Sidebar escura profissional

\* Menu dinâmico baseado em permissões

\* Ícones modernos

\* Topbar com usuário logado

\* Botão de logout funcional

\* Layout clean e corporativo



Layout em:



```

Areas/Admin/Views/Shared/\_LayoutAdmin.cshtml

```



---



\# CRUD de Projetos (em desenvolvimento)



Entidade principal:



```csharp

public class Project

{

&nbsp;   public int Id { get; set; }

&nbsp;   public string Name { get; set; }

&nbsp;   public string Description { get; set; }

&nbsp;   public string Url { get; set; }

&nbsp;   public string Repository { get; set; }

&nbsp;   public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}

```



A migration correspondente:



```

AddProjectsTable

```



Tabelas criadas automaticamente:



\* Projects

\* Todas as tabelas do Identity (AspNetUsers, Roles, Claims, etc.)



---



\#  Como Rodar Localmente



\## 1. Clonar o projeto



```bash

git clone https://github.com/jotabox/portfolio-admin-crud-dotnet

cd portfolio-admin-crud-dotnet/WebApp

```



\## 2. Configurar a Connection String



No arquivo:



```

WebApp/appsettings.json

```



Altere:



```json

"ConnectionStrings": {

&nbsp; "DefaultConnection": "Host=...;Port=...;Database=...;Username=...;Password=..."

}

```



\## 3. Rodar Migrations



```bash

dotnet ef database update --project ../Infrastructure --startup-project .

```



\## 4. Rodar a aplicação



```bash

dotnet run

```



Acesse:



```

https://localhost:<porta>

```



---



\# 🧪 Usuário Administrador



Login padrão:



```

Email: admin@admin.com

Senha: Admin123

```



Permissões:

\*\*todas\*\* as permissões definidas no sistema.



---



\#  Funcionalidades Atuais



✔ Login e logout

✔ Proteção por área administrativa

✔ Permissões personalizadas

✔ Menu lateral dinâmico

✔ Layout Admin moderno

✔ Domínio organizado em camadas

✔ Dashboard inicial



---



\# Funcionalidades Futuras



🔧 CRUD completo de Projetos

🔧 CRUD de Usuários

🔧 Sistema completo de permissões UI

🔧 Logs administrativos

🔧 Dashboard com dados reais

🔧 Deploy da WebApp



---



\# Autor



\*\*Jota\*\*

Desenvolvedor .NET • C# • Unity • Web • Arquitetura • Jogos • TCG

GitHub: \[https://github.com/jotabox](https://github.com/jotabox)



---



\# Licença



Este projeto é open-source sob a licença MIT.



---





