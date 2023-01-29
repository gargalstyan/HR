using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication
{
    public static class Helper
    {
        public static void ShowMenu()
        {  
            MenuItems[] menuItems = Enum.GetValues<MenuItems>();
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(int)menuItems[i]}-{menuItems[i].ToString()}");
            }
        }
        
    }
}
