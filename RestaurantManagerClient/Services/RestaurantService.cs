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
         return RestaurantRepository.GetAll(new UnitOfWork()).Result.ToList();
    }

    public Restaurant GetRestaurantById(string id)
    {
        return RestaurantRepository.GetById(id).Result;
    }
    
    public void AddNewRestaurant(Restaurant restaurant)
    {
        RestaurantRepository.Save(restaurant);
    }

    public void UpdateRestaurant(Restaurant restaurant)
    {
        using var uow = new UnitOfWork();
        var itemToUpdate = uow.GetObjectByKey<Restaurant>(restaurant.Id);
        
        if (itemToUpdate == null) return;

        itemToUpdate.Name = restaurant.Name;
        RestaurantRepository.Update(itemToUpdate, uow);
    }
    
    public void RemoveRestaurant(string id)
    {
        RestaurantRepository.Delete(id);
    }
}