using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public class MenuOperation : IMenuOperation
    {
        private readonly IDrinkProcessor _drinkProcessor;
        private readonly IStockProcess _stockProcess;
        private readonly ILogger _logger;
        public MenuOperation(IDrinkProcessor drinkProcessor, IStockProcess stockProcess, ILogger logger)
        {
            _logger = logger;
            _stockProcess = stockProcess;
            _drinkProcessor = drinkProcessor;
        }

        public void ProcessSelection(int input)
        {
            switch (input)
            {
                case 1: //Cappuccino
                    {
                        var cap = new Cappuccino();
                        if (_drinkProcessor.OrderDrink(cap))
                        {
                            _drinkProcessor.DispenseDrink(cap);
                        }
                        break;
                    }
                case 2: //Coffee
                    {

                        var coffee = new Coffee();
                        if (_drinkProcessor.OrderDrink(coffee))
                        {
                            _drinkProcessor.DispenseDrink(coffee);
                        }
                        break;
                    }
                case 21: //Black Coffee
                    {

                        var blkCoffee = new BlackCoffee();
                        if (_drinkProcessor.OrderDrink(blkCoffee))
                        {
                            _drinkProcessor.DispenseDrink(blkCoffee);
                        }
                        break;
                    }
                case 3: //Latte
                    {
                        var latte = new Latte();
                        if (_drinkProcessor.OrderDrink(latte))
                        {
                            _drinkProcessor.DispenseDrink(latte);
                        }
                        break;
                    }
                case 8: //Check Stock
                    {
                        _stockProcess.PrintStock();
                        break;
                    }                
                default:
                    {
                        _logger.PublishLogging(" Wrong selection...");
                        break;
                    }
            }
        }
    }
}
