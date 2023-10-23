using CA_Week5_4.Enums;
using CA_Week5_4.Interfaces;
using System;


namespace CA_Week5_4.clss
{
    internal class Employee : IPerson
    {

        private static int _id = 1;

        public int Id { get; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        
        public EPosition Position { get; set; }



        public Employee(string? name, int age, double salary, EPosition pos)
        {
            Id = Employee._id;
            Name = name;
            Age = age;
            Salary = salary;
            Position = pos;

            Employee._id++;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Id} {Name} {Age} {Salary} {Position}");
        }

        public string GetInfo()
        {
            return $"{Id} {Name} {Age} {Salary} {Position}";
        }

        public override string ToString()
        {
            return GetInfo();
        }
    }
}
