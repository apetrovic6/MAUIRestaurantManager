using DevExpress.Xpo;

namespace RestaurantManagerClient.Models;

[NonPersistent]
public class BaseModel : XPObject
{
    public BaseModel(Session session) :base (session){}
    public BaseModel(){}
    
    private string _Id;
    
    public string Id
    {
        get => _Id;
        set => SetPropertyValue(nameof(Id), ref _Id, value);
    }
}