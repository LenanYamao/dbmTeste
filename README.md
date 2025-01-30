# DBM Teste

![GitHub repo size](https://img.shields.io/github/repo-size/iuricode/README-template?style=for-the-badge)
![GitHub language count](https://img.shields.io/github/languages/count/iuricode/README-template?style=for-the-badge)

> Teste técnico para DBM

## 💻 Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:

- Visual Studio
- .NET 8
- Docker
- Postgresql

## 🚀 Instalando <nome_do_projeto>

Windows:

```
- Clone este repositório
- Abra o console (iniciar -> cmd)
- Navegue até a pasta em que o repositório foi clonado (cd caminho/para/repositorio)
- Execute o comando docker-compose pull
- Abra o projeto no Visual Studio
- Expanda o projeto TestDbm e abra o arquivo appsettings.json
- Altere os valores username e password para os dados de acesso ao postgres
  - Caso tenha alterado a porta padrão, altere o valor Port
- Expanda o projedo docker-compose e abra o arquivo docker-compose.yml
- Altere os valores username e password da connection string para os dados de acesso ao postgres
- Selecione o profile docker-compose
- Rode o projeto
- Todas as migrações e testes são executados quando o projeto é executado
```

## ☕ CRUD Produtos

```
Para acessar o CRUD acesse a url:
http://localhost:5002/Produto
No CRUD é possivel adicionar, editar e remover produtos.
```

## Docker (informações das imagens)

```
Docker está utilizando o docker-compose para compartilhamento de dados entre projetos.
Executar o comando:
docker-compose pull
Busca todas as imagens necessárias do docker hub
Postgres está sendo executado na porta 5432 e utilizando healthcheck para validar se está executando corretamente.
A API valida se o postgres rodou corretamente antes de executar (postgres marcado como dependencia), tambem utiliza uma connection string para definir a conexão e roda nas portas 5000 e 5001
O Front está rodando nas portas 5002 e 5003 e depende da api
```

## Documentação

Documentação do projeto pode ser acessada no link:
https://docs.google.com/document/d/1cTgdxn9lseBK94cdOCUOwDuTQaB26r7a7p68UfCYcwg/edit?usp=sharing