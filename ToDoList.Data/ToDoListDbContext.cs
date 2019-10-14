using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListData.Entities;

namespace ToDoListData
{
    public class ToDoListDbContext:DbContext
    {
        public ToDoListDbContext()
        {
            Database.SetInitializer<ToDoListDbContext>(null);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoListItem> ToDoListItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
