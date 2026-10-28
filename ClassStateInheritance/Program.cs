using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClassState
{
    class Country
    {
        protected string countryCode;
        protected string countryName;
        protected string establishmentYear;
        protected string governmentForm;
        protected int population;
        protected double gdp;
        protected double nationalDebt;
        public Country() { }
        public Country(string countryCode, string countryName, string establishmentYear,
                       string governmentForm, int population, double GDP, double nationalDebt)
        {
            this.countryCode = countryCode;
            this.countryName = countryName;
            this.establishmentYear = establishmentYear;
            this.governmentForm = governmentForm;
            this.population = population;
            this.gdp = GDP;
            this.nationalDebt = nationalDebt;
        }
        public string CountryCode
        {
            set { if (countryCode == null) countryCode = value; }
            get { return countryCode; }
        }
        public string CountryName
        {
            set { if (countryName == null) countryName = value; }
            get { return countryName; }
        }
        public string EstablishmentYear
        {
            set { establishmentYear = value; }
            get { return establishmentYear; }
        }
        public string GovernmentForm
        {
            set { governmentForm = value; }
            get { return governmentForm; }
        }
        public int Population
        {
            set { population = value; }
            get { return population; }
        }
        public double GDP
        {
            set { gdp = value; }
            get { return gdp; }
        }
        public double NationalDebt
        {
            set { nationalDebt = value; }
            get { return nationalDebt; }
        }
        public virtual double DebtToGdpPercent
        {
            get
            {
                if (gdp == 0) return 0;
                return (nationalDebt / gdp) * 100;
            }
        }
        public virtual void Show()
        {
            Console.WriteLine();
            Console.WriteLine("Country name: " + CountryName);
            Console.WriteLine("Country code: " + CountryCode);
            Console.WriteLine("Established: " + EstablishmentYear);
            Console.WriteLine("Government form: " + GovernmentForm);
            Console.WriteLine("Population: " + Population);
            Console.WriteLine("GDP: " + GDP);
            Console.WriteLine("National debt: " + NationalDebt);
            Console.WriteLine("Debt to GDP: " + DebtToGdpPercent.ToString("F2") + "%");
        }
    }
    class State : Country
    {
        public State() : base() { }
        public State(string countryCode, string countryName, string establishmentYear,
                     string governmentForm, int population, double GDP, double nationalDebt)
            : base(countryCode, countryName, establishmentYear, governmentForm, population, GDP, nationalDebt)
        {
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
            State usa = new State("US", "United States", "1776", "Federal Republic", 331000000, 25462.0, 31000.0);
            usa.Show();
            State[] states = new State[99];
            for (i = 0; i < 99; i++)
                states[i] = new State();
            string subkey, key;
            do
            {
                Console.WriteLine();
                Console.WriteLine("====== Menu ======");
                Console.WriteLine("1 - Enter data");
                Console.WriteLine("2 - Show data");
                Console.WriteLine("3 - Search by country code");
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
                            states[n].CountryCode = ReadString("Enter country code: ");
                            states[n].CountryName = ReadString("Enter country name: ");
                            states[n].EstablishmentYear = ReadString("Enter establishment year: ");
                            states[n].GovernmentForm = ReadString("Enter government form: ");
                            states[n].Population = ReadInt("Enter population: ");
                            states[n].GDP = ReadDouble("Enter GDP: ");
                            states[n].NationalDebt = ReadDouble("Enter national debt: ");
                            n++;
                            Console.Write("Continue? [y/N]: ");
                            subkey = Console.ReadLine()?.Trim().ToLower();
                        } while (subkey == "y");
                        break;
                    case "2":
                        for (i = 0; i < n; i++)
                        {
                            states[i].Show();
                        }
                        break;
                    case "3":
                        {
                            bool found = false;
                            string code = ReadString("Enter country code: ");
                            for (i = 0; i < n; i++)
                            {
                                if (states[i].CountryCode != null &&
                                    states[i].CountryCode.Equals(code, StringComparison.OrdinalIgnoreCase))
                                {
                                    Console.WriteLine("Country = {0}, Code = {1}, Debt to GDP = {2:F2}%",
                                        states[i].CountryName, states[i].CountryCode, states[i].DebtToGdpPercent);
                                    found = true;
                                }
                            }
                            if (!found)
                                Console.WriteLine("No country with this code!");
                        }
                        break;
                }
            } while (key != "4");
        }
    }
}