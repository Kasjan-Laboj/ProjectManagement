using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Services
{
    public class ProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddProject(string name)
        {
            try
            {
                var project = new Project()
                {
                    Name = name,
                };

                _context.Projects.Add(project);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database update error occurred: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while adding the project: {ex.Message}");
            }
        }

        public void RemoveProject(string name)
        {
            try
            {
                var project = _context.Projects.Find(name);

                if (project == null)
                {
                    Console.WriteLine($"Project with {name} not found");
                    return;
                }

                _context.Projects.Remove(project);
                _context.SaveChanges();

                Console.WriteLine("Project removed successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
