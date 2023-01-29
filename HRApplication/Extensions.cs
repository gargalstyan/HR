using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication
{
    public static class Extensions
    {
        public static void ShowAll<T>(this T items) where T : IEnumerable<T>
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
     
    }
}
