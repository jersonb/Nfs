#nullable disable

namespace GerenciaNf.Domain.Model
{
    public class Imposto
    {
        public string Descricao { get; init; }
        public decimal Aliquota { get; init; }
        public decimal BaseCalculo { get; init; }
    }
}