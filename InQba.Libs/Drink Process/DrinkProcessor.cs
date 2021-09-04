﻿using InQba.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public class DrinkProcessor : IDrinkProcessor
    {
        private readonly ILogger _logger;
        private readonly IStockProcess _stockProcess;
        private readonly IMachineEventing _eventing;
        public DrinkProcessor(IMachineEventing eventing, IStockProcess stockProcess, ILogger logger)
        {
            _stockProcess = stockProcess;
            _logger = logger;
            _eventing = eventing;
        }

        public void DispenseDrink(Drink drink)
        {
            _logger.PublishLogging("Dispensing the drink........");
            _logger.PublishLogging("Updating Stock........");

            drink.BeanUnit.Qty = drink.BeanUnit.Qty * -1;            
            _stockProcess.UdateStock(drink.BeanUnit);
            drink.MilkUnit.Qty = drink.MilkUnit.Qty * -1;
            _stockProcess.UdateStock(drink.MilkUnit);
            _stockProcess.IsStockAvailble(drink.BeanUnit.Id);
            _stockProcess.PrintStock();            
        }

        public bool OrderDrink(Drink drink)
        {
            var beanAvailble = _stockProcess.IsStockAvailble(drink.BeanUnit.Id);
            var milkAvailble = _stockProcess.IsStockAvailble(drink.MilkUnit.Id);
            if (beanAvailble.Qty >= drink.BeanUnit.Qty && milkAvailble.Qty >= drink.MilkUnit.Qty)
            {
                //Make the drink
                return true;
            }
            else
            {
                _stockProcess.PrintStock();

                if (beanAvailble.Qty < drink.BeanUnit.Qty)
                {
                    _eventing.OnStockIsLess(new CustomEventArgs(beanAvailble));
                }
                if (milkAvailble.Qty < drink.MilkUnit.Qty)
                {
                    _eventing.OnStockIsLess(new CustomEventArgs(milkAvailble));
                }
                return false;
            }

        }
    }
}
