using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public abstract class EntityBase
    {
        [Key]
        public virtual uint Id { get; set; }
    }
}