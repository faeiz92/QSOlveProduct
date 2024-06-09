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
    public  class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
       : base(repositoryContext)
        {

        }
    }
}
