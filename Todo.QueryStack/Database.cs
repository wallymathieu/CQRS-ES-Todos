using System.Linq;
using Todo.QueryStack.Logic.Services;
using Todo.QueryStack.Model;

namespace Todo.QueryStack
{
    public class Database : IDatabase
    {
        private ToDoContext Context;
        private readonly IIdentityMapper _identityMapper;

        public Database(IIdentityMapper identityMapper)
        {
            _identityMapper = identityMapper;
            Context = new ToDoContext();
            //Context.Configuration.AutoDetectChangesEnabled = false;
            // Lazy loading is turned off
            //Context.Configuration.LazyLoadingEnabled = false;
            //Context.Database.Log = s => { System.Diagnostics.Debug.WriteLine(s); }; ; 

        }

        public IQueryable<ToDoList> ToDoLists
        {
            get
            {
                return from list in Context.Lists
                       join map in Context.IdMap on list.Id equals map.ModelId
                       where map.TypeName.Equals("ToDoList")
                       orderby list.Id
                       select list;
            }
            //get { return Context.Lists; }
        }

        public IQueryable<ToDoItem> ToDoItems
        {
            get { return Context.Items; }
        }

        public IIdentityMapper IdMaps
        {
            get { return _identityMapper; }
        }

    }
}
