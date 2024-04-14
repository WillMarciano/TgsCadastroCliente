# TgsCadastroCliente

Arquitetura da Solução:
Back-end:
- API REST em C#: Utilizaremos o .NET 8 para criar uma API RESTful para manipulação de clientes e logradouros.
- Entity Framework Core: Para acesso ao banco de dados, o Entity Framework Core será utilizado como ORM para manipulação de dados.
- Autenticação e Autorização: Implementaremos autenticação JWT (JSON Web Token) para autenticar usuários e autorizar suas solicitações.
- Armazenamento de Imagens: As imagens do logotipo serão armazenadas no banco de dados utilizando a funcionalidade de armazenamento de arquivos binários do SQL Server.
- Performance: Utilizaremos técnicas de otimização de consulta, caching e escalabilidade horizontal para garantir alta performance.

Front-end:
- ASP.NET com MVC e Razor: Para o front-end, utilizaremos ASP.NET com MVC e Razor para renderização de páginas dinâmicas.
- HTML, JavaScript: Serão utilizados para criar interfaces de usuário interativas e responsivas.
- Integração com a API: O front-end se comunicará com a API RESTful para realizar operações CRUD de clientes e logradouros.

Decisões de Design:
- Separation of Concerns (SoC): A arquitetura seguirá o padrão DDD (Domain-Driven Design) para separar a lógica de negócios das camadas de apresentação e persistência de dados.
- Clean Architecture: Implementaremos uma arquitetura limpa, dividindo o sistema em camadas (Apresentação, Aplicação, Domínio e Infraestrutura), garantindo assim a separação de responsabilidades e facilitando a manutenção e testabilidade do sistema.