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

    public void AddNewRestaurant(Restaurant restaurant)
    {
        RestaurantRepository.Save(restaurant);
    }
    
}