using Cafeteria.Modelos;

namespace Cafeteria.Dados;

public static class Cardapio
{
    public static List<Produto> Produtos = new List<Produto>
    {
        new Produto { Nome = "Espresso", Categoria = "Cafés", Preco = 6.50m },
        new Produto { Nome = "Cappuccino", Categoria = "Cafés", Preco = 9.00m },
        new Produto { Nome = "Café com leite", Categoria = "Cafés", Preco = 7.50m },
        new Produto { Nome = "Mocha", Categoria = "Cafés", Preco = 11.00m },
        new Produto { Nome = "Cold Brew", Categoria = "Cafés", Preco = 12.00m },
        new Produto { Nome = "Pão de queijo", Categoria = "Salgados", Preco = 5.00m },
        new Produto { Nome = "Croissant", Categoria = "Salgados", Preco = 8.50m },
        new Produto { Nome = "Bolo de cenoura", Categoria = "Doces", Preco = 9.50m },
        new Produto { Nome = "Brownie", Categoria = "Doces", Preco = 10.00m },
    };
}
