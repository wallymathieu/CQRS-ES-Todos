using Microsoft.EntityFrameworkCore;
using Todo.QueryStack.Model;

namespace Todo.QueryStack
{
    public class ToDoContext : DbContext
    {

        public virtual DbSet<ToDoList> Lists { get; set; }

        public virtual DbSet<ToDoItem> Items { get; set; }

        public virtual DbSet<IdentityMap> IdMap { get; set; }

        public virtual DbSet<Checkpoint> Checkpoints { get; set; }
    }
}
