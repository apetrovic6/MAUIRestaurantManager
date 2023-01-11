using DevExpress.Xpo;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Repositories;

namespace RestaurantManagerClient.Services;

public class RestaurantService
{
    private Repository<Restaurant> RestaurantRepository { get; set; }
    
    public RestaurantService(Repository<Restaurant> restaurantRepository)
    {
        RestaurantRepository = restaurantRepository;
    }

    public List<Restaurant> GetAllRestaurants() 
    {
            return RestaurantRepository.GetAll().Result.ToList();
    }

    public Restaurant GetRestaurantById(int id)
    {
        return RestaurantRepository.GetById(id).Result;
    }
    
    public void AddNewRestaurant(Restaurant restaurant)
    {
        using (var uow = new UnitOfWork())
        {
            var newRes = new Restaurant(uow);
            newRes.Name = restaurant.Name;

            RestaurantRepository.Save(newRes, uow);
        }
    }

    public void UpdateRestaurant(Restaurant restaurant)
    {
        using var uow = new UnitOfWork();
        var itemToUpdate = uow.GetObjectByKey<Restaurant>(restaurant.Oid);
        
        if (itemToUpdate == null) return;

        itemToUpdate.Name = restaurant.Name;
        RestaurantRepository.Update(itemToUpdate, uow);
    }
    
    public void RemoveRestaurant(int id)
    {
        RestaurantRepository.Delete(id);
    }
}