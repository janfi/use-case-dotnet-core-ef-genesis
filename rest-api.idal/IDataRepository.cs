using System;
using System.Collections.Generic;
using System.Text;

namespace rest_api.idal
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TEntity Add(TEntity entity);
        void Update(TEntity dBentity, TEntity entity);
        void Delete(TEntity entity);
        void Remove(TEntity entity);
    }
}
