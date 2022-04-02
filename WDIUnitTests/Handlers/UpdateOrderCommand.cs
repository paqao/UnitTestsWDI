using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDIUnitTests.Handlers
{
    public class UpdateOrderCommand : IRequestCommand
    {
        public bool CompletedStatus { get; set; }
        public string Id { get; set; }
    }
}
