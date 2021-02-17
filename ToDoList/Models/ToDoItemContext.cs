using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Model
{
    public class ToDoItemContext : DbContext
    {
        public DbSet<ToDoItem> Items { get; set; }

        public ToDoItemContext(DbContextOptions<ToDoItemContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
