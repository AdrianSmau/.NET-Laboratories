using System;

namespace Tema1
{
    class Program
    {
        static void Main()
        {
            Employee manager = new Manager
            {
                FirstName = "Andrei",
                LastName = "Mosor",
                StartDate = new DateTime(2020, 01, 01, 00, 00, 00),
                EndDate = new DateTime(2020, 12, 12, 00, 00, 00)
            };
            Console.WriteLine(manager.GetFullName() + " is active ? " + manager.IsActive());
            Console.WriteLine("How do we salute " + manager.GetFullName() + " ? " + manager.Salutation());
            Employee arch = new Architect
            {
                FirstName = "Adrian",
                LastName = "Smau"
            };
            Console.WriteLine("How do we salute " + arch.GetFullName() + " ? " + arch.Salutation());
            Console.WriteLine("Using an extention method, we will split a phrase into words, using the implemented ExtentionClass.");
            string[] foundWords = manager.SplitIntoWords("Let's split this phrase into words, see if it works!");
            foreach (string x in foundWords) {
                Console.WriteLine(x);
            }
        }
    }
}
