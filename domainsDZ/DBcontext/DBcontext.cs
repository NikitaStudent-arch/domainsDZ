using domainsDZ.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace domainsDZ.DBcontext
{
    public class DBcontext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=COMP1M;Database=Blog_Code_First;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}