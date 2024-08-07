using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
