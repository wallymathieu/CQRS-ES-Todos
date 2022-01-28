using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Infrastructure;
using Todo.QueryStack.Model;
using Web.UI.Models.TodoList;
using Web.UI.Worker;

namespace Web.UI.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly ToDoWorker Worker;

        public ToDoListController(ToDoWorker worker)
        {
            Contract.Requires<System.ArgumentNullException>(worker != null, "worker");
            Worker = worker;
        }

        ///////////////////////
        /// TODO -LISTS
        ///////////////////////
        #region TodoList Actions
        [Route("api/TodoList/List")]
        [HttpGet]
        public Task<List<ToDoList>> List()
        {
            return Worker.GetLists();
        }

        [Route("api/TodoList/ChangeDescription")]
        [HttpPost]
        public IActionResult ChangeDescription(ChangeTodoListDescriptionCommandModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Worker.ChangeToDoListDescription(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/TodoList/CreateNewList")]
        [HttpPost]
        public IActionResult CreateNewList(CreateTodoListCommandModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Worker.CreateToDoList(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Rebuild")]
        [HttpPost]
        public IActionResult Rebuild()
        {
            try
            {
                Worker.EventsRebuild();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        ///////////////////////
        /// TODO -ITEMS
        ///////////////////////
        #region ToDoItems Actions
        [Route("api/TodoList/Items/{Id}")]
        [HttpGet]
        public Task<ToDoList> Items(string Id)
        {
            return Worker.GetListItems(Id);
        }

        //http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2#route-names
        [Route("api/TodoItems/{Id}", Name = "GetTodoItemById")]
        [HttpGet]
        public Task<ToDoItem> GetTodoItem(string Id)
        {
            return Worker.GetToDoItem(Id);
        }

        [Route("api/TodoList/Items/{Id}/Add")]
        [HttpPost]
        public IActionResult AddItemToList(AddNewToDoItemCommandModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Worker.AddNewToDoItem(model);
                string uri = Url.Link("GetTodoItemById", new { Id = model.Id});
                return Redirect(uri);                
                //return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/TodoItems/MarkAsComplete")]
        [HttpPost]
        public IActionResult MarkToDoItemAsComplete(MarkToDoItemAsCompleteModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Worker.MarkToDoItemAsComplete(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/TodoItems/ReOpen")]
        [HttpPost]
        public IActionResult ReOpenToDoItem(ReOpenToDoItemModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Worker.ReOpenToDoItem(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/TodoItems/ChangeDescription")]
        [HttpPost]
        public IActionResult ChangeDescription(ChangeToDoItemDescriptionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Worker.ChangeDescription(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/TodoItems/ChangeImportance")]
        [HttpPost]
        public IActionResult ReOpenToDoItem(ChangeToDoItemImportanceModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Worker.ChangeImportance(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/TodoItems/ChangeDueDate")]
        [HttpPost]
        public IActionResult ChangeDueDate(ChangeToDoItemDueDateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Worker.ChangeDueDate(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
