using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication
{
    public class FileHelper
    {
        public string FileName { get;}
        public FileHelper(string fileName)
        {
            FileName  = fileName;
        }
        public bool SaveToFileForEmployee(EmployeeList list)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(FileName))
                {
                    foreach (var item in list)
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
        public bool SaveToFileForDepartment(DepartmentList list)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(FileName))
                {
                    foreach (var item in list)
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
        public EmployeeList LoadFromFileForEmployee()
        {
            EmployeeList employeesList = new EmployeeList();
            using (StreamReader streamReader = new StreamReader(File.Open(FileName, FileMode.OpenOrCreate)))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    employeesList.Add(Employee.Parse(line));
                }
            }
            return employeesList;
        }
        public DepartmentList LoadFromFileForDepartment()
        {
            DepartmentList departmentList = new DepartmentList();
            using (StreamReader streamReader = new StreamReader(File.Open(FileName, FileMode.OpenOrCreate)))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    departmentList.Add(Department.Parse(line));
                }
            }
            return departmentList;
        }
    }
}
