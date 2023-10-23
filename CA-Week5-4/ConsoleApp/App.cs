using CA_Week5_4.clss;
using CA_Week5_4.Enums;
using CA_Week5_4.Exps;
using System;

namespace CA_Week5_4.ConsoleApp
{



    internal class App
    {

  
        private EWindowState WINDOW_STATE = EWindowState.Home;


        public static void Message(string msg, EMessageLevel lvl) {

            switch (lvl)
            {
                case EMessageLevel.Casual:
                    Console.WriteLine($"[*] - {msg}");
                    break;

                case EMessageLevel.Alert:
                    Console.Write($"\n!!! - {msg} - !!!\n");
                    break;

                case EMessageLevel.MenuSelection:
                    Console.WriteLine($"\\*/ {msg}");
                    break;

                case EMessageLevel.NewSection:
                    Console.Write($"\n\n\n-------- {msg} --------\n\n\n");
                    break;

                default:
                    throw new InvalidDataException();
            }
        }

        public void Start(Department department)
        {


            while (true)
            {

                try
                {
                    if(!_showWindow(department)) continue;
                }
                catch(EndProgramException)
                {
                    App.Message("Good Bye", EMessageLevel.Alert);
                    break;
                }
                

            }


        }

        private bool _inputValidator(string? input)
        {
            if (input == null || input.Length > 1) return false;

            return true;

        }

        private void _windowStateHandler(string? input) {

            switch (input)
            {
              
                case "1":
                    WINDOW_STATE = EWindowState.AddEmployee;
                    break;


                case "2":
                    WINDOW_STATE = EWindowState.SearchEmployee;
                    break;


                case "3":
                    WINDOW_STATE = EWindowState.ShowAllEmployees;
                    break;
              
                case "4":
                    WINDOW_STATE = EWindowState.SearchBySalary;
                    break;

                 
                case "5":
                    WINDOW_STATE = EWindowState.SearchByDepartmentName;
                    break;

                case "6":
                    WINDOW_STATE = EWindowState.SearchByEmployeePosition;
                    break;

                case "7":
                    WINDOW_STATE = EWindowState.FireEmployee;
                    break;

                case "0":
                    WINDOW_STATE = EWindowState.Exit;
                    break;

                default:
                    App.Message("Invalid Menu Number", EMessageLevel.Alert);
                    break;
            }

        }

        private bool _showWindow(Department department) {

            bool found = false ;

            switch (WINDOW_STATE)
            {
                case EWindowState.Home:

                    App.Message("MENU", EMessageLevel.NewSection);

                    App.Message("1) Add New Employee", EMessageLevel.MenuSelection);
                    App.Message("2) Search Employee", EMessageLevel.MenuSelection);
                    App.Message("3) Show Employees", EMessageLevel.MenuSelection);
                    App.Message("4) Search Employee By Salary Range", EMessageLevel.MenuSelection);
                    App.Message("5) Search Employee By Department Name", EMessageLevel.MenuSelection);
                    App.Message("6) Search Employee By Position", EMessageLevel.MenuSelection);
                    App.Message("7) Fire Employee :(", EMessageLevel.MenuSelection);
                    App.Message("0) Exit :<", EMessageLevel.MenuSelection);


                    string? userInput = Console.ReadLine()?.Trim().ToLower();

                    if (!_inputValidator(userInput)) return false;

                    _windowStateHandler(userInput);

                    break;

                case EWindowState.AddEmployee:

                    App.Message("ADD EMPLOYEE", EMessageLevel.NewSection);

                
                    App.Message("Enter Employee Name: ", EMessageLevel.Casual);

                    string? name = Console.ReadLine();

                    if (name == null || name.Trim().Length < 1)
                    {
                        App.Message("Invalid Name Value Retry ...", EMessageLevel.Alert);
                        return false;
                    }

                    App.Message("Enter Employee Age: ", EMessageLevel.Casual);
                    
                    string? age = Console.ReadLine();
                    int parsedAge;


                    if (age == null || !int.TryParse(age, out parsedAge))
                    {
                        App.Message("Invalid Age Value Retry ...", EMessageLevel.Alert);
                        return false;
                    }

                    App.Message("Enter Employee Salary: ", EMessageLevel.Casual);
                    
                    string? salary = Console.ReadLine();
                    double parsedSalary;


                    if (salary == null || !double.TryParse(salary, out parsedSalary))
                    {
                        App.Message("Invalid Salary Value Retry ...", EMessageLevel.Alert);
                        return false;
                    }


                    App.Message("Select Employee Position", EMessageLevel.Casual);

                    App.Message("1) Boss", EMessageLevel.Casual);
                    App.Message("2) Engineer", EMessageLevel.Casual);
                    App.Message("3) HR", EMessageLevel.Casual);

                    string? _ = Console.ReadLine();
                    EPosition position;

                    switch (_)
                    {
                        case null: return false;

                        case "1":
                            position = EPosition.Boss;
                            break;

                        case "2":
                            position = EPosition.Engineer;
                            break;

                        case "3":
                            position = EPosition.HR;
                            break;

                        default:
                            App.Message("Invalid Positin Value Retry...", EMessageLevel.Casual);
                            return false;

                    }



                    Employee e = new(name, parsedAge, parsedSalary, position);

                    try
                    {
                        department.AddEmployee(e);
                    }

                    catch (CapacityLimitException)
                    {
                        App.Message("Employee Capacity Exceeded", EMessageLevel.Alert);
                    }

                    WINDOW_STATE = EWindowState.Home;

                    break;

                case EWindowState.SearchByDepartmentName:
                    found = false;
                    foreach (Employee emp in department.GetEmployees())
                    {
                        found = true;
                        App.Message(emp.GetInfo(), EMessageLevel.Casual);
                    };

                    if (!found) App.Message("There is no employee", EMessageLevel.Alert);

                    WINDOW_STATE = EWindowState.Home;

                    break;

                case EWindowState.ShowAllEmployees:

                    App.Message("ALL EMPLOYEES", EMessageLevel.NewSection);

                    found = false;
                    foreach(Employee emp in department.Employees)
                    {
                        found = true;
                        App.Message(emp.GetInfo(), EMessageLevel.Casual);
                    }

                    if (!found) App.Message("There is no employee", EMessageLevel.Alert);

                    WINDOW_STATE = EWindowState.Home;

                    break;

                case EWindowState.SearchEmployee:

                    App.Message("SEARCH EMPLOOYE", EMessageLevel.NewSection);

                    App.Message("Enter Employee ID", EMessageLevel.Casual);

                    string? id = Console.ReadLine();
                    int parsedId;

                    if (id == null || !int.TryParse(id, out parsedId))
                    {
                        App.Message("Invalid Id Value Retry...", EMessageLevel.Casual);
                        return false;
                    }

                    Employee? empp = department.GetEmployee(parsedId);

                    if (empp != null)
                    {
                        App.Message(empp.GetInfo(), EMessageLevel.Casual);
                    }
                    else
                    {
                        App.Message($"There is no such employee id - {parsedId}", EMessageLevel.Alert);
                    }

                    WINDOW_STATE = EWindowState.Home;
                    break;

                case EWindowState.SearchByEmployeePosition:

                    App.Message("SEARCH EMPLOYEE BY POSITION", EMessageLevel.NewSection);



                    App.Message("Select Employee Position", EMessageLevel.Casual);

                    App.Message("1) Boss", EMessageLevel.Casual);
                    App.Message("2) Engineer", EMessageLevel.Casual);
                    App.Message("3) HR", EMessageLevel.Casual);

                    string? posValue = Console.ReadLine();
                    EPosition ePosition;

                    switch (posValue)
                    {
                        case null: return false;

                        case "1":
                            ePosition = EPosition.Boss;
                            break;

                        case "2":
                            ePosition = EPosition.Engineer;
                            break;

                        case "3":
                            ePosition = EPosition.HR;
                            break;

                        default:
                            App.Message("Invalid Positin Value Retry...", EMessageLevel.Casual);
                            return false;

                    }

                    foreach (Employee employee in department.GetEmployeesByPosition(ePosition))
                    {
                        found = true;
                        App.Message(employee.GetInfo(), EMessageLevel.Casual);
                    };

                    if (!found) App.Message("No Employee Found", EMessageLevel.Alert);


                    WINDOW_STATE = EWindowState.Home;
                    break;

                case EWindowState.SearchBySalary:

                    App.Message("SEARCH EMPLOYEE BY SALARY RANGE", EMessageLevel.NewSection);

                    App.Message("Enter min salary: ", EMessageLevel.Casual);

                    string min = Console.ReadLine();
                    double parsedMin;

                    if(min == null || !double.TryParse(min, out parsedMin))
                    {
                        App.Message("Invalid Minimum Salary Value Retry...", EMessageLevel.Casual);
                        return false;
                    }


                    App.Message("Enter max salary: ", EMessageLevel.Casual);

                    string max = Console.ReadLine();
                    double parsedMax;

                    if (max == null || !double.TryParse(max, out parsedMax))
                    {
                        App.Message("Invalid Maximum Salary Value Retry...", EMessageLevel.Casual);
                        return false;
                    }


                    foreach (Employee x in department.GetEmployeesBySalary(parsedMin, parsedMax)) {
                        found = true;
                        App.Message(x.GetInfo(), EMessageLevel.Casual);
                    };

                    if (!found) App.Message($"There is no employee in salary range {min} - {max}", EMessageLevel.Alert);


                    WINDOW_STATE = EWindowState.Home;
                    break;

                case EWindowState.FireEmployee:

                    App.Message("FIRE EMPLOYEE", EMessageLevel.NewSection);



                    App.Message("Enter Employee ID: ", EMessageLevel.Casual);

                    string? empId = Console.ReadLine();
                    int parsedEmpId;

                    if(empId == null || !int.TryParse(empId, out parsedEmpId))
                    {
                        App.Message("Invalid Employee Id Retry...", EMessageLevel.Alert);
                        return false;
                    }

                    try
                    {
                        department.RemoveEmployee(parsedEmpId);
                    }
                    catch(NoValidEmployeeException  exp){
                        App.Message($"There is no such employee ID: {empId}", EMessageLevel.Alert);
                        return false;
                    }


                    App.Message($"Removed employee ID: {empId}", EMessageLevel.Casual);


                    WINDOW_STATE = EWindowState.Home;
                    break;

                case EWindowState.Exit:
                    throw new EndProgramException();
            }


            return true;
        
        }


    }
}
