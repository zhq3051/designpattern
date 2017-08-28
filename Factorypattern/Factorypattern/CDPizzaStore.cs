using System;
using System.Collections.Generic;
using System.Text;
using Factorypattern.model;

namespace Factorypattern
{
    public class CDPizzaStore : PizzaStore
    {
        
        public CDPizzaStore()
        {
        }
        public override Pizza CreatePizza(string type)
        {
            IngredientFactory factory = new CDIngredientFactory();
            if (type == "sweet")
            {
                return new CDSweetPizza(factory);
            }
            else
            {
                return new CDSaltyPizza(factory);
            }
        }
    }
}
