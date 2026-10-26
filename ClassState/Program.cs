using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassState
{
    class Program
    {
        public class State
        {
            private string countryCode;
            private string countryName;
            private string establishmentYear;
            private string governmentForm;
            private int population;
            private double gdp;
            private double nationalDebt;

            public State() { }

            public State(string countryCode, string countryName, string establishmentYear,
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
                get { return countryCode; }
                set { countryCode = value; }
            }

            public string CountryName
            {
                get { return countryName; }
                set { countryName = value; }
            }

            public string EstablishmentYear
            {
                get { return establishmentYear; }
                set { establishmentYear = value; }
            }

            public string GovernmentForm
            {
                get { return governmentForm; }
                set { governmentForm = value; }
            }

            public int Population
            {
                get { return population; }
                set { population = value; }
            }

            public double GDP
            {
                get { return gdp; }
                set { gdp = value; }
            }

            public double NationalDebt
            {
                get { return nationalDebt; }
                set { nationalDebt = value; }
            }

            public void DisplayInfo()
            {
                Console.WriteLine("Name: {0}", countryName);
                Console.WriteLine("Code: {0}", countryCode);
                Console.WriteLine("Established: {0}", establishmentYear);
                Console.WriteLine("Government: {0}", governmentForm);
                Console.WriteLine("Population: {0}", population);
                Console.WriteLine("GDP: {0}", GDP);
                Console.WriteLine("National Debt: {0}", nationalDebt);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine();

            State usa = new State("US", "United States", "1776", "Federal Republic", 331000000, 25462.0, 31000.0);
            usa.DisplayInfo();

            usa.Population = 340000000;
            usa.GDP = 27000.0;
            usa.NationalDebt = 35000.0;

            Console.WriteLine();

            Console.WriteLine("Redacted:");

            Console.WriteLine();

            usa.DisplayInfo();

            Console.WriteLine();

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}