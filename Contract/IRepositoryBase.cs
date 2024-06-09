using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IRepositoryBase<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);

        void Add(TEntity entity);
        void AddRange(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
