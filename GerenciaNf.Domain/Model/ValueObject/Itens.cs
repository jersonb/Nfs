namespace GerenciaNf.Domain.Model.ValueObject
{
    public class Itens : List<Item>
    {
        public Itens(IEnumerable<Item> collection) : base(collection)
        {
        }
    }
}