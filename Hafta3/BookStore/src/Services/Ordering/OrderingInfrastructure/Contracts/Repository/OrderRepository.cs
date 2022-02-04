using Microsoft.EntityFrameworkCore;
using OrderingApplication.Contracts.Repository;
using OrderingDomain.Entities.Orders;
using OrderingInfrastructure.Contracts.Repository.Common;
using OrderingInfrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingInfrastructure.Contracts.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                .Where(o => o.UserName == userName)
                                .ToListAsync();
            return orderList;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var orderList = await _dbContext.Orders
                                .ToListAsync();
            return orderList;
        }
    }
}
