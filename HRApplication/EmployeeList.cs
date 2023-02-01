using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication
{
    public class EmployeeList:IEnumerable<Employee>
    {
        private List<Employee> _employees;
        public int Count => _employees.Count;
        public EmployeeList()
        {
            _employees = new List<Employee>();
        }
        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public bool Remove(int id)
        {
            IEnumerable<Employee> employees = Find(employee => employee.Id == id);
            foreach (var item in employees)
            {
                if (item.Id == id)
                {
                    _employees.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public Employee GetId(int id)
        {
            List<Employee> list = this._employees.GetByCondition(item => item.Id == id).ToList();
            if (list.Count != 1)
                throw new Exception("Invalid value for Id");

            return list[0];
        }

        public IEnumerable<Employee> Find(Predicate<Employee> predicate)
        {
            return this._employees.GetByCondition(predicate);
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return _employees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _employees.GetEnumerator();
        }
    }
}
