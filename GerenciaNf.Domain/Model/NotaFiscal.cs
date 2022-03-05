#nullable disable

using GerenciaNf.Domain.Model.ValueObject;

namespace GerenciaNf.Domain.Model
{
    public class NotaFiscal
    {
        public NumeroNf Numero { get; init; }
        public Empresa Emissor { get; init; }
        public Empresa Destinatario { get; init; }
        public Imposto Imposto { get; init; }
        public Itens Itens { get; init; }
    }
}