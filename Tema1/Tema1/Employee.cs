using System;

namespace Tema1
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Salary { get; set; }
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public bool IsActive()
        {
            return DateTime.Now < EndDate && DateTime.Now > StartDate;
        }

        public virtual string Salutation() // Since the behaviour of this function will depend on the kind of employee, we will use inheritence to override this function for the Architect and the Manager. Thus, we must make it virtual, so that this polymorphism can be done.
        {
            return "Hello, Employee!";
        }
    }
}
