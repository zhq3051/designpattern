using System;
using System.Collections.Generic;
using System.Text;

namespace Factorypattern.model
{
    public class CDSaltyPizza : Pizza
    {
        public CDSaltyPizza(IngredientFactory factory)
        {
            Name = "chengdu salty pizza";
            DoughOrigin = "chengdu dough";
            SauceOrigin = "chengdu salty SauceOrigin";
            ingredientFactory = factory;
        }
        public override void cut()
        {
            Console.WriteLine("cut into square");
        }
    }
}
