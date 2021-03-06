﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters)
            : base(name, price)
        {
            this.Milliliters = milliliters;
        }
        public double Milliliters { get; private set; }
    }
}
