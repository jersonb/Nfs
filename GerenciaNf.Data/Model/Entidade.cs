#nullable disable

namespace GerenciaNf.Data.Model
{
    public class Entidade
    {
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public bool IsDeleted { get; set; }
    }
}