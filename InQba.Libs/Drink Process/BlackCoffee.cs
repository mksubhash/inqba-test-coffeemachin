using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public class BlackCoffee : Drink
    {        
        public BlackCoffee()
        {
            Id = 4;
            Name = "Coffee";
            MilkUnit = new Milk
            {
                Id = 2,
                Name = "Milk",
                Qty = 0
            };
            BeanUnit = new CoffeeBean
            {
                Id = 1,
                Qty = 2,
                Name = "Cofee Bean"
            };
        }
        public override Product MilkUnit { get; set; }
        public override Product BeanUnit { get; set; }
    }
}
