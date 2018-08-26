using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatcherServiceApp
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext():base("DefaultConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
