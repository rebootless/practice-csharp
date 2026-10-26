using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritance
{
    class Person
    {
        string fam;
        int salary;
        int tab;

        public Person(string Fam, int Tab, int Salary)
        {
            fam = Fam;
            tab = Tab;
            salary = Salary;
        }

        public Person() { }

        public string Fam
        {
            set { if (fam == null) fam = value; }
            get { return fam; }
        }

        public int Tab
        {
            set { tab = value; }
            get { return tab; }
        }

        public int Salary
        {
            get { return salary; }
            set { if ((value > 13000) && (value < 17000)) salary = value; }
        }
    }

    class Manager : Person
    {
        string company;
        int sale;

        public Manager() { }

        public Manager(string Fam, int Tab, int Salary, string Company, int Sale)
            : base(Fam, Tab, Salary)
        {
            company = Company;
            sale = Sale;
        }

        public string Company
        {
            set { if (company == null) company = value; }
            get { return company; }
        }

        public int Sale
        {
            set { sale = value; }
            get { return sale; }
        }

        public double Bonus
        {
            get { return sale * 0.05; }
        }

        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine("Surname: " + base.Fam);
            Console.WriteLine("Personnel number: " + base.Tab);
            Console.WriteLine("Salary: " + base.Salary);
            Console.WriteLine("Sales volume: " + sale);
            Console.WriteLine("Bonus: " + Bonus);
            double sum = Bonus + base.Salary;
            Console.WriteLine("Total salary: " + sum);
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
            Manager m = new Manager("Ivanov", 101, 20000, "Eldorado", 500000);
            m.Show();

            Manager[] pr = new Manager[99];
            for (i = 0; i < 99; i++)
                pr[i] = new Manager();

            string subkey, key;

            do
            {
                Console.WriteLine();
                Console.WriteLine("====== Menu ======");
                Console.WriteLine("1 - Enter data");
                Console.WriteLine("2 - Show data");
                Console.WriteLine("3 - Search by personnel number");
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
                                Console.WriteLine("Array is full (maximum 99 records)!");
                                break;
                            }

                            pr[n].Fam = ReadString("Enter surname: ");
                            pr[n].Tab = ReadInt("Enter personnel number: ");
                            pr[n].Salary = ReadInt("Enter salary: ");
                            pr[n].Company = ReadString("Enter company: ");
                            pr[n].Sale = ReadInt("Enter sales volume: ");

                            n++;

                            Console.Write("Continue? [y/N]: ");
                            subkey = Console.ReadLine()?.Trim().ToLower();
                        } while (subkey == "y");
                        break;

                    case "2":
                        for (i = 0; i < n; i++)
                        {
                            pr[i].Show();
                        }
                        break;

                    case "3":
                        {
                            bool found = false;
                            int num = ReadInt("Enter personnel number: ");

                            for (i = 0; i < n; i++)
                            {
                                if (pr[i].Tab == num)
                                {
                                    Console.WriteLine("Surname = {0}, personnel number = {1}, bonus = {2}",
                                        pr[i].Fam, pr[i].Tab, pr[i].Bonus);
                                    found = true;
                                }
                            }

                            if (!found)
                                Console.WriteLine("No person with this personnel number!");
                        }
                        break;
                }
            } while (key != "4");
        }
    }
}