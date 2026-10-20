using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Cafeteria.Modelos;

public class Venda
{
    public int Numero { get; set; }
    public DateTime Data { get; set; }
    public string Cliente { get; set; } = "";
    public string Pagamento { get; set; } = "";

    [Browsable(false)]
    public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();

    [JsonIgnore]
    public int QuantidadeItens => Itens.Sum(i => i.Quantidade);

    [JsonIgnore]
    public decimal Total => Itens.Sum(i => i.Subtotal);
}
