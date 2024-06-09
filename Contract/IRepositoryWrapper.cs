using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        IProductCategoryRepository ProductCategory { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItem { get; }
        void Save();

        void SaveChanges();
    }
}
