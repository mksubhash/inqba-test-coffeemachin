using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public class Latte : Drink
    {
        public Latte()
        {
            Id = 3;
            Name = "Latte";
            MilkUnit = new Milk
            {
                Id = 2,
                Name = "Milk",
                Qty = 2
            };
            BeanUnit = new CoffeeBean
            {
                Id = 1,
                Qty = 3,
                Name = "Cofee Bean"
            };
        }
        public override Product MilkUnit { get; set; }
        public override Product BeanUnit { get; set; }
    }
}
