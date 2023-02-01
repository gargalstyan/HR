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
        public override string ToString()
        {
            
            return $"{this.Id},{Name},{Surname},{IdDepartament}";
        }
        public static Employee Parse(string line)
        {
            string[] text = line.Split(',');
            if (text.Length != 4)
            {
                throw new ArgumentException("Not valid format");
            }
            int id = int.Parse(text[0]);
            string name = text[1].Trim();
            string surname = text[2].Trim();
            int idDepartament = int.Parse(text[3]);
            return new Employee(id, name, surname, idDepartament);
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
