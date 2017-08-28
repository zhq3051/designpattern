using System;
using System.Collections.Generic;
using System.Text;
using Factorypattern.model;

namespace Factorypattern
{
    public class CDIngredientFactory : IngredientFactory
    {
        public override Dough CreateDough()
        {
            return new CDDough();
        }

        public override Sauce CreateSauce()
        {
            return new CDSauce();
        }
    }
}
