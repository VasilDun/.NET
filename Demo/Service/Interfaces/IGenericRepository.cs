using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {    
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        void Save();
    }
}
