# OESP(Orchestrators event sourcing project)
### Sistema de controle de eventos dos orquestradores

## Sobre o projeto
* Desenvolvido para monitorar aplicações de motores, as aplicações cadastradas
vão sendo monitoradas por eventos definidos por intervalo de tempo.
Caso alguma aplicação monitorada saia do ar o sistema envia um email
para evidenciar o caso além de salvar um log de "event sourcing" em uma base
de dados.

## O que esse sistema pode fazer ?
* Verificar o estado de aplicações
* Validar o estado de aplicações
* Enviar email's de estado
* Controlar a fonte de eventos (Event Sourcing)
* Utilizar serviços hospedados em background para validar as aplicações

## Tecnologias
* dotNet 5
* C#
* ASP.NET MVC
* Entity Framework Core 5
* Microsoft Tests
* SMTP Service
* Hosted Services

## Modelagem e estrutura
* DDD 
* CQRS
* Event Sourcing
* Repository Patterns
* Service Patterns
* SOLID
* Clean Code
