using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication
{
    public class Employee : IEnumerable<Employee>
    {
        const string FileName = "Employee.txt";
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? IdDepartament { get; set; }
        public int Count => _employees.Count;
        private List<Employee> _employees;
        
        public int Id { get; set; }
      
        public Employee()
        {
            _employees = new List<Employee>();
        }
        public Employee(int id, string name, string surname, int? departament)
        {
            Id = id;
            Name = name;
            Surname = surname;
            IdDepartament = departament;
        }
        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }
        public Employee this[int index ]
        {
            get 
            {
                return _employees[index];
            }
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

        public IEnumerable<Employee> Find(Predicate<Employee> predicate)
        {
            foreach (var item in _employees)
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
                    foreach (var item in _employees)
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
            _employees.Clear();
            using (StreamReader streamReader = new StreamReader(FileName))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Employee employee = Parse(line);
                    _employees.Add(employee);
                }
            }
        }
        public override string ToString()
        {
            Department department = new Department();
            department.LoadFromFile();
            int? idDepartment = null;
            foreach (var item in department)
            {
                if (this.IdDepartament == item.Id)
                {
                    idDepartment = item.Id;
                    break;
                }
            }
            return $"{this.Id}){Name} {Surname},{idDepartment}";
        }
        public static Employee Parse(string line)
        {
            string firstOfLine = line.Substring(0, line.IndexOf(' '));
            string secondPartOfLine = line.Substring(line.IndexOf(' ') + 1);
            int employeeId = int.Parse(firstOfLine.Substring(0, line.IndexOf(')')));
            string name = firstOfLine.Substring(firstOfLine.IndexOf(')') + 1);
            string surname = secondPartOfLine.Substring(secondPartOfLine.LastIndexOf(' ') + 1, secondPartOfLine.IndexOf(','));
            int id = int.Parse(secondPartOfLine.Substring(secondPartOfLine.LastIndexOf(',') + 1));
            return new Employee(employeeId, name, surname, id);
        }
       
        public IEnumerator<Employee> GetEnumerator()
        {
            return _employees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
