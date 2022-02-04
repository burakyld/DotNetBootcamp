using OrderingApplication.Models;
using OrderingDomain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApplication.Contracts.Services
{
    public interface IOrderService
    {
        Task<List<OrdersVm>> GetOrdersByUserName(string userName);

        Task<List<OrdersVm>> GetAllOrders();

    }
}
