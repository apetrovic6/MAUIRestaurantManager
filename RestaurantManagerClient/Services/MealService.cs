using DevExpress.Xpo;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Repositories;

namespace RestaurantManagerClient.Services;

public class MealService
{
    private Repository<Meal> MealRepository { get; set; }

    public MealService(Repository<Meal> mealRepository)
    {
        MealRepository = mealRepository;
    }

    public List<Meal> GetAllMeals()
    {
        return MealRepository.GetAll().Result.ToList();
    }

    public Meal GetMealById(int id)
    {
        return MealRepository.GetById(id).Result;
    }

    public void AddNewMeal(Meal newMeal)
    {
        using (var uow = new UnitOfWork())
        {
            var meal = new Meal(uow);
            meal.Name = newMeal.Name;

            MealRepository.Save(meal, uow);
        }
    }

    public void UpdateMeal(Meal meal)
    {
        using (var uow = new UnitOfWork())
        {
            var itemToUpdate = uow.GetObjectByKey<Meal>(meal.Oid);
            
            itemToUpdate.Name = meal.Name;
            MealRepository.Update(itemToUpdate, uow);
        }
    }

    public void DeleteMeal(int id)
    {
        MealRepository.Delete(id);
    }
}