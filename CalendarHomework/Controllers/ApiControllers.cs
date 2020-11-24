
using Microsoft.AspNetCore.Mvc;
using Calendar.Models;
using System.Collections.Generic;
using System.Linq;

namespace Calendar.Controllers 
{

    public class ApiController : Controller
    {

        private DataContext dbContext;

        public ApiController(DataContext db)
        {
            this.dbContext = db; 
        }


        [HttpPost]
        public IActionResult SaveTask([FromBody] Task theTask)
        {


            //save it
                dbContext.Tasks.Add(theTask);
                dbContext.SaveChanges();

            //return
            return Json(theTask);
        }
        [HttpGet]
        public IActionResult GetTasks()
        {
           var allTasks = dbContext.Tasks.ToList();
           return Json(allTasks);
        }


        public IActionResult Test()
        {
            return Content("Hello FSD01");
        }
    }
}