# Teste Prático TGS

## Descrição do projeto 

<p align="justify">
  Projeto de uma API para cadastro de clientes, para utilizar os endpoints é necessário pessoas autenticadas e autorizadas para ter acesso as funcionalidades, 
  em cada requisição é enviado um token para autenticação
</p>

## Solicitação do Cliente

<ul>
  <li>Deve ser possível criar, atualizar, visualizar e remover Cliente.</span></li>
  <ul>
    <li><span>O cadastro dos clientes deve conter apenas os seguintes campos:</span></li>
    <li><span>Nome</span></li>
    <li><span>e-mail</span></li>
    <li><span>Logotipo;</span></li>
    <li><span>Logradouro, Um cliente pode conter vários logradouros</span></li>
    <li><span>Um cliente não pode se registrar duas vezes com o mesmo endereço de e-mail</span></li>
    <li><span>Deve ser possível criar, atualizar, visualizar e remover os logradouros</span></li>
	<li><span>O acesso à API deve ser aberto ao mundo, porém deve possuir autenticação e autorização</span></li>
	<li><span>A API terá um grande volume de requisições então tenha em mente que a preocupação com performance é algo que temos constantemente preocupação</span></li>
  </ul>
</ul>

## Funcionalidades

 Cadastro de Clientes, Cadastro de Logradouros, Autenticação

## Pré-requisitos

Caso for rodar o projeto localmente
<ul>
  <li> .NET Core SDK 8.0.4</li>
  <li> SQL SERVER caso deseja salvar no banco, porém para a plicação ficar mais dinamica para teste, estou tulizando SqlServer Em memória, ou seja fechando a aplicação os dados são apagados
  porém é possivel realizar todos os testes</li>
  <li> Visual Studio 2022 ou VS Code</li>
  <li>Se desejar rodar por contatiner Docker necessário ter o docer desktop</li>
  </ul>

## Como rodar a aplicação

Abra um terminal e clone o projeto: 

```
   git clone https://github.com/WillMarciano/TgsCadastroCliente.git
```

<b>Rodar projeto localmente via terminal os comandos necessários são</b>

```
   dotnet restore 
```
na pasta TgsCadastroCliente

![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/ac668f92-a9c4-4298-aa0d-7defeef7aaa1)


Após isso rodar os comandos

```
   cd CadastroCliente.Api
```

![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/35231cc5-41dc-4bda-a26c-05b318c8f149)

Rodar o comando

```
   dotnet run
```

![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/ff8bf084-dc91-4b31-aeb7-828b96a94be0)


Rodando aplicação por Docker, abra o terminal ate a pasta TgsCadastroCliente e rode o comando abaixo
Lembrando que é necessário ter o Docker Desktop


```
   docker build -t tgsclienteapi:dev -f CadastroCliente.Api/Dockerfile .
```


![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/4582cc82-8664-4c31-90f3-8ef80a2e179c)



Após isso rodar o comando baixo


```
   docker run -p 32180:8080 --rm --name CadastroCliente.API tgsclienteapi:dev
```


 

<b>Rodar projeto localmente via VS2022</b>
<ul>
  <li>Também é possível executar o projeto pelo visual studio 2022</li>
  <li>Abra a solution TgsCadastroCliente.sln</li>
  <li>Marque o projeto CadastroCliente.Api como startup project</li>
  <li>Execute o projeto com F5 ou Ctrl+F5</li>
  <li>Será exibido o Swagger da API com os endpoints criados</li>

  Lembrando que não é necessário configurar nada no Sql por estar utilizado sql in memory
</ul>
<br>

## Resumo


<ul>Os métodos da api necessitam de atutenticação, os tokens para essa autenticação são geradas após cadastrar um usuário e toda vez que or logar com esse usuário
os métodos são essas duas rotas



![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/6fc9b0ac-5070-4c34-aa97-5f7b64c20e87)


ao criar um usuário ou logar é gerado um token, esse token pelo swagger da para autenticar na aplicação e testar demais rotas

![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/f73d8861-6a27-4ac0-bd9e-d9dc3ac601db)


![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/85a705c5-49e7-4445-9e63-434ee0f8c750)


Exemplo chamada após autorizar 

![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/f1ffa955-07c2-461d-8635-6e8f85088237)



## A documentação do swagger em cada passo descreve o que cada rota é responsável

![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/920c0a81-8b72-4f68-8515-76118667f6d2)


## Arquitetura
<ul>
  <li>Arquitetura com separação de responsabilidade SOLID e Clean Code</li>
  <li>Design orientado por domínio (camadas e padrão de modelo de domínio)</li>
  <li>Eventos de domínio</li>
  <li>Notificação de domínio</li>
  <li>Repositório</li>
  <li>Injeção de dependência</li>
</ul>

## Arquitetura da Solução:
Back-end:
- API REST em C#: Utilizaremos o .NET 8 para criar uma API RESTful para manipulação de clientes e logradouros.
- Entity Framework Core: Para acesso ao banco de dados, o Entity Framework Core será utilizado como ORM para manipulação de dados.
- Autenticação e Autorização: Implementaremos autenticação JWT (JSON Web Token) para autenticar usuários e autorizar suas solicitações.
- Armazenamento de Imagens: As imagens do logotipo serão armazenadas no banco de dados utilizando a funcionalidade de armazenamento de arquivos binários do SQL Server.
- Performance: Utilizaremos técnicas de otimização de consulta, caching e escalabilidade horizontal para garantir alta performance.

## Decisões de Design:
- Separation of Concerns (SoC): A arquitetura seguirá o padrão DDD (Domain-Driven Design) para separar a lógica de negócios das camadas de apresentação e persistência de dados.
- Clean Architecture: Implementaremos uma arquitetura limpa, dividindo o sistema em camadas (Apresentação, Aplicação, Domínio e Infraestrutura), garantindo assim a separação de responsabilidades e facilitando a manutenção e testabilidade do sistema.


## Segurança
<ul>
  <li>Tokens de autorização com JWT Bearer</li>
</ul>

## Licença 

The [MIT License]() (MIT)


# FrontEnd para Testes

Para realizar os testes via frontend disponiibilzei um app em Angular 16 na qual a esperiencia para tal será mais fluída, necessário ter node para rodar os comandos.


baixe o repositorio do projeto

```
   https://github.com/WillMarciano/cadastroClienteApp.git
```

após isso va até a pasta cadastroClienteApp e rode os comandos abaixo


```
   npm i --f
   ng s --o
```


![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/fab1f927-b659-4fee-a066-cbbfa54410d4)


abaixo as telas do sistema que contempla todas as funções solicitadas

## Login

Após logar ou cadastrar usuário automaticamente ele já logado na aplicação

![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/bf3eb12f-bd01-4054-85c0-e5b595604aac)


## Cadastrar Usuario


![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/01896222-8612-4e7f-95a8-6fce8f12a5de)


## Tela Home

![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/f66ce1f4-6dd6-4a5d-8422-7cc404f37087)



## Cadastro do Cliente

Uma vez que é feito o cadastro do usuário via identity

![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/1e5e145c-8eca-47c6-9ce3-1896707f6051)


## Editar nome do Cliente

para acessar é só clicar linha que contém os dados do cliente nessa tela, é possivel atualizar o usuário ou a logotipo

![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/fc3b96a3-63bd-4d39-8415-f6161c69f193)


![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/f129a559-3fa8-44f9-8ab1-fc8ac68921c6)

Obs a logo é um blob salva no banco de dados conforme solicitada na lista trouxe os 10 primeiros caracteres apenás

## Cadastrar Logradouros 

Para acessar é só clicar no botão azul Visualizar os Endereços


![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/4dbc7aba-4d72-4646-bb4e-60ffbbf0c41e)


![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/310b03ba-cc01-4a2d-bb56-f3ead2b4718d)


![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/292c59d6-ca3e-4227-ad51-36d46bd57106)


![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/98dd6ff5-f32f-4c39-9bd0-0ddc88c68b8c)


![image](https://github.com/WillMarciano/TgsCadastroCliente/assets/34887614/3c95555f-a950-4370-878e-b664e34a7cfd)
