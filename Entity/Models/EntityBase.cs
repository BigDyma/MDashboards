using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public abstract class EntityBase
    {
        [Key]
        public virtual long Id { get; set; }
    }
}