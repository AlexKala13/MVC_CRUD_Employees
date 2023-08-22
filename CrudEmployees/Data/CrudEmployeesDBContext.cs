using CrudEmployees.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudEmployees.Data
{
    public class CrudEmployeesDBContext : DbContext
    {
        public CrudEmployeesDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }
    }
}
