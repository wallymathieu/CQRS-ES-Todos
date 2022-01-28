using System;
using Microsoft.AspNetCore.Mvc;
using Todo.Infrastructure;
using Todo.Legacy.Migration.Worker;

namespace Web.UI.Controllers
{
    public class MigrationController : Controller
    {
        private readonly LegacyMigrationWorker Worker;

        public MigrationController(LegacyMigrationWorker worker)
        {
            Contract.Requires<System.ArgumentNullException>(worker != null, "worker");
            Worker = worker;
        }

        [Route("api/Migrate")]
        [HttpPost]
        public IActionResult Migrate()
        {
            try
            {
                Worker.ExecuteMigration();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
