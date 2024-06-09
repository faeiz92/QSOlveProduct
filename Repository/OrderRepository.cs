using Entities;
using Entities.Models;
using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository :RepositoryBase<Orders>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
       : base(repositoryContext)
        {

        }
    }
}
