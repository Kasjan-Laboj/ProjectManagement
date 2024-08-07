using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjectManagement.Services
{
    public class EmployeeService
    {
        
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddEmployee(string name, string role)
        {
            try
            {
                var employee = new Employee()
                {
                    FullName = name,
                    Role = role
                };

                _context.Employees.Add(employee);
                _context.SaveChanges();

                Console.WriteLine($"Employee {name} added succesfully");
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database update error occurred: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while adding the employee: {ex.Message}");
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);

                if (employee == null)
                {
                    Console.WriteLine($"Employee with {id} not found");
                    return;
                }

                _context.Employees.Remove(employee);
                _context.SaveChanges();

                Console.WriteLine("Employee removed successsfully");
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database update error occurred: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while removing the employee: {ex.Message}");
            }
        }

        public void GetListOfEmployees()
        {
            try
            {
                var employees = _context.Employees.ToList();

                if (employees == null)
                {
                    Console.WriteLine("We dont have employees");
                    return;
                }

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error occurred: {dbEx.Message}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddEmployeeToProject(int employeeId, int projectId)
        {
            try
            {
                var employee = _context.Employees.Find(employeeId);
                var project = _context.Projects
                                  .Include(p => p.Employees)
                                  .FirstOrDefault(p => p.Id == projectId);

                if (employee == null || project == null)
                {
                    Console.WriteLine($"Employee or Project not found");
                    return;
                }

                if (!project.Employees.Contains(employee))
                {
                    project.Employees.Add(employee);
                    _context.SaveChanges();
                    Console.WriteLine($"Employee {employee.FullName} added to project {project.Name}");
                }
                else
                {
                    Console.WriteLine($"{employee.FullName} is already assigned to this project");
                }
            }
            catch (DbUpdateException dbUEx)
            {
                Console.WriteLine($"Database update error occurred: {dbUEx.Message}");
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error occurred: {dbEx.Message}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveEmployeeFromProject(int employeeId, int projectId)
        {

        }
    }
}
