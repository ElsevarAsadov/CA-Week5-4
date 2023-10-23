using CA_Week5_4.Enums;
using CA_Week5_4.Exps;
using System;

namespace CA_Week5_4.clss
{
    internal class Department
    {
        private static int _id = 1;

        private static int _count = 0;

        public Employee[] Employees = new Employee[0];
        public int Id { get; }
        public string? Name { get; set; }
        public int EmployeeLimit { get; set; }


        public Department(string? name, int empLimit) 
        {
            Id = Department._id;
            Name = name;
            EmployeeLimit = empLimit;

            Department._id++;
            Department._count++;
        }

        public void AddEmployee(Employee e)
        {
            if (EmployeeLimit < _count) throw new CapacityLimitException("Employee Capacity Exceeded.") ;
            Utils.PushEmployee(ref Employees, e);
            Department._count++;
        }
        public void RemoveEmployee(int id)
        {
            Utils.RemoveEmployee(ref Employees, id);
            Department._count--;
        }

        public Employee? GetEmployee(int id)
        {

            foreach (Employee e in Employees)
            {
                if (e.Id == id) return e;
            }

            return null;

        }

        public Employee[]? GetEmployeesBySalary(double min, double max) {
            
            Employee[] emps = new Employee[0];

            foreach(Employee e in Employees)
            {
                if(e.Salary >= min && e.Salary <= max)
                {
                    Utils.PushEmployee(ref emps, e);
                }
            }


            return emps;
        }

        //??? why
       /* public Employee[]? GetEmployeesByDepartmentName(string depName)
        {

            Employee[] emps = new Employee[0];

            foreach (Employee e in Employees)
            {
                //??? why
                if (Name == depName)
                {
                    Utils.PushEmployee(ref emps, e);
                    //return Employees
                }
            }


            return emps;
        }*/

        public Employee[]? GetEmployees()
        {
            return Employees;

        }

        public Employee[]? GetEmployeesByPosition(EPosition pos)
        {
            Employee[] emps = new Employee[0];

            foreach (Employee e in Employees)
            {
             
                if (e.Position == pos)
                {
                    Utils.PushEmployee(ref emps, e);
                }
            }


            return emps;
        }

        public Employee? this[int idx]
        {
            get 
            {
                return idx < Employees.Length - 1 ? Employees[idx] : throw new IndexOutOfRangeException();
            }
            set
            {
                if(idx > Employees.Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                if( !(value is Employee) ) {

                    throw new NoValidEmployeeException("Provided value is not valid Employee type.");
                }

                Employees[idx] = value;
            }
        }

    }
}
