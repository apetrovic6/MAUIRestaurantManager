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
        return MenuRepository.GetAll().Result.ToList();
    }

    public Menu GetMenuById(int id)
    {
        return MenuRepository.GetById(id).Result;
    }

    public void AddNewMenu(string newName, int resId)
    {
        using (var uow = new UnitOfWork())
        {
            var restaurant = uow.GetObjectByKey<Restaurant>(resId);

            Menu menu = new Menu(uow);
            
            menu.Name = newName;
            menu.Restaurant = restaurant;
            MenuRepository.Save(menu, uow);
        }
        
    }

    public void UpdateMenu(Menu menu)
    {
        using var uow = new UnitOfWork();
        var itemToUpdate = uow.GetObjectByKey<Menu>(menu.Oid);
        
        if (itemToUpdate == null) return;

        itemToUpdate.Name = menu.Name;
        MenuRepository.Update(itemToUpdate, uow);
    }

    public void RemoveMenu(int id)
    {
        MenuRepository.Delete(id);
    } 
}