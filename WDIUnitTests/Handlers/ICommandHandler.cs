using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDIUnitTests.Handlers
{
    public interface ICommandHandler<TCommand> where TCommand : IRequestCommand
    {
        Task HandleAsync(TCommand command);
    }
}
