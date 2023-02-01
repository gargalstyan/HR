using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication
{
    public static class Extensions
    {
        public static void ShowAll(this EmployeeList items) 
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        public static void ShowAll(this DepartmentList items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        public static IEnumerable<T> GetByCondition<T>(this IEnumerable<T> list,Predicate<T> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                    yield return item; 
             }
        }

    }
}
