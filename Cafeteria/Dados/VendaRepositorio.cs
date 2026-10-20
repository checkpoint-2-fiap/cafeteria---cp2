using System.Text.Json;
using Cafeteria.Modelos;

namespace Cafeteria.Dados;

// Guarda as vendas num arquivo vendas.json ao lado do executável
public static class VendaRepositorio
{
    static string arquivo = Path.Combine(AppContext.BaseDirectory, "vendas.json");

    public static List<Venda> Listar()
    {
        if (!File.Exists(arquivo))
        {
            return new List<Venda>();
        }

        string json = File.ReadAllText(arquivo);
        return JsonSerializer.Deserialize<List<Venda>>(json) ?? new List<Venda>();
    }

    public static void Salvar(Venda venda)
    {
        var vendas = Listar();

        venda.Numero = vendas.Count == 0 ? 1 : vendas.Max(v => v.Numero) + 1;
        venda.Data = DateTime.Now;
        vendas.Add(venda);

        var opcoes = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(arquivo, JsonSerializer.Serialize(vendas, opcoes));
    }
}
