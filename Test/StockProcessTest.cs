using InQba.Libs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass]
    public class StockProcessTest
    {
        IMachineEventing eventing;
        ConstantConfigValues configValues;
        ILogger logger;
        IStockProcess _stockProcess;
        public StockProcessTest()
        {
            logger = new ConsoleLogger();
            configValues = new ConstantConfigValues();
            eventing = new MachineEventing();
        }
        [TestMethod]
        public void AddStock_CoffeeBean_26()
        {
            _stockProcess = new StockProcess(eventing, logger, configValues, new StockBookContext());

            var expected = false;
            var actual = _stockProcess.AddStock(new CoffeeBean
            {
                Id = 1,
                Name = "Cofee Bean",
                Qty = 26
            });
            Assert.AreEqual<bool>(expected, actual);
        }
        [TestMethod]
        public void AddStock_Milk_21()
        {
            _stockProcess = new StockProcess(eventing, logger, configValues, new StockBookContext());
            var expected = false;
            var actual = _stockProcess.AddStock(new Milk
            {
                Id = 2,
                Name = "Milk",
                Qty = 21
            });
            Assert.AreEqual<bool>(expected, actual);
        }

        [TestMethod]
        public void AddStock_CoffeeBean_25()
        {
            _stockProcess = new StockProcess(eventing, logger, configValues, new StockBookContext());
            var actual = _stockProcess.AddStock(new CoffeeBean
            {
                Id = 1,
                Name = "Cofee Bean",
                Qty = 25
            });
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void AddStock_Milk_20()
        {
            _stockProcess = new StockProcess(eventing, logger, configValues, new StockBookContext());
            var actual = _stockProcess.AddStock(new Milk
            {
                Id = 2,
                Name = "Milk",
                Qty = 20
            });
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void UpdateStock_CoffeeBean()
        {
            _stockProcess = new StockProcess(eventing, logger, configValues, new StockBookContext());
            var response = _stockProcess.AddStock(new CoffeeBean
            {
                Id = 1,
                Name = "Cofee Bean",
                Qty = 25
            });
            if (response)
            {

                var response2 = _stockProcess.UdateStock(new CoffeeBean
                {
                    Id = 1,
                    Name = "Cofee Bean",
                    Qty = -5
                });
                if (response)
                {
                    int expected = 20;
                    var actual = _stockProcess.IsStockAvailble(1).Qty;
                    Assert.AreEqual<int>(expected, actual);
                }
                else
                {
                    Assert.Fail("Update -5 coffee bean failed");
                }
            }
            else
            {
                Assert.Fail("Add 25 coffee bean failed");
            }
        }
        [TestMethod]
        public void UpdateStock_Milk()
        {
            _stockProcess = new StockProcess(eventing, logger, configValues, new StockBookContext());
            var response = _stockProcess.AddStock(new Milk
            {
                Id = 2,
                Name = "Milk",
                Qty = 20
            });
            if (response)
            {

                var response2 = _stockProcess.UdateStock(new Milk
                {
                    Id = 2,
                    Name = "Milk",
                    Qty = -2
                });
                if (response)
                {
                    int expected = 18;
                    var actual = _stockProcess.IsStockAvailble(2).Qty;
                    Assert.AreEqual<int>(expected, actual);
                }
                else
                {
                    Assert.Fail("Update -2 milk failed");
                }
            }
            else
            {
                Assert.Fail("Add 20 milk failed");
            }
        }
    }
}
