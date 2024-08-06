using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public ICollection<Project> Projects { get; set; }


        public override string ToString()
        {
            return $"Id: {Id} Full name: {FullName} Role: {Role}";
        }
    }
}
