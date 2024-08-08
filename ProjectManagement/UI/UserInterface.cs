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
        private readonly ApplicationDbContext _context;
        private int _choice;
        public UserInterface(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public void Run()
        {
            bool issLogged = true;
            do
            {
                Console.WriteLine("---Project Management Application---");

                Console.WriteLine("Choose subject to manage\n1-Projects\n2-Employees");
                
                while (!int.TryParse(Console.ReadLine(), out _choice))
                {
                    Console.WriteLine("Choose Projects (1) or Employees (2)");
                }

                switch (_choice)
                {
                    case 1:
                        //project interface
                        break;
                    case 2:
                        //employee interface cahnge to methode
                        break;
                    default:
                        Console.WriteLine("blebleble");
                        break;
                }

            } while (issLogged);
        }

        private void ProjecstManagementInterace()
        {
            Console.WriteLine("---Projects Management---");

            Console.WriteLine("Choose option \n1-Add Project\n2-Remove Project\n3-Display Porjects List");

            while (!int.TryParse(Console.ReadLine(), out _choice) || _choice > 0 || _choice < 2)
            {
                Console.WriteLine("Choose option Add(1), Remove(2), Get List(3)");
            }
        }

        private void EmployeesManagementInterface()
        {
            Console.WriteLine("---Employees Management---");

            //while (!int.TryParse(Console.ReadLine(), out _choice) || _choice > 0 || _choice < 6)
            //{
            //    //Console.WriteLine("Choose option Add(1), Remove(2), Get List(3)");
            //}
        }
    }
}
