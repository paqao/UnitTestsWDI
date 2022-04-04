using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.Clients;
using WDIUnitTests.DatabaseLayer.Data;
using WDIUnitTests.Repository;

namespace WDIUnitTests.Handlers
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand>
    {
        private readonly ISalesApiClient _salesApiClient;
        private readonly IDataRepository<Order> _orderRepository;

        public UpdateOrderCommandHandler(ISalesApiClient salesApiClient,
            IDataRepository<Order> orderRepository)
        {
            _salesApiClient = salesApiClient;
            _orderRepository = orderRepository;
        }

        public async Task HandleAsync(UpdateOrderCommand command)
        {
            var data = await _orderRepository.GetByIdAsync(command.Id);
            if (data == null)
            {
                throw new Exception("Not found order");
            }

            data.IsCompleted = command.CompletedStatus;

            await _salesApiClient.UpdateAsync(data);
        }
    }
}
