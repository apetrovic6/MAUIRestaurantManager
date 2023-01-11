using DevExpress.Xpo;

namespace RestaurantManagerClient.Models;


public class Menu : BaseModel
{
    private string _Name;
    
    public string Name
    {
        get => _Name;
        set => SetPropertyValue(nameof(Name), ref _Name, value);
    }


    private Restaurant _Restaurant;

    [Association("Menus-Restaurant"), Aggregated]
    public Restaurant Restaurant
    {
        get => _Restaurant;
        set => SetPropertyValue(nameof(Restaurant), ref _Restaurant, value);
    }

    [Association("Meal-Menu")]
    public XPCollection<Meal> Meals
    {
        get => GetCollection<Meal>(nameof(Meals));
    }

    public Menu(Session session) : base(session) { }
    public Menu() {}
}