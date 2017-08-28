using System;
using System.Collections.Generic;
using System.Text;
using Factorypattern.model;

namespace Factorypattern
{
    public abstract class PizzaStore
    {
        public void OrderPizza(string type)
        {
            Pizza pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.cut();
            pizza.box();
        }

        public abstract Pizza CreatePizza(string type);
    }
}
