using DevExpress.Xpo;

namespace RestaurantManagerClient.Models;

public class Meal : BaseModel
{
    public  Meal(Session session) : base(session) {}

    public Meal() { }

    private string _Name;

    public string Name
    {
        get => _Name;
        set => SetPropertyValue(nameof(Name), ref _Name, value);
    }

    [Association("Meal-Menu")]
    public XPCollection<Menu> Menus
    {
        get => GetCollection<Menu>(nameof(Menus));
    }
}