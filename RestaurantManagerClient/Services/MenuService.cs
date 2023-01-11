using DevExpress.Xpo;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Repositories;

namespace RestaurantManagerClient.Services;

public class MenuService
{
    private Repository<Menu> MenuRepository { get; set; }
    
    public MenuService(Repository<Menu> menuRepository)
    {
        MenuRepository = menuRepository;
    }

    public List<Menu> GetAll()
    {
        // using (var uow = new UnitOfWork())
        // {
        //     return uow.Query<Menu>().Where(x => x.Restaurant.Id == "ab8dbb32-29a2-48fc-8035-43b22b8356d9")
        //         .ToList();
        // }
        return MenuRepository.GetAll(new UnitOfWork()).Result.ToList();
    }

    public Menu GetMenuById(int id)
    {
        return MenuRepository.GetById(id).Result;
    }

    public void AddNewMenu(string newName, string resId)
    {
        using (var uow = new UnitOfWork())
        {
            var restaurant = uow.GetObjectByKey<Restaurant>(resId);

            Menu menu = new();
            
            menu.Id = Guid.NewGuid().ToString();
            menu.Name = newName;
            menu.Restaurant = restaurant;
            MenuRepository.Save(menu, uow);
        }
        
    }

    public void UpdateMenu(Menu menu)
    {
        using var uow = new UnitOfWork();
        var itemToUpdate = uow.GetObjectByKey<Menu>(menu.Id);
        
        if (itemToUpdate == null) return;

        itemToUpdate.Name = menu.Name;
        MenuRepository.Update(itemToUpdate, uow);
    }

    public void RemoveMenu(int id)
    {
        MenuRepository.Delete(id);
    } 
}