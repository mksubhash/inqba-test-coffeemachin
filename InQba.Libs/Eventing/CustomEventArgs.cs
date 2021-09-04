using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(Product product)
        {
            Product = product;
        }
        public Product Product { get; set; }
    }
}
