using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public interface IStockProcess
    {
        Product IsStockAvailble(int productId);
        bool AddStock(Product product);
        bool UdateStock(Product product);
        List<Product> GetStock();
        void PrintStock();
    }
}
