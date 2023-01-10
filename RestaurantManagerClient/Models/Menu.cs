using DevExpress.Xpo;

namespace RestaurantManagerClient.Models;

[Persistent]
public class Menu : BaseModel
{
    [Size(50)]
    public string Name { get; set; }

    [Association("Menus-Restaurant")] 
    public Restaurant Restaurant { get; set; }
}