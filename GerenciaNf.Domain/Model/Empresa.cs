#nullable disable

using GerenciaNf.Domain.Model.ValueObject;

namespace GerenciaNf.Domain.Model
{
    public class Empresa
    {
        public string Nome { get; init; }
        public Cnpj Cnpj { get; init; }
    }
}