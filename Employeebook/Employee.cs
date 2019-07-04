using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeebook

{
    
    class Employee
    {
        private const string TEXT_FILENAME = "EmployeefileText.txt";
        public string Name { get; set; }

        public string Title { get; set; }

        // Creating a Dummy Employee method to understand binding concept
        public static Employee GetEmployee()

        {
            var employee = new Employee
            {
                Name = "John doe",
                Title = "CEO"
            };
            return employee;
        }

        public static void WriteEmployee(Employee employee)
        {
            var employeeData = $"{employee.Name},{employee.Title}";
            FileHelper.WriteTextfileAsync(TEXT_FILENAME,employeeData);

        }
        public async static Task <ICollection<Employee>>GetEmployeesAsync()
        {
            var employees = new List<Employee>();
            var fileContent= await FileHelper.ReadTextFileAsync(TEXT_FILENAME);
            var lines=fileContent.Split('\r', '\n');
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts=line.Split(',');
                var employee = new Employee
                {
                    Name = lineParts[0],
                    Title = lineParts[1]

                };
                employees.Add(employee);
            }

            return employees;
        }

    }
}
