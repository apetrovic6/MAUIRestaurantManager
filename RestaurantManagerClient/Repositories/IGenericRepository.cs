using DevExpress.Xpo;
using RestaurantManagerClient.Models;

namespace RestaurantManagerClient.Repositories;

    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAll(Session uow);
        Task<T> GetById(string id);
        void Update(T obj, UnitOfWork uow);
        void Delete(string id);
        void Save(T obj);
    }