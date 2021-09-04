using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public class BootstrapMachine
    {
        /// <summary>
        /// Dependency injection handlers
        /// </summary>
        private readonly IStockProcess _stockProcess;
        private readonly ConstantConfigValues _constantConfigValues; //Cretaed as singleton
        private readonly IDrinkProcessor _drinkProcessor;
        private readonly IMachineEventing _eventing;
        private readonly IMenuOperation _menuOperation;
        public BootstrapMachine(IMenuOperation menuOperation, IMachineEventing eventing, IStockProcess stockProcess, IDrinkProcessor drinkProcessor, ConstantConfigValues constantConfigValues)
        {
            _menuOperation = menuOperation;
            _eventing = eventing;
            _stockProcess = stockProcess;
            _drinkProcessor = drinkProcessor;
            _constantConfigValues = constantConfigValues;

            _eventing.Warning += _eventing_Warning;
            _eventing.NoStock += _eventing_NoStock;
        }

        /// <summary>
        /// Event routine for No stock message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _eventing_NoStock(object sender, EventArgs e)
        {
            var cea = e as CustomEventArgs;
            Console.WriteLine(string.Format(@" Cannot prepare the drink as no/low stock of {0}. Please add stock", cea.Product.Name));
        }

        /// <summary>
        /// event routine for Warning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _eventing_Warning(object sender, EventArgs e)
        {
            var cea = e as CustomEventArgs;
            Console.WriteLine(string.Format(@" Warning !!! {0} is low (5 or less)", cea.Product.Name));
        }

        /// <summary>
        /// This is method will get called at the first
        /// </summary>
        public void Bootstrap()
        {
            Console.WriteLine("Adding full stock...");            
            AddStock(); // Initial stock config in the machine
            Console.WriteLine("Stock Added");
            _stockProcess.PrintStock();
            PrintMenu();
        }

        /// <summary>
        /// This is added as part of configuaration... 
        /// </summary>
        public void AddStock()
        {
            //Add mx stock
            //var stockP = new StockProcess(_stockProcess, ConstantConfigValues.GetConstantConfigValues());
            _stockProcess.AddStock(new CoffeeBean
            {
                Id = 1,
                Name = "Cofee Bean",
                Qty = _constantConfigValues.MaxProductQtyByProductId[0].Value
            });
            _stockProcess.AddStock(new Milk
            {
                Id = 2,
                Name = "Milk",
                Qty = _constantConfigValues.MaxProductQtyByProductId[1].Value
            });            
        }        
        public void PrintMenu()
        {
            bool proceed = true;
            int input = 0;
            while (input != -1)
            {
                Console.WriteLine(" Menu...");
                foreach (var item in _constantConfigValues.MenuItems)
                {
                    Console.WriteLine(string.Format(@" {0} for {1} ", item.Key, item.Value));
                }
                Console.WriteLine(" Please type your selection:-");

                if (Int32.TryParse(Console.ReadLine(), out input) && _constantConfigValues.MenuItems.FirstOrDefault(x => x.Key == input).Value != null)
                {
                    if (input == 9) //Switch off machine
                    {
                        break;
                    }
                    string inp = string.Empty;
                    if (input == 2)
                    {
                        int lpC = 1;
                        
                        Console.WriteLine(" With Milk?(y/n) and 'b' to go back:-");

                        while (inp.ToLowerInvariant() != "y" || inp.ToLowerInvariant() != "n" || inp.ToLowerInvariant() != "b")
                        {
                            inp = Console.ReadLine();
                            if(inp.ToLowerInvariant() == "y")
                            {
                                proceed = true;
                                input = 2;
                                break;
                            }
                            if(inp.ToLowerInvariant() == "n")
                            {
                                proceed = true;
                                input = 21;
                                break;
                            }
                            if (inp.ToLowerInvariant() == "b")
                            {
                                proceed = false;
                                break;
                            }
                            if (lpC == 3)
                            {
                                proceed = false;
                                break;
                            }
                            lpC++;
                            Console.WriteLine(" Wrong selection, for Coffee with Milk?(y/n) and 'b' to go back:-");
                        }
                    }
                    if (proceed)
                    {
                        _menuOperation.ProcessSelection(input);
                    }
                    else
                    {
                        if (inp.ToLowerInvariant() != "b")
                        {
                            Console.WriteLine(" Wrong selection...");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(" Wrong selection...");
                }
            }
            Console.WriteLine(" Good bye......");
            System.Threading.Thread.Sleep(2000);
        }

    }
}
