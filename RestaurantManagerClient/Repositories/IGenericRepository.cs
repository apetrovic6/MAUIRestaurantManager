using DevExpress.Xpo;
using RestaurantManagerClient.Models;

namespace RestaurantManagerClient.Repositories;

    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Update(T obj, UnitOfWork uow);
        void Delete(int id);
        
        void Save(T obj, UnitOfWork uow);
    }