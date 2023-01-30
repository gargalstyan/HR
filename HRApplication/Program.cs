using HRApplication;

Employee employees = new Employee();
Department departments = new Department();
MenuItems menuItems;
FindMenu findMenu;
employees.LoadFromFile();
departments.LoadFromFile();
int choice;
do
{
    Helper.ShowMenu();
    Console.Write("choice ->");

    while (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Please, enter a number");
    }
    Console.WriteLine($"Your choise is {(MenuItems)choice}");
    menuItems = (MenuItems)choice;

    switch (menuItems)
    {
        case MenuItems.AddEmployee:
            int currentId = employees.Count;
            employees.Id = ++currentId;
            Console.Write("Add Employee name ");
            employees.Name = Console.ReadLine();
            Console.Write("Add Employee surname ");
            employees.Surname = Console.ReadLine();
            Console.WriteLine("Departaments we have if you want add new departament tap yes or no ");
            departments.ShowAll();
            Console.Write("Enter = ");
            string yesOrNo = Console.ReadLine();
            if (yesOrNo.ToLower() == "yes")
            {
                int currentIdD = departments.Count;
                departments.Id = ++currentIdD;
                Console.WriteLine("Add name of departament");
                departments.DepartmentName = Console.ReadLine();
                departments.Add(new Department(departments.Id, departments.DepartmentName));
                departments.SaveToFile();
                departments.ShowAll();
            }
            Console.Write("Add Employee departamentId ");
            employees.IdDepartament = int.Parse(Console.ReadLine());

            employees.Add(new Employee(employees.Id, employees.Name, employees.Surname, employees.IdDepartament));
            break;
        case MenuItems.AddDepartamant:
            int currentIdD1 = departments.Count;
            departments.Id = ++currentIdD1;
            Console.WriteLine("Add name of departament");
            departments.DepartmentName = Console.ReadLine();
            departments.Add(new Department(departments.Id, departments.DepartmentName));
            break;
        case MenuItems.RemoveEmployee:
            employees.ShowAll();
            Console.WriteLine("Enter Id to remove  ");
            int idToRemove = int.Parse(Console.ReadLine());
            if (employees.Remove(idToRemove))
            {
                Console.WriteLine("Successfuly removed");
            }
            else
            {
                Console.WriteLine("Error");
            }
            break;
        case MenuItems.RemoveDepartamant:
            departments.ShowAll();
            Console.Write("Enter departament Id = ");
            int idDepartament = int.Parse(Console.ReadLine());
            if (departments.Remove(idDepartament))
            {
                Console.WriteLine("Successfuly removed");
            }
            else
            {
                Console.WriteLine("Error");
            }
            break;
        case MenuItems.Find:
            IEnumerable<Employee> employee = null;
            Console.WriteLine("1-Find by Id");
            Console.WriteLine("2-Find by Name");
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please, enter a number");
            }
            findMenu = (FindMenu)choice;
            switch (findMenu)
            {
                case FindMenu.FindById:
                    Console.WriteLine("Enter id");
                    int id = int.Parse(Console.ReadLine());
                    employee = employees.Find(emp => emp.Id == id);
                    break;
                case FindMenu.FindByName:
                    Console.WriteLine("Enter name");
                    string nameToFind = Console.ReadLine();
                    employee = employees.Find(emp => emp.Name.ToLower() == nameToFind.ToLower());
                    break;
            }
            if (employee.Count() != 0)
            {
                foreach (var item in employee)
                {
                    Console.WriteLine($"The employee you need is {item.Id}) {item.Name} {item.Surname} {item.IdDepartament}");
                }
            }
            else
            {
                Console.WriteLine("Record did not exist");
            }
            break;
        case MenuItems.ShowEmployee:
            employees.ShowAll();
            Console.WriteLine();
            break;
        case MenuItems.ShowDepartamant:
            departments.ShowAll();
            Console.WriteLine();
            break;
        case MenuItems.Save:
            if (employees.SaveToFile() && departments.SaveToFile())
            {
                Console.WriteLine("Successfuly saved");
            }
            else
            {
                Console.WriteLine("Error while saving");
            }
            break;
        case MenuItems.Exit:
            Console.WriteLine("You exit");
            break;
    }
}
while ((int)menuItems != 0);


