# Cafeteria Dev

Sistema desktop de vendas para uma cafeteria, feito em C# com Windows Forms (.NET 8).
Projeto do Checkpoint 2 de C# Development, FIAP.

## Telas

* **Splash**: tela de abertura com barra de carregamento.
* **Menu**: navegação para a venda, o relatório e saída.
* **Venda do Café**: escolhe produtos do cardápio, monta o pedido, informa cliente e forma de pagamento e finaliza a venda.
* **Relatório de Vendas**: lista as vendas por período, mostra os itens de cada venda, o faturamento e o ticket médio.

## Como executar

1. Instalar o Visual Studio 2022 com a carga de trabalho "Desenvolvimento para desktop com .NET" (SDK do .NET 8).
2. Abrir o arquivo `Cafeteria.sln`.
3. Definir `Cafeteria` como projeto de inicialização e apertar F5.

As vendas ficam salvas no arquivo `vendas.json`, na mesma pasta do executável.

## Estrutura

```
Cafeteria.sln
integrantes.txt
Cafeteria/
    Program.cs
    Modelos/    Produto, ItemVenda, Venda
    Dados/      Cardapio, VendaRepositorio
    Telas/      SplashForm, MenuForm, VendaForm, RelatorioForm, Estilo
```

## Fluxo de trabalho no Git

* Branches: `main` (versão final) e `dev` (integração).
* Cada tarefa em uma branch `feature/...` criada a partir da `dev`.
* Commits semânticos (`feat`, `fix`, `style`, `refactor`, `docs`, `chore`), no mínimo 3 por tarefa para cada integrante.
* Pull Request para a `dev` ao finalizar cada tarefa, revisado pelo Tech Lead.
