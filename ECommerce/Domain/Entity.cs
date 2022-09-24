using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain
{
public class Entity
{
    [Key]
    public Guid Id {
        get;
        set;
    } = Guid.NewGuid();
}
}
