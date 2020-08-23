# Avalição Função Sistemas
O exame está organizado da seguinte forma:
* Pasta scripts contém os scripts de banco de dados
## Solution

Na solution foram criados 2 novos projetos:
* Ifraestrutura : **Separei a camada de dados em um projeto a parte utilizando EF 6.4**
* Utilidades: coloquei a validação de CPF nesta pasta  
## Pacotes adicionados

* Ef 6.4
* Fluentvalidadion.net
* Jquery.InputMask
## Mudanças

* Acrescentada a pasta Validators Na camada FI.AtividadeEntrevista, onde foram colocados os arquivos de validação com FluentValidation.net
* Acrescentada a classe Beneficiario.cs na pasta DML
> Obs. Não foi criado BoBeneficiario nem foram incrementados novos métodos na BoCliente, pois foi utilizada técnica de "Repositórios"
> Onde Métodos relacionados ao CRUD são colocados nessa classe, por isso, na camada Infraestrutura foi criada a classe EntrevistaRepositório

## Camada Infraestrutura

Camada de dados com as classes:
* EntrevistaDbContext: Responsável por modelar o Banco de dados e disponibilizar as tabelas e seus conteúdos em forma de coleção, 
facilitando o entendimento do negócio.
* Migrations: Log de alterações estruturais das tabelas
## Camada de Apresentacao

Foi mantida compatibilidade visual e strutural do projeto incluindo utilização de bundles para inclusão dos novos arquivos de script:
* FI.Beneficiarios.js: Responsável por pegar os dados da view "Create" e envivar via ajax um POST para a Action Create da controller "Beneficiário"
* FI.ListBeneficiarios: Responsável por montar o grid de Beneficiários e enviar via ajax a Action de Delete de Beneficiario, Para a edição do 
beneficiário, escolhi apenas preencher de volta na view os dados do beneficiário selecionado e deletar do banco, assim o comportamento fica semlhante
a Edição, mas pupou bastante tempo na programação.
## Agradecimentos

Obrigado, pela oportunidade espero que gostem do trabalho.
