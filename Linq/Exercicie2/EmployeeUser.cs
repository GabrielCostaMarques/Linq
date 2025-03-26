using LinqClass.Exercicie2.Entities;
using System.Globalization;
namespace LinqClass.Exercicie2
{
    class EmployeeUser
    {
        public void EmployeeShow()
        {
            List<Employee> list = new();

            Console.Write("Enter with full path: ");
            string path = Console.ReadLine();

            Console.Write("Enter Salary: ");
            double sal= double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] vect = line.Split(',');
                    string name = vect[0];
                    string email = vect[1];
                    double salary = double.Parse(vect[2],CultureInfo.InvariantCulture);

                    list.Add(new Employee {Name = name, Email = email,Salary = salary});
                }
            }

            Console.WriteLine("Email of people whose salary is more than 2000.00");
            var moreTwoThousand=list.Where(e => e.Salary > sal).OrderBy(e => e.Name).Select(e => e.Email);
            foreach (var item in moreTwoThousand)
            {
                Console.WriteLine(item);

            }           
            Console.WriteLine("Sum of salary of people whose name starts with 'M': ");
            var startM = list.Where(e => e.Name[0]=='M').Sum(e => e.Salary);

            Console.WriteLine(startM);
        }
    }
}
