using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public interface IDrinkProcessor
    {
        bool OrderDrink(Drink drink);
        bool DispenseDrink(Drink drink);
    }
}
