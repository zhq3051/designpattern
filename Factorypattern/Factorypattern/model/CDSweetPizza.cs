using System;
using System.Collections.Generic;
using System.Text;

namespace Factorypattern.model
{
    public class CDSweetPizza : Pizza
    {
        public CDSweetPizza(IngredientFactory factory)
        {
            Name = "chengdu sweet pizza";
            DoughOrigin = "chengdu sweet dough";
            SauceOrigin = "chengdu sweet SauceOrigin";
            this.ingredientFactory = factory;
        }

        public override void cut()
        {
            Console.WriteLine(string.Format("cut [{0} into round]", this.Name));
        }
    }
}
