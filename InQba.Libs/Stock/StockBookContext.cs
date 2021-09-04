using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public class StockBookContext
    {
        //Realy world this will be the product table with type and other atribute. For making things easy, i have thought of making it a collection
        //private static StockBook _stockBook;
        //public static StockBook GetStockBook() //Making sure only one instance across the excution -- singlton
        //{
        //    if (_stockBook == null)
        //    {
        //        _stockBook = new StockBook();
        //    }
        //    return _stockBook;
        //}
        public StockBookContext()
        {
            Products = new List<Product>();
        }
        public const int _maxBeanCapacity = 25;
        public const int _maxMilkCapacity = 20;
        public List<Product> Products { get; set; }
    }
}
