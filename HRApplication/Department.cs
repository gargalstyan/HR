using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication
{
    public class Department:IEnumerable<Department>
    {
        const string FileName = "Department.txt";
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int Count => _departments.Count;
        private List<Department> _departments;
        public Department()
        {
            _departments = new List<Department>();
        }
        public Department(int id, string departmentName)
        {
            Id = id;
            DepartmentName = departmentName;
        }
        public static Department Parse(string line)
        {
            string departemntName = line.Substring(0, line.IndexOf('-'));
            int id = int.Parse(line.Substring(line.LastIndexOf('-') + 1));
            return new Department(id, departemntName);
        }
        public override bool Equals(object? obj)
        {
            return DepartmentName == ((Department)obj).DepartmentName;    
        }
        public override string ToString()
        {
            return $"{DepartmentName}---{Id}";
        }

        public IEnumerator<Department> GetEnumerator()
        {
            return _departments.GetEnumerator();
        }
            
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override int GetHashCode()
        {
            return DepartmentName.GetHashCode();
        }
    }
}
