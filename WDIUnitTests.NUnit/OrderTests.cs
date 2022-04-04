using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.DatabaseLayer.Data;

namespace WDIUnitTests.NUnit
{
    public class OrderTests
    {
        [Test]
        public void GenerateSampleOrder()
        {
            GenFu.GenFu.Configure<Order>().Fill(x => x.Id).WithRandom(new string[] { "123", "142" });

            Order order = GenFu.A.New<Order>();
        }
    }
}
