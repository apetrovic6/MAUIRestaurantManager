using DevExpress.Xpo;
using RestaurantManagerClient.Models;

namespace RestaurantManagerClient.Repositories;

    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAll(UnitOfWork uow);
        Task<T> GetById(string id);
        void Update(T obj, UnitOfWork uow);
        void Delete(string id);
        
        /// <summary>
        /// Use when saving entities and possible relationship
        /// </summary>
        /// <param name="obj">Item to save</param>
        /// <param name="uow">Unit of Work</param>
        void Save(T obj, UnitOfWork uow);

        /// <summary>
        /// Use when only saving an entity
        /// </summary>
        /// <param name="obj">Item to save</param>
        void Save(T obj);
    }