# ERP Backend
Backend do ERP de propósito geral desenvolvido a título de estudo, mas com possibilidade de implantação em ambiente produtivo no futuro (quem sabe....)

## 🚀 Começando
Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

### 📋 Pré-requisitos
* [.NET 7 ou superior](https://dotnet.microsoft.com/download/dotnet/7.0)
* [PostgreSQL 15 ou superior](https://www.postgresql.org/download/)
* [Última Versão do GIT](https://git-scm.com/downloads)

### 🔧 Clonar, configurar e executar

#### 1. Obtendo uma cópia e configurando

Abra um terminal e **clone** este repositório em qualquer diretório da sua máquina (recomendado `c:\` no Windows) utilizando o comando:
`git clone https://github.com/herculesdev/erp-backend.git`

Acesse o diretório do projeto em:
`erp-backend/src/ERP.API` 

Localize e abra o arquivo de configuração:
`appsettings.Development.json` 

Altere a seção **ConnectionStrings** com as informações de conexão com o PostgreSQL:
```json
"ConnectionStrings": {
"PgSql": "Host=IP_DO_BANCO;Database=NOME_DO_BANCO;Username=USUARIO;Password=SENHA;Include Error Detail=True;"
}
```

#### 2. Subindo o Backend
**Observação:** os passos abaixo foram realizados no terminal, mas caso utilize um ambiente de desenvolvimento integrado como o **Microsoft Visual Studio** ou **JetBrains Rider IDE**, basta abrir a solução ``ERP.sln`` que está na pasta **src** e executar o projeto ``ERP.API``

No terminal, acesse a pasta do código fonte do projeto com:

```bash
cd erp-backend/src
```
Restaure as dependências:
```
dotnet restore
```

Compile utilizando:
```
dotnet build
```

Rode os testes de unidade (caso queira,):
```
dotnet test
```

Em seguida rode o servidor:
```
dotnet run --project .\ERP.API\
```
Um resultado parecido com este será exibido
```
Compilando...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5298
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\erp-backend\src\ERP.API
```

Após isto, a Web API estará em pleno funcionamento. É possível visualizar a documentação e testar API abrindo a URL exibida na saída do comando anterior na rota "swagger"
```
https://localhost:5298/swagger
```
![image](https://user-images.githubusercontent.com/17711118/226072686-72dbdc45-b158-4661-a6b7-0998ff53e07a.png)

#### 3. Criando dados de teste
Para criar dados de teste (grupo de empresas, empresas, usuário e permissões) faça uma requisição POST para **v1/admin/data/create** conforme imagem abaixo:

![image](https://user-images.githubusercontent.com/17711118/226073034-bc663814-6b70-4059-9e8c-ac2f17106dff.png)

Após isso será possível autenticar-se na aplicação com as credenciais abaixo:
**Usuário:** admin 
**senha:** admin123

**Observação:** existem dois tipos de autenticação
1. Autenticação inicial: Dá-se através do envio do usuário e senha, tendo como resposta um **token** que te permite **listar as empresas** que o usuário logado tem acesso

3. Autenticação na empresa: permite de fato realizar todas as operações relacionadas aos dados pertencentes a uma empresa que o usuário tem acesso. **É necessário já estar autenticado** com o token da autenticação inicial, e informar **ID do grupo da empresa**, bem como o próprio **ID da empresa**. Tem como resposta um **token** que te **permite alterar dados naquela empresa**

## 🛠️ Construído com
Ferramentas/tecnologias utilizadas para construção deste projeto

* [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) - Backend e Web API
* [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/) - Mapeamento objeto-relacional
* [Flunt](https://github.com/andrebaltieri/Flunt) - Validações de domínio
* [PostgreSQL](https://www.postgresql.org) - Banco de dados relacional
* [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/launch/) - IDE C# / .NET
* [Swagger](https://swagger.io/) - Documentação e teste da API

## 📚 Arquitetura
O arquitetura foi baseada nos princípios da Clean Architecture respeitando o conceito de modelagem voltada ao domínio, dessa forma o mesmo é independente e não faz referência a recursos externos, muito pelo contrário, os dependências são invertidas e sempre partem da borda em direção ao centro (domínio).

![Onion Architecture](https://camo.githubusercontent.com/07832a2276c948e197784ba3d53a91b70da3906520b61e7488f70e0f9a6e9ddc/68747470733a2f2f7465616d736d696c65792e6769746875622e696f2f6173736574732f636c65616e2d6172636869746563747572652d646f746e65742e706e67)

Em conjunto também foi empregado o CQRS (Command Query Responsibility Segregation) para separar as operações de leitura e escrita na aplicação representado através dos **commands** e **queries** da **camada de aplicação**.

![enter image description here](https://miro.medium.com/max/1200/1*Fo70HYchxk2q2uEiHoV6Cw.png)

