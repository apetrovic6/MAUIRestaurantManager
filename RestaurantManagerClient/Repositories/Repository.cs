using DevExpress.Xpo;
using RestaurantManagerClient.Models;

namespace RestaurantManagerClient.Repositories;

public class Repository<T> : IGenericRepository<T> where T : BaseModel
{

    public async Task<IEnumerable<T>> GetAll()
    {
        // try
        // {
            var query = new XPQuery<T>(new Session());
            return await Task.FromResult(query);
        // }
        // catch (Exception e)
        // {
            // Console.WriteLine(e);
            // return Task.FromException<T>(null);
        // }
    }

    public Task<T> GetById(int id)
    {

        var res = new XPQuery<T>(new Session()).Where(x => x.Oid == id);
        return Task.FromResult(res.FirstOrDefault());
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