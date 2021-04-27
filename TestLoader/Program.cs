using INDEX;
using System;

namespace TestLoader
{
    class Program
    {
        private static INDEXManager Manager;

        static void Main(string[] args)
        {
            Manager = new INDEXManager($"{Environment.CurrentDirectory}\\Plugins", true);

            while (true)
            {

            }
        }
    }
}