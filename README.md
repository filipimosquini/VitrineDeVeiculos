## VitrineDeVeiculos

 O projeto simula uma plataforma de listagem de veículos.

## Execução

Para executar o projeto é requerido que se tenha o docker instalado na máquina.

![image](https://github.com/filipimosquini/VitrineDeVeiculos/assets/5280221/cc5b2ef7-7bd9-46a2-8560-a64e946d33ad)

Deve-se navegar até este diretório aonde estão listadas as pastas do projeto e executar o comando docker-compose up

Logo apos serem criados os containers do projeto, deve-se acessar a página http://localhost:4200.

## Execução (Alternativa)

Caso não for possivel executar o projeto via Docker. recomenda-se usar o Visual Studio 2022 para a execução do backend
e o Visual Code para a execução do Frontend.

# Requisitos para a execução do projeto

1. Frontend: Ter instalado o Node JS e o Angular na versão 16.
2. Backend: Ter instalado o .Net 7 SDK.
3. Banco de dados: Instalar o banco de dados MySQl realizar as seguintes configurações:

Post: localhost
Porta: 3306
Usuário: root e não colocar senha.

# Passo a passo:

Frontend:
Após instalar as bibliotecas mencionadas acima, deve-se executar o comando npm install para instalar as dependências do projeto
e o comando ng s para executar o frontend.

Backend:
Após baixar o projeto backend, clicar com o botão direito do mouse no projeto Backend.Api e selecionar a opção Definir como projeto de inicialização (Show as startup project).

## Frameworks e Ferramentas utilizados

1. Linguagem de programação C# (Backend) com webapi na plataforma .NET 7
2. Angular+ na versão 16 (Frontend)
3. Bootstrap
4. AspNetIdentity
5. Entity Framework Core
6. Banco de dados MySQL
7. Docker

## Observações

* As imagens salvas deste projeto serão persistidas em uma pasta na API somente para fins de demonstração. Para uma aplicação em produção
pensando em escalabilidade e boas práticas, estas imagens deve ser salvas em um serviço dedicado como CDNs ou um repositório BLOB ou até
mesmo um servidor de arquivos local.

* Este projeto usa o AspNetIdentity para gerenciar os usuários mas propositalmente ele foi configurado de forma básica para somente cadastrar o usuário.
As claims necessárias para uso da API são passadas ao gerar o Token de autenticação.


## Melhorias futuras

1. Frontend: 

* Implementação de paginação nas grids da vitrine e do cadastro de veículos
* Implementação de um spinner para sinalizar que uma requisição está em aandamento.
* Implementação de tela para manter o cadastro dos usuários
 
2. Backend

* Evolução dos endpoints de usuário para ações como: edição, exclusão, bloqueio e permissionamento.
