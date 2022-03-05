#nullable disable

namespace GerenciaNf.Data.Model
{
    public class Empresa : Entidade
    {
        public Empresa()
        {
            NotasEmissor = new HashSet<NotaFiscal>();
            NotasDestinatario = new HashSet<NotaFiscal>();
        }

        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public ICollection<NotaFiscal> NotasEmissor { get; set; }
        public ICollection<NotaFiscal> NotasDestinatario { get; set; }
    }
}