#nullable disable

namespace GerenciaNf.Data.Model
{
    public class NotaItem : Entidade
    {
        public int NotaId { get; set; }
        public virtual NotaFiscal Nota { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}