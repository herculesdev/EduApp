
# EduApp
Um simples CRUD composta de Web API + GUI reativa empregando conceitos de SOLID, DDD e CQRS no backend

## 🚀 Começando
Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

### 📋 Pré-requisitos
* [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) ou superior
* [NodeJS + NPM / Yarn](https://nodejs.org/en/)
* [Git](https://git-scm.com/downloads)

### 🔧 Compilando e executando
Abra um terminal e clone este repositório em qualquer diretório da sua máquina utilizando o comando:
```
git clone https://github.com/herculesdev/EduApp.git
```
#### 1. Web API
Acesse a pasta com:
```
cd EduApp/src/EduApp
```
Restaure as dependências:
```
dotnet restore
```

Compile utilizando:
```
dotnet build
```

Rode os testes de unidade (caso queira):
```
dotnet test
```

Em seguida rode o servidor:
```
dotnet run --project API
```
Um resultado parecido com este será exibido
```
Compilando...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7071
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5071
info: Microsoft.Hosting.Lifetime[0]
```

Após isto, a Web API estará em pleno funcionamento. É possível visualizar a documentação e testar API abrindo a URL do Swagger
```
https://localhost:7071/swagger/index.html
```
![enter image description here](https://raw.githubusercontent.com/herculesdev/EduApp/master/images/swagger.png)

#### 2. Client (Frontend)
Acesse a pasta:
```
cd EduApp/src/EduAppClient
```
Obs: se necessário edite o arquivo services/Service.js e informe o base URL da Web API

Rode o servidor com
```
yarn serve
```
Algo semelhante será mostrado
```
 DONE  Compiled successfully in 1158ms                                                                          19:04:58
  App running at:
  - Local:   http://localhost:8080/
  - Network: http://192.168.0.110:8080/
  Note that the development build is not optimized.
  To create a production build, run npm run build.
```
Utilize o link do item "local" e acesse através do navegador para visualizar

![Imagem da home](https://github.com/herculesdev/EduApp/blob/master/images/home.png?raw=true)
![Imagem da lista](https://github.com/herculesdev/EduApp/blob/master/images/list.png?raw=true)

![Imagem do form](https://github.com/herculesdev/EduApp/blob/master/images/add.png?raw=true)

## 🛠️ Construído com
Ferramentas/tecnologias utilizadas para construção deste projeto

* [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) - Backend e Web API
* [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/) - Mapeamento Objeto-Relacional
* [Flunt](https://github.com/andrebaltieri/Flunt) - Validações de domínio
* [Moq](https://github.com/moq/moq) - Mocagem de dependencias nos testes de unidade
* [SQLite](https://www.sqlite.org/index.html) - Banco de Dados
* [VueJS](https://vuejs.org/) - Lib Javascript (Frontend)
* [Vuetify](https://vuetifyjs.com/) - Framework UI para o VueJS
* [Visual Studio Code](https://code.visualstudio.com/) - Editor de Código
* [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/launch/) - IDE C# / .NET
* [Swagger](https://swagger.io/) - Documentação e teste da API

## ☑️ O que eu adicionaria se tivesse mais tempo
* AutoMapper para mapeamento automático entre os commands, queries, responses e models
* Migrations para versionamento do banco de dados
* Camada extra "Application" para conter ViewModels, Services e o que mais fosse necessário para coordenar as chamadas ao domínio
* Promoveria alguns dados primitivos para ValueObject afim de melhorar a expressividade do modelo e isolar suas validações (CPF, RA, Email...)
* Extrair o acesso a dados da camada de infraestrutura
* Implementar o Unit Of Work para controle transacional
* Tornar os endpoints e algumas operações assíncronas
* Aumentar a cobertura dos testes (extendo-os aos entities, commands e queries e até mesmo aos repositories com banco de dados In-Memory

Obs: a princípio o projeto utilizaria o MySQL mas devido diversos problemas por eu ter utilizado o .NET 6 Preview, me vi obrigado a optar pelo SQLite, porém numa ocasião normal em que tivesse utilizando um produto estável isso não ocorreria. Tenho outro projeto utilizado o EF + MySQL que pode ser conferido [aqui](https://github.com/herculesdev/covid-app)

## 📚 Arquitetura
O arquitetura foi baseada em parte na Onion Architecture respeitando o princípio de que a modelagem é voltada ao domínio, dessa forma o mesmo é independente e não faz referência a recursos externos, muito pelo contrário, os dependências são invertidas e sempre partem da borda em direção ao centro (domínio).

![Onion Architecture](https://camo.githubusercontent.com/07832a2276c948e197784ba3d53a91b70da3906520b61e7488f70e0f9a6e9ddc/68747470733a2f2f7465616d736d696c65792e6769746875622e696f2f6173736574732f636c65616e2d6172636869746563747572652d646f746e65742e706e67)

Em conjunto também foi empregado o CQRS (Command Query Responsibility Segregation) para separar as operações de leitura e escrita na aplicação.

![enter image description here](https://miro.medium.com/max/1200/1*Fo70HYchxk2q2uEiHoV6Cw.png)
