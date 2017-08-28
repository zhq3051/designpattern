using System;
using System.Collections.Generic;
using System.Text;
using Factorypattern.model;

namespace Factorypattern
{
    public class MYIngredientFactory : IngredientFactory
    {
        public override Dough CreateDough()
        {
            return new MYDough();
        }

        public override Sauce CreateSauce()
        {
            return new MYSauce();
        }
    }
}
