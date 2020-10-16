# Documentação do código

A estrutura da aplicação consiste em uma solução (DashboardCovid.sln) formada por cinco projetos, sendo estes:

* DashboardCovid.csproj: Possui a arquitetura Web MVC do sistema, responsável por realizar a comunicação com o usuário;
* DashboardCovid.Data.csproj: Possui as classes de dados responsáveis por acessar uma API externa para obtenção dos países e o banco de dados local, o SQLite. Ademais, possui a configuração do banco de dados local, em que é criado um contexto e classes de entidade que representa os dados na tabela e no retorno da API;
* DashboardCovid.Domain.csproj: Possui classes de domínio (services) responsáveis por tratar os dados e aplicar regras de negócio, como validações ao CRUD. Além disso, possui classes para objetos de transferências de dados (Data Transfer Objects - DTOs), os quais permitem a comunicação de dados entre os projetos;
* DashboardCovid.Infra.CrossCutting.IoC.csproj: Responsável por configurar a injeção de dependências, registrando as classes de serviço, Domain, e de repositórios, Data;
* DashboardCovid.Shared.csproj: Possui classes que auxiliam na configuração da aplicação e são compartilhadas entre os projetos.

Nesse sentido, estruturou-se o diagrama abaixo a fim de ilustrar as referências entre os projetos, explicitando suas comunicações:
