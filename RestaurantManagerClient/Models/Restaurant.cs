using DevExpress.Xpo;

namespace RestaurantManagerClient.Models;

[Persistent]
public class Restaurant : BaseModel
{
    [Size(50)]
    public string Name { get; set; }
}