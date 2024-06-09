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
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _context;
        private IProductRepository _productRepository;
        private IProductCategoryRepository _categoryRepository;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;

        public RepositoryWrapper(RepositoryContext context)
        {
            _context = context;
        }

        public IProductRepository Product
        {

            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_context);

                return _productRepository;
            }

        }

        public IProductCategoryRepository ProductCategory
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new ProductCategoryRepository(_context);

                return _categoryRepository;
            }
        }
        public IOrderRepository Orders
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_context);

                return _orderRepository;
            }

        }

        public IOrderItemRepository OrderItem
        {
            get
            {
                if (_orderItemRepository == null)
                    _orderItemRepository = new OrderItemRepository(_context);

                return _orderItemRepository;
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
