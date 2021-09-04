using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public class StockProcess : IStockProcess
    {
        private readonly StockBookContext _stockBook; // this is supposded to be dbContext. Here added as an object. 
        private readonly ConstantConfigValues _config;
        private readonly IMachineEventing _eventing;
        private readonly ILogger _logger;
        public StockProcess(IMachineEventing eventing,ILogger logger, ConstantConfigValues config, StockBookContext stockBook) // injecting dependency dbContext and IOption (config)  in real world applications
        {
            _logger = logger;
            _stockBook = stockBook;
            _config = config;
            _eventing = eventing;
        }
        public bool AddStock(Product product)
        {
            return AddOrUpdateStock(product);
        }

        public List<Product> GetStock()
        {
            return _stockBook.Products;
        }

        public Product IsStockAvailble(int productId)
        {
            var productIn = _stockBook.Products.Find(x => x.Id == productId);
            if (productIn.Qty <= 5)
            {
                _eventing.OnWarningHappened(new CustomEventArgs(productIn));
            }
            return productIn;
        }

        public void PrintStock()
        {
            _logger.PublishLogging("Available stock..");
            foreach (var item in GetStock())
            {
                _logger.PublishLogging(string.Format("{0} : {1}", item.Name, item.Qty));
            }
        }

        public bool UdateStock(Product product)
        {
            return AddOrUpdateStock(product);
        }

        private bool AddOrUpdateStock(Product product)
        {
            int currentStock = 0;
            var productIn = _stockBook.Products.Find(x => x.Id == product.Id);
            if (productIn != null)
            {
                currentStock = productIn.Qty;
            }
            var max = _config.MaxProductQtyByProductId.Find(x => x.Key == product.Id);
            var newStock = product.Qty + currentStock;
            if (max.Value >= newStock)
            {
                _stockBook.Products.Remove(productIn);
                product.Qty = newStock;
                _stockBook.Products.Add(product);

            }
            else
            {
                _logger.PublishLogging("Cannot Add Stock. Out side of capacity. Product:" + product.Name);
                return false;
            }
            return true;
        }        
    }
}
