# DevFreela

O DevFreela é uma API REST completa de um sistema de projetos de freelancers. Esta aplicação permite que freelancers e clientes colaborem em projetos de desenvolvimento de software. A plataforma oferece funcionalidades de gerenciamento de projetos, autenticação de usuários, cadastro de comentários e muito mais.

## Tecnologias Utilizadas

- ASP.NET Core com .NET 6
- Arquitetura Limpa
- Entity Framework Core
- CQRS (Command Query Responsibility Segregation)
- Padrão Repository
- Validação de APIs
- Autenticação e Autorização com JWT (JSON Web Tokens)
- Testes Unitários
- Mensageria com RabbitMQ

## Funcionalidades

- Cadastro, Listagem, Detalhes, Atualização e Remoção de Projetos
- Início e Conclusão de Projetos
- Cadastro de Comentários em Projetos
- Cadastro, Detalhes e Login de Usuários

## Como Contribuir

Se você deseja contribuir para o desenvolvimento do DevFreela, siga as etapas abaixo:

1. Faça um fork deste repositório.
2. Crie uma branch para a sua feature (`git checkout -b minha-feature`).
3. Faça as alterações desejadas no código.
4. Commit suas alterações (`git commit -m 'Adiciona minha nova feature'`).
5. Faça um push para a branch (`git push origin minha-feature`).
6. Abra um Pull Request neste repositório.

## Como Executar o Projeto

Siga as etapas abaixo para executar o projeto localmente:

1. Clone este repositório para a sua máquina local.
2. Abra o projeto em sua IDE preferida (por exemplo, Rider, Visual Studio, Visual Studio Code).
3. Configure a conexão com o banco de dados no arquivo `appsettings.json`.
4. No terminal, navegue até a pasta raiz do projeto e execute os seguintes comandos:

 ```console
   dotnet restore
   dotnet ef database update
   dotnet run
 ```
   

5. Acesse a aplicação em `https://localhost:5001` em seu navegador.

## Licença

Este projeto é licenciado sob a [Licença MIT](LICENSE).