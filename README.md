# DIO - Trilha .NET - API e Entity Framework
www.dio.me

## Desafio de projeto
Para este desafio, está sendo colocado em prática os conhecimentos adquiridos nos cursos sobre Entity Framework e front-end com ASP.NET MVC.

## Contexto
Será construido um sistema gerenciador de tarefas, onde poderá ser cadastrada uma lista de tarefas que permitirá organizar melhor uma rotina.

Essa lista de tarefas terá um CRUD, ou seja, deverá permitir as operações de obter os registros, criar, salvar e deletar esses registros.

## Solução desenvolvida
O sistema de tarefas foi implementado usando o Entity Framework + ASP.NET Core MVC, além de SQL Server como solução de banco de dados.

A solução desenvolvida, além de fornecer as operações básicas de um CRUD, também fornece buscas baseadas em nome (título da tarefa), id, data de acordo com o idioma do sistema (na caixa de busca será solicitado data e hora, porém serão retornadas todas as tarefas que correspondem ao dia procurado) e busca por status.
