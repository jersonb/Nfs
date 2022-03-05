#nullable disable

namespace GerenciaNf.Data.Model
{
    public class Imposto : Entidade
    {
        public string Descricao { get; set; }
        public decimal Aliquota { get; set; }
        public decimal BaseCalculo { get; set; }
    }
}