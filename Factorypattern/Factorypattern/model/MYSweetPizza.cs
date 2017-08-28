using System;
using System.Collections.Generic;
using System.Text;

namespace Factorypattern.model
{
    public class MYSweetPizza : Pizza
    {
        public MYSweetPizza(IngredientFactory factory)
        {
            Name = "Mianyang sweet pizza";
            DoughOrigin = "mianyang thin dough";
            SauceOrigin = "mianyang spicy";
            this.ingredientFactory = factory;
        }
    }
}
