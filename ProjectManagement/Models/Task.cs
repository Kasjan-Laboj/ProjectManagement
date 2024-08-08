using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    //TODO AFTER 1.0 EXPAND
    /// <summary>
    /// Future development
    /// Employees will have tasks in projects to do 
    /// </summary>
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
