# Documentação do código

A estrutura da aplicação consiste em uma solução (DashboardCovid.sln) formada por cinco projetos, sendo estes:

* DashboardCovid.csproj: Possui a arquitetura Web MVC do sistema, responsável por realizar a comunicação com o usuário;
* DashboardCovid.Data.csproj: Possui as classes de dados responsáveis por acessar uma API externa para obtenção dos países e o banco de dados local, o SQLite. Ademais, possui a configuração do banco de dados local, em que é criado um contexto e classes de entidade que representa os dados na tabela e no retorno da API;
* DashboardCovid.Domain.csproj: Possui classes de domínio (services) responsáveis por tratar os dados e aplicar regras de negócio, como validações ao CRUD. Além disso, possui classes para objetos de transferências de dados (Data Transfer Objects - DTOs), os quais permitem a comunicação de dados entre os projetos;
* DashboardCovid.Infra.CrossCutting.IoC.csproj: Responsável por configurar a injeção de dependências, registrando as classes de serviço, Domain, e de repositórios, Data;
* DashboardCovid.Shared.csproj: Possui classes que auxiliam na configuração da aplicação e são compartilhadas entre os projetos.

Nesse sentido, estruturou-se o diagrama abaixo a fim de ilustrar as referências entre os projetos, explicitando suas comunicações:

![image](https://user-images.githubusercontent.com/26631860/96199289-8852ba00-0f2d-11eb-97e9-dd245f7b2da9.png)

Por sua vez, o próximo diagrama representa a comunicação entre a View e as classes de cada um dos projetos mencionados anteriormente. As entidades transferem dados do repositório para o Service, então, os nomes entre as setas (em branco internos a uma caixa cinza) representam os tipos de classes que transferem esses dados entre as camadas. Data Transfer Objects (DTOs) transferem dados da classe Service para as Controllers e, por sua vez, as classess Models transferem dados entre as Controllers e as Views. Observe abaixo:

<p align="center">
  <img src="https://user-images.githubusercontent.com/26631860/96199780-a7058080-0f2e-11eb-8b03-a0fc5cf39454.png">
</p>
