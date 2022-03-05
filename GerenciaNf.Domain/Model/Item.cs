#nullable disable

namespace GerenciaNf.Domain.Model
{
    public class Item
    {
        public Imposto Imposto { get; init; }
        public decimal Valor { get; init; }
        public string Descricao { get; init; }
    }
}