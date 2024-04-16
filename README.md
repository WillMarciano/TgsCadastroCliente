# TgsCadastroCliente

Teste pr�tico para vaga Desenvolvedor .Net para a empresa Localiza utilizando as t�cnologias

Arquitetura da Solu��o:
Back-end:
- API REST em C#: Utilizaremos o .NET 8 para criar uma API RESTful para manipula��o de clientes e logradouros.
- Entity Framework Core: Para acesso ao banco de dados, o Entity Framework Core ser� utilizado como ORM para manipula��o de dados.
- Autentica��o e Autoriza��o: Implementaremos autentica��o JWT (JSON Web Token) para autenticar usu�rios e autorizar suas solicita��es.
- Armazenamento de Imagens: As imagens do logotipo ser�o armazenadas no banco de dados utilizando a funcionalidade de armazenamento de arquivos bin�rios do SQL Server.
- Performance: Utilizaremos t�cnicas de otimiza��o de consulta, caching e escalabilidade horizontal para garantir alta performance.

Front-end:
- Angular 16
- Integra��o com a API: O front-end se comunicar� com a API RESTful para realizar opera��es CRUD de clientes e logradouros.

Decis�es de Design:
- Separation of Concerns (SoC): A arquitetura seguir� o padr�o DDD (Domain-Driven Design) para separar a l�gica de neg�cios das camadas de apresenta��o e persist�ncia de dados.
- Clean Architecture: Implementaremos uma arquitetura limpa, dividindo o sistema em camadas (Apresenta��o, Aplica��o, Dom�nio e Infraestrutura), garantindo assim a separa��o de responsabilidades e facilitando a manuten��o e testabilidade do sistema.


Instru��es para Execu��o:
1. Clonar o reposit�rio:
```
git clone
```

	
