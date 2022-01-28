﻿using System.Linq;
using Todo.QueryStack;
using Todo.QueryStack.Logic.Services;
using Todo.QueryStack.Model;

namespace Todo.Legacy.Migration.Infrastructure
{
    public class LegacyDatabase: IDatabase
    {
        private ToDoContext Context;
        private readonly IIdentityMapper _identityMapper;

        public LegacyDatabase(IIdentityMapper identityMapper)
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
            get { return Context.Lists; }
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
