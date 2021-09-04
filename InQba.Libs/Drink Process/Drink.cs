﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InQba.Libs
{
    public abstract class Drink
    {
        public Drink()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract Product BeanUnit { get; set; }
        public abstract Product MilkUnit { get; set; }
    }
}
