using Microsoft.AspNetCore.Mvc;
using WDIUnitTests.DatabaseLayer.Data;
using WDIUnitTests.Repository;

namespace WDIUnitTests.WebApi.Controllers
{
    [Route("orders")]
    public class OrdersController : Controller
    {
        private IDataRepository<Order> _ordersRepository;
        public OrdersController(IDataRepository<Order> ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _ordersRepository.GetAllAsync();
        }

        [HttpPost()]
        public async Task AddOrder([FromBody] Order order)
        {
            await _ordersRepository.AddAsync(order);
        }
    }
}
