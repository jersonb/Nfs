namespace GerenciaNf.Domain.Model.ValueObject
{
    public struct NumeroNf
    {
        public NumeroNf(string valor)
        {
            Valor = Limpar(valor);
            ValorFormatado = Formatar(Valor);
        }

        private static string Formatar(string valor)
        {
            return long.Parse(valor).ToString(@"##\.###\.###\-##");
        }

        private static string Limpar(string valor)
        {
            valor = new string(valor.Where(x => char.IsLetterOrDigit(x)).ToArray());

            if (valor.Length < 1)
                throw new ArgumentException("Erro", valor);

            return valor;
        }

        public string Valor { get; }
        public string ValorFormatado { get; }
    }
}