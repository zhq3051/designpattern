using System;
using System.Collections.Generic;
using System.Text;

namespace Factorypattern.model
{
    public class Pizza
    {
        public IngredientFactory ingredientFactory;
        public string Name { get; set; }

        public string DoughOrigin { get; set; }

        public string SauceOrigin { get; set; }

        public Dough Dough;

        public Sauce Sauce;

        public void SetName(string name)
        {
            Name = name;
        }

        public virtual void cut()
        {
            Console.WriteLine(string.Format("cut [{0}] into trigon", this.Name));
        }

        public void box()
        {
            Console.WriteLine(string.Format("box [{0}]", this.Name));
        }

        public void Prepare()
        {
            Dough = ingredientFactory.CreateDough();
            Sauce = ingredientFactory.CreateSauce();
            Console.WriteLine(string.Format("prepare {2}, and ingredient with {0} and {1}", Dough.Name, Sauce.Name, Name));
        }
    }
}
