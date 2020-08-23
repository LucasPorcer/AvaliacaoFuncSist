# Avaliação Desenvolvedor Pleno - Função Sistemas

Na solution foram criados 2 novos projetos :
* FI.WebAtividadeEntrevista.CrossCutting : Camada responsável por métodos Uteis como validação de CPF entre outros.
* FI.WebAtividadeEntrevista.InfraData: Camada responsável por retirar dados de determinada fonte, seja ela banco de dados, microserviço, api, etc. 


## Pacotes Nuget adicionados

* Dapper
* Fluentvalidadion.net
* Jquery.InputMask


## Novos Projetos:

Foram criados duas novos projetos seguindo o modelo DDD afim de demonstrar os conhecimentos nesta estrutura. 
* Para o projeto CrossCutting foi adicionado a classe validadora de CPF.

* Para o projeto InfraData foi adicionado o repositório do projeto, usando o Nuget Dapper, afim de deixar mais visivel e fácil a manutenção e leitura do código,
também para o projeto InfraData foi adicionado o tratamento de transactions, para obter segurança ao relizar inserts e deletes na base de dados.


## Camada WebAtividadeEntrevista

Para a interface Web, foram feitas e adicionadas melhorias de validação, fluxo da tela e tratamento de exceções, além das tarefas listadas na avaliação.


Deus abençõe a todos.

