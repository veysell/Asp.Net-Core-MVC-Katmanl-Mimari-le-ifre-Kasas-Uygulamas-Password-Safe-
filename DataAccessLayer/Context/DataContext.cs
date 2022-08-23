using EntitiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class DataContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Password> Passwords { get; set; }
    }
}
