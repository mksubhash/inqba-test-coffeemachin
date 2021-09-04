using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public class Cappuccino : Drink
    {
        public Cappuccino()
        {
            Id = 1;
            Name = "Cappuccino";
            MilkUnit = new Milk
            {
                Id = 2,
                Name = "Milk",
                Qty = 3
            };
            BeanUnit = new CoffeeBean
            {
                Id = 1,
                Qty = 5,
                Name = "Cofee Bean"
            };
        }
        public override Product MilkUnit { get; set; }
        public override Product BeanUnit { get; set; }
    }
}
