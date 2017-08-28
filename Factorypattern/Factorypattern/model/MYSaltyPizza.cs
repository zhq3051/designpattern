using System;
using System.Collections.Generic;
using System.Text;

namespace Factorypattern.model
{
    public class MYSaltyPizza : Pizza
    {
        public MYSaltyPizza(IngredientFactory factory)
        {
            Name = "Mianyang salty pissa";
            DoughOrigin = "mianyang dough";
            SauceOrigin = "mianyang salty SauceOrigin";
            this.ingredientFactory = factory;
        }
    }
}
