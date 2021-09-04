using InQba.Libs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass]
    public class DrinkProcessTest
    {
        IMachineEventing eventing;
        ConstantConfigValues configValues;
        ILogger logger;
        IStockProcess _stockProcess;
        IDrinkProcessor _drinkProcessor;
        public DrinkProcessTest()
        {
            logger = new ConsoleLogger();
            configValues = new ConstantConfigValues();
            eventing = new MachineEventing();
            eventing.NoStock += Eventing_NoStock;
        }

        private void Eventing_NoStock(object sender, EventArgs e)
        {
            //for debug only
            System.Diagnostics.Trace.WriteLine("Event fired");
            System.Diagnostics.Trace.WriteLine("No stock:" + (e as CustomEventArgs).Product.Name);
        }

        [TestMethod]
        public void ProcessDrink_Cappuccino_Test_NegativeScenario()
        {
            _stockProcess = new StockProcess(eventing, logger, configValues, new StockBookContext());
            _drinkProcessor = new DrinkProcessor(eventing, _stockProcess, logger);
            var cap = new Cappuccino();
            var actual = _drinkProcessor.OrderDrink(cap);
            var expected = false;
            Assert.AreEqual<bool>(expected, actual);   
        }
        [TestMethod]
        public void ProcessDrink_Cappuccino_Test_PositiveScenario()
        {
            _stockProcess = new StockProcess(eventing, logger, configValues, new StockBookContext());
            _stockProcess.AddStock(new CoffeeBean
            {
                Id = 1,
                Name = "Cofee Bean",
                Qty = 25
            });
            _stockProcess.AddStock(new Milk
            {
                Id = 2,
                Name = "Milk",
                Qty = 20
            });
            _drinkProcessor = new DrinkProcessor(eventing, _stockProcess, logger);
            var cap = new Cappuccino();
            if(_drinkProcessor.OrderDrink(cap))
            {
                var actual = _drinkProcessor.DispenseDrink(cap);
                var expected = true;
                Assert.AreEqual<bool>(expected, actual);
            }
            else
            {
                Assert.Fail("Order drink failed");
            }
        }
    }
}
