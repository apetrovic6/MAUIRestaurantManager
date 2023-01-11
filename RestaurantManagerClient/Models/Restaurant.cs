using DevExpress.Xpo;

namespace RestaurantManagerClient.Models;


public class Restaurant : BaseModel
{
    private string _Name;
    public Restaurant(Session session) : base(session) { }
    public Restaurant() {}

    public string Name
    {
        get => _Name;
        set => SetPropertyValue(nameof(Name), ref _Name, value);
    }

    [Association("Menus-Restaurant")] public XPCollection<Menu> Menus
    {
        get => GetCollection<Menu>(nameof(Menus));
    }
}