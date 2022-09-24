namespace ECommerce.Domain.Models
{
public class Customer : Entity
{
    public string Name {
        get;
        set;
    }
    public DateTime BirthDate {
        get;
        set;
    }
    public string Email {
        get;
        set;
    }
    public string Password {
        get;
        set;
    }
    public DateTime? DeletedAt {
        get;
        set;
    }

    public ICollection<Address> Addresses {
        get;
        set;
    }
}
}
