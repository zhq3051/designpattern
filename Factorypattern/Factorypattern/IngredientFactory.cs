using System;
using System.Collections.Generic;
using System.Text;
using Factorypattern.model;

namespace Factorypattern
{
    public abstract class IngredientFactory
    {
        public abstract Dough CreateDough();

        public abstract Sauce CreateSauce();
    }
}
