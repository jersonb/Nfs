namespace GerenciaNf.Domain.Model.ValueObject
{
    public struct Cnpj
    {
        public Cnpj(string valor)
        {
            Valor = Limpar(valor);
            ValorFormatado = Formatar(Valor);
        }

        private static string Formatar(string valor)
        {
            return long.Parse(valor).ToString(@"00\.000\.000\/0000\-00");
        }

        private static string Limpar(string valor)
        {
            valor = new string(valor.Where(x => char.IsNumber(x)).ToArray());

            if (valor.Length != 14)
                throw new ArgumentException("Erro", valor);

            return valor;
        }

        public string Valor { get; }
        public string ValorFormatado { get; }
    }
}