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
        public void Add(Department department)
        {
            _departments.Add(department);
        }
        public bool Remove(int id)
        {
            IEnumerable<Department> departments1 = Find(departments1 => departments1.Id == id);
            foreach (var item in _departments)
            {
                if (item.Id == id)
                {
                    _departments.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Department> Find(Predicate<Department> predicate)
        {
            foreach (var item in _departments)
            {
                if (predicate(item))
                    yield return item;
            }
        }
        public bool SaveToFile()
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(FileName))
                {
                    foreach (var item in _departments)
                    {
                        streamWriter.WriteLine(item);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void LoadFromFile()
        {
            _departments.Clear();
            using (StreamReader streamReader = new StreamReader(File.Open(FileName, FileMode.OpenOrCreate)))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Department department = Parse(line);
                    _departments.Add(department);
                }
            }
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
