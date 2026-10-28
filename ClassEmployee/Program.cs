using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClassEmployee
{
    class Employee
    {
        string fullName;
        int empID;
        double currPay;
        public Employee() { }
        public Employee(string fullName, int empID, double currPay)
        {
            this.fullName = fullName;
            this.empID = empID;
            this.currPay = currPay;
        }
        public string Name
        {
            set { if (fullName == null) fullName = value; }
            get { return fullName; }
        }
        public int ID
        {
            set { empID = value; }
            get { return empID; }
        }
        public double Pay
        {
            set { currPay = value; }
            get { return currPay; }
        }
        public void GiveBonus(double amount)
        {
            currPay += amount;
        }
        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Pay: " + Pay);
        }
    }
    class Program
    {
        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (int.TryParse(s, out int value))
                    return value;
                Console.WriteLine("Error: please enter an integer!");
            }
        }
        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (double.TryParse(s, out double value))
                    return value;
                Console.WriteLine("Error: please enter a number!");
            }
        }
        static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(s))
                    return s.Trim();
                Console.WriteLine("Error: field cannot be empty!");
            }
        }
        static void Main(string[] args)
        {
            int n = 0, i;
            Employee emp = new Employee("John Smith", 1001, 45000.0);
            emp.Show();
            Employee[] employees = new Employee[99];
            for (i = 0; i < 99; i++)
                employees[i] = new Employee();
            string subkey, key;
            do
            {
                Console.WriteLine();
                Console.WriteLine("====== Menu ======");
                Console.WriteLine("1 - Enter data");
                Console.WriteLine("2 - Show data");
                Console.WriteLine("3 - Give bonus");
                Console.WriteLine("4 - Exit");
                Console.WriteLine("==================");
                Console.WriteLine();
                Console.Write("Your choice: ");
                key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        do
                        {
                            if (n >= 99)
                            {
                                Console.WriteLine("Array is full");
                                break;
                            }
                            employees[n].Name = ReadString("Enter name: ");
                            employees[n].ID = ReadInt("Enter ID: ");
                            employees[n].Pay = ReadDouble("Enter pay: ");
                            n++;
                            Console.Write("Continue? [y/N]: ");
                            subkey = Console.ReadLine()?.Trim().ToLower();
                        } while (subkey == "y");
                        break;
                    case "2":
                        for (i = 0; i < n; i++)
                        {
                            employees[i].Show();
                        }
                        break;
                    case "3":
                        {
                            bool found = false;
                            int id = ReadInt("Enter employee ID: ");
                            for (i = 0; i < n; i++)
                            {
                                if (employees[i].ID == id)
                                {
                                    double bonus = ReadDouble("Enter bonus amount: ");
                                    employees[i].GiveBonus(bonus);
                                    Console.WriteLine("Bonus added. New pay: " + employees[i].Pay);
                                    found = true;
                                }
                            }
                            if (!found)
                                Console.WriteLine("No employee with this ID!");
                        }
                        break;
                }
            } while (key != "4");
        }
    }
}