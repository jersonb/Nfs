#nullable disable

namespace GerenciaNf.Data.Model
{
    public class NotaFiscal : Entidade
    {
        public NotaFiscal()
        {
            NotasItens = new HashSet<NotaItem>();
        }

        public string Numero { get; set; }
        public int EmissorId { get; set; }
        public Empresa Emissor { get; set; }
        public int DestinatarioId { get; set; }
        public Empresa Destinatario { get; set; }
        public int ImpostoId { get; set; }
        public Imposto Imposto { get; set; }
        public ICollection<NotaItem> NotasItens { get; set; }
    }
}