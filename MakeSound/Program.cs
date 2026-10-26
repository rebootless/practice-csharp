using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSound
{
    class Animal
    {
        private string name;

        public virtual void MakeSound()
        {
            Console.WriteLine("Some sound...");
        }

        public void SetName()
        {
            Console.Write("Enter the name: ");
            name = Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Animal animal = new Animal();
            animal.SetName();
            animal.MakeSound();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}

