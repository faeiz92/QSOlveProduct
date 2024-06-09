using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(RepositoryContext repositoryContext)
       : base(repositoryContext)
        {

        }
    }
}
