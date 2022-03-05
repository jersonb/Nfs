#nullable disable

namespace GerenciaNf.Data.Model
{
    public class Item : Entidade
    {
        public Item()
        {
            NotasItens = new HashSet<NotaItem>();
        }

        public int ImpostoId { get; set; }
        public Imposto Imposto { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public ICollection<NotaItem> NotasItens { get; set; }
    }
}