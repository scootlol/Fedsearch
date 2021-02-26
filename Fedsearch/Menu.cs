using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fedsearch
{
    class Menu
    {
        public static void Banner()
        {
            Console.WriteLine($"{Color.Yellow}     _*_ ....weewoo{Color.Reset}");
            Console.WriteLine($"{Color.Yellow}  __/_|_\\__ {Color.Reset}");
            Console.WriteLine($"{Color.Yellow} [(o)_R_(o)]{Color.Green} fedsearch database lookup\n{Color.Reset}");
            Console.WriteLine($"{Color.Red} !cls / !clear - clear console\n !exit - exit program\n{Color.Reset}");
        }
    }
}
