using System;

namespace Factorypattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaStore mystore = new MYPizzaStore();
            mystore.OrderPizza("sweet");

            PizzaStore cdstore = new CDPizzaStore();
            cdstore.OrderPizza("salty");

            Console.Read();
        }
    }
}