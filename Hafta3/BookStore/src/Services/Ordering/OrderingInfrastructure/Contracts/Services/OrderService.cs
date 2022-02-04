using AutoMapper;
using OrderingApplication.Contracts.Repository;
using OrderingApplication.Contracts.Services;
using OrderingApplication.Models;
using OrderingDomain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingInfrastructure.Contracts.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OrdersVm>> GetOrdersByUserName(string userName)
        {
            var orderList = await _orderRepository.GetOrdersByUserName(userName);
            return _mapper.Map<List<OrdersVm>>(orderList);
        }

        public async Task<List<OrdersVm>> GetAllOrders()
        {
            var orderList = await _orderRepository.GetAllOrders();
            return _mapper.Map<List<OrdersVm>>(orderList);
        }
    }
}
