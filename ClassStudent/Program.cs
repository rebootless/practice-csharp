using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStudent
{
    class Program
    {
        class Student
        {
            public string firstName;
            public string lastName;
            public string faculty;
            public int yearIn;
            public int curs;

            public Student()
            {
                Console.WriteLine("Input First name:");
                firstName = Console.ReadLine();

                Console.WriteLine("Input Last name:");
                lastName = Console.ReadLine();

                Console.WriteLine("Input Faculty:");
                faculty = Console.ReadLine();

                Console.WriteLine("Input Admission year:");
                yearIn = int.Parse(Console.ReadLine());

                Console.WriteLine("Input Course:");
                curs = int.Parse(Console.ReadLine());

                Console.WriteLine("First name: " + firstName);
                Console.WriteLine("Last name: " + lastName);
                Console.WriteLine("Faculty: " + faculty);
                Console.WriteLine("Admission year: " + yearIn);
                Console.WriteLine("Course: " + curs);
            }
        }

        public static void Main(string[] args)
        {
            Student student = new Student();
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
