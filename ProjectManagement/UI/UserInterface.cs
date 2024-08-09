using ProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProjectManagement.UI
{
    //TODO FINISH INTERAFACE
    public class UserInterface
    {
        private int _choice;

        private readonly ProjectService _projectService;
        private readonly EmployeeService _employeeService;
        private readonly ProjectTaskService _projectTaskService;
        private readonly ApplicationDbContext _context;
        public UserInterface(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _projectService = new ProjectService(_context);
            _employeeService = new EmployeeService(_context);
            _projectTaskService = new ProjectTaskService(_context);
        }

        public void Run()
        {
            bool issLogged = true;
            do
            {
                Console.WriteLine("---Project Management Application---");

                Console.WriteLine("Choose subject to manage\n1-Projects\n2-Employees\n3-Exit program");

                while (!int.TryParse(Console.ReadLine(), out _choice) || _choice < 1 || _choice > 3)
                {
                    Console.WriteLine("Choose Projects (1) or Employees (2)");
                }

                switch (_choice)
                {
                    case 1:
                        Console.Clear();
                        ProjecstManagementInterace();
                        break;
                    case 2:
                        Console.Clear();
                        EmployeesManagementInterface();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("blebleble");
                        break;
                }
            } while (issLogged);
        }

        private void ProjecstManagementInterace()
        {
            bool _projectPanel = true;
            string name;

            while (_projectPanel == true)
            {
                Console.WriteLine("---Projects Management---");

                Console.WriteLine("Choose option \n1-Add Project\n2-Remove Project\n3-Display Porjects List\n4-Back to main panel");

                while (!int.TryParse(Console.ReadLine(), out _choice) || _choice < 1 || _choice > 4)
                {
                    Console.WriteLine("Choose option Add(1), Remove(2), Get List(3)");
                }

                switch (_choice)
                {
                    case 1:
                        Console.Write("Name for project: ");
                        name = Console.ReadLine();
                        _projectService.AddProject(name);
                        break;
                    case 2:
                        Console.WriteLine("Enter name of the project to remove");
                        name = Console.ReadLine();
                        _projectService.RemoveProject(name);
                        break;
                    case 3:
                        Console.WriteLine("------");
                        _projectService.DisplayListOfProjects();
                        Console.WriteLine("------");
                        break;
                    case 4:
                        _projectPanel = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void EmployeesManagementInterface()
        {
            bool _employeePanel = true;
            int id, employeeId,projectId;

            while (_employeePanel == true)
            {
                Console.WriteLine("---Employees Management---");

                Console.WriteLine("Choose option \n1-Add Employee\n2-Remove Employee\n3-Display Employee List\n4-Add Employee to Project\n5-Remove Employee from Project\n6-Back to main panel");

                while (!int.TryParse(Console.ReadLine(), out _choice) || _choice < 1 || _choice > 6)
                {
                    Console.WriteLine("Invalid input");
                }

                switch (_choice)
                {
                    case 1:
                        Console.WriteLine("Enter full name of employee");
                        string fullName = Console.ReadLine();
                        Console.WriteLine("Enter his role");
                        string role = Console.ReadLine();
                        _employeeService.AddEmployee(fullName, role);
                        break;
                    case 2:
                        Console.WriteLine("Enter id of employee to remove");
                        while (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.WriteLine("Invalid input");
                        }
                        _employeeService.RemoveEmployee(id);
                        break;
                    case 3:
                        Console.WriteLine("------");
                        _employeeService.DisplayListOfEmployees();
                        Console.WriteLine("------");
                        break;
                    case 4:
                        Console.WriteLine("Enter id of employee");
                        while (!int.TryParse(Console.ReadLine(), out employeeId))
                        {
                            Console.WriteLine("Invalid input");
                        }
                        Console.WriteLine("Enter id of project");
                        while (!int.TryParse(Console.ReadLine(), out projectId))
                        {
                            Console.WriteLine("Invalid input");
                        }
                        _employeeService.AddEmployeeToProject(employeeId, projectId);
                        break;
                    case 5:
                        Console.WriteLine("Enter id of employee");
                        while (!int.TryParse(Console.ReadLine(), out employeeId))
                        {
                            Console.WriteLine("Invalid input");
                        }
                        Console.WriteLine("Enter id of project");
                        while (!int.TryParse(Console.ReadLine(), out projectId))
                        {
                            Console.WriteLine("Invalid input");
                        }
                        _employeeService.RemoveEmployeeFromProject(employeeId, projectId);
                        break;
                    case 6:
                        _employeePanel = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
