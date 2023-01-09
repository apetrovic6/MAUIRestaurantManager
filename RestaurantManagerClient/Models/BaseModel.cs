using DevExpress.Xpo;

namespace RestaurantManagerClient.Models;

public class BaseModel
{
    [Key]
    public string Id { get; set; }
}