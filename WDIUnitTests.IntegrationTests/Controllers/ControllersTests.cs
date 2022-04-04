using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.IntegrationTests.Fixtures;
using Xunit;

namespace WDIUnitTests.IntegrationTests.Controllers
{
    public partial class ControllersTests : IClassFixture<AppFixture<Program>>
    {
        private readonly AppFixture<Program> _appFixture;
        public ControllersTests(AppFixture<Program> appFixture)
        {
            _appFixture = appFixture;
        }

    }
}
