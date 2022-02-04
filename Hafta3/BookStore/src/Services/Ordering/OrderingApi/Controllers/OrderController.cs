using Microsoft.AspNetCore.Mvc;
using OrderingApplication.Contracts.Services;
using OrderingApplication.Models;
using OrderingDomain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrderingApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Girilen kullanıcı adına göre sipariş bilgilerini getirir.
        [HttpGet("{userName}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrdersVm>>> GetOrdersByUserName(string userName)
        {
            var orders = await _orderService.GetOrdersByUserName(userName);
            return Ok(orders);
        }

        // Tüm siparişleri listeler.
        [HttpGet( Name = "GetAllOrders")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrdersVm>>> GetOrderList()
        {
            return Ok(await _orderService.GetAllOrders());
        }

    }
}
