using DevExpress.Xpo;
using RestaurantManagerClient.Models;

namespace RestaurantManagerClient.Repositories;

public class Repository<T> : IGenericRepository<T> where T : BaseModel
{

    public async Task<IEnumerable<T>> GetAll(UnitOfWork uow)
    {
        try
        {
            return await Task.FromResult(uow.Query<T>());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<T> GetById(int id)
    {
        using (var uow = new UnitOfWork())
        {
            return await Task.FromResult(uow.GetObjectByKey<T>(id));
        }
    }

    public void Update(T obj, UnitOfWork uow)
    {
        uow.Save(obj);
        uow.CommitChanges();
    }

    public void Delete(int id)
    {
        using (var uow = new UnitOfWork())
        {
            var itemToDelete = uow.GetObjectByKey<T>(id);
            if (itemToDelete != null)
            {
                uow.Delete(itemToDelete);
                uow.CommitChanges();
            }
        }
    }

    public void Save(T obj, UnitOfWork uow)
    {
        obj.Id = Guid.NewGuid().ToString();
        
        uow.Save(obj);
        uow.CommitChanges();
    }
    
}