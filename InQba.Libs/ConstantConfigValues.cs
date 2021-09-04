using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public class ConstantConfigValues
    {
        ////Supposed to be in config mapping - May be in DB or config file
        //private static ConstantConfigValues _stockBook;
        //public static ConstantConfigValues GetConstantConfigValues() // One instance across the execution
        //{
        //    if (_stockBook == null)
        //    {
        //        _stockBook = new ConstantConfigValues();
        //    }
        //    return _stockBook;
        //}        
        public ConstantConfigValues()
        {
            MaxProductQtyByProductId = new List<KeyValuePair<int, int>>();
            MaxProductQtyByProductId.Add(new KeyValuePair<int, int>(1, 25)); //Cofee bean
            MaxProductQtyByProductId.Add(new KeyValuePair<int, int>(2, 20)); // Milk

            MenuItems = new List<KeyValuePair<int, string>>();
            MenuItems.Add(new KeyValuePair<int, string>(1, "Cappuccino"));
            MenuItems.Add(new KeyValuePair<int, string>(2, "Coffee"));
            MenuItems.Add(new KeyValuePair<int, string>(3, "Latte"));            
            MenuItems.Add(new KeyValuePair<int, string>(8, "Check Stock"));
            MenuItems.Add(new KeyValuePair<int, string>(9, "Switch off"));

        }
        public List<KeyValuePair<int, int>> MaxProductQtyByProductId { get; private set; }

        public List<KeyValuePair<int, string>> MenuItems { get; private set; }
    }
}
