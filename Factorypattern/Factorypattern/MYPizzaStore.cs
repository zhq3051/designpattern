using System;
using System.Collections.Generic;
using System.Text;
using Factorypattern.model;

namespace Factorypattern
{
    public class MYPizzaStore : PizzaStore
    {
        public MYPizzaStore()
        {
            
        }

        public override Pizza CreatePizza(string type)
        {
            Pizza pizza;
            IngredientFactory factory = new MYIngredientFactory();
            if (type == "sweet")
            {
                pizza = new MYSweetPizza(factory);
                pizza.SetName("sweettttttt mianyang pizzzzzzza");
            }
            else
            {
                pizza = new MYSaltyPizza(factory);
            }

            return pizza;
        }
    }
}
