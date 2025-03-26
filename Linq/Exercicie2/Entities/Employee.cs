using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqClass.Exercicie2.Entities
{
    class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary{ get; set; }

        public Employee() { }
        public Employee(string name, string email, double salary)
        {

            Name = name;
            Email = email;
            Salary = salary;
        }

        public override string ToString()
        {
            return Name+", "+Email+", "+Salary;
        }
    }
}
