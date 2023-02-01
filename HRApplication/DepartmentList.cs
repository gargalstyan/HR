using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication
{
    public class DepartmentList:IEnumerable<Department>
    {
        private List<Department> departmentList;
        public int Count => departmentList.Count;
        public DepartmentList()
        {
            departmentList = new List<Department>();
        }
         public void Add(Department department)
        {
            departmentList.Add(department);
        }
        public bool Remove(int id)
        {
            IEnumerable<Department> departments1 = Find(departments1 => departments1.Id == id);
            foreach (var item in departmentList)
            {
                if (item.Id == id)
                {
                    departmentList.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public Department GetId(int id)
        {
            List<Department> list = this.departmentList.GetByCondition(item => item.Id == id).ToList();
            if (list.Count != 1)
                throw new Exception("Invalid value for Id");

            return list[0];
        }

        public IEnumerable<Department> Find(Predicate<Department> predicate)
        {
            return this.departmentList.GetByCondition(predicate);
        }


        public IEnumerator<Department> GetEnumerator()
        {
            return this.departmentList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.departmentList.GetEnumerator();
        }
    }
}
