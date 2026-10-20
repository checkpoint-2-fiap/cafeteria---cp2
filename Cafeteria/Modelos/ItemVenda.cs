using System.Text.Json.Serialization;

namespace Cafeteria.Modelos;

public class ItemVenda
{
    public string Nome { get; set; } = "";
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }

    [JsonIgnore]
    public decimal Subtotal => Quantidade * PrecoUnitario;
}
