using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Entities;
using Newtonsoft.Json;

namespace PlanerBackEnd.Controllers
{
    [Route("api/Tasks/")]
    [ApiController]
    public class TaskToDoController : ControllerBase
    {
        static private List<TaskToDo> tasksToDo = new List<TaskToDo>
        {
            new TaskToDo(0, "task 0", new DateOnly(2025,10,10)),
            new TaskToDo(1, "task 1", new DateOnly(2025,10,10)),
            new TaskToDo(2, "task 2", new DateOnly(2025,10,10)),
            new TaskToDo(3, "task 3", new DateOnly(2025,10,10)),
            new TaskToDo(4, "task 4", new DateOnly(2025,10,10))
        };

        [HttpGet]
        public ActionResult<List<TaskToDo>> GetTasksToDo()
        {
            Console.Write("Get Request reieved"); 
            return (Ok(tasksToDo));
        }


        [HttpGet("{id}", Name = "GetTasks")]
        public ActionResult<TaskToDo> getTaskToDoById(int id)
        {
            TaskToDo task = tasksToDo.FirstOrDefault(x => x.nId == id);
            if (task == null)
            {
                return NotFound();
            }
            return (Ok(task));
        }

        [HttpPost]
        public IActionResult AddTaskToDo()
        {
            IActionResult oResult = new BadRequestResult();
            string sJsonBody;
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                sJsonBody = reader.ReadToEndAsync().Result;
            }
            Console.WriteLine(sJsonBody);
            TaskToDo task = JsonConvert.DeserializeObject<TaskToDo>(sJsonBody);
            if (task != null)
            {
                tasksToDo.Add(task);
                oResult = CreatedAtAction(nameof(AddTaskToDo), task);
            }

            return oResult;

        }

        [HttpPost("isRepeating")]
        public IActionResult AddTaskToDoRepeating()
        {
            IActionResult oResult = new BadRequestResult();
            string sJsonBody;
            using (StreamReader reader = new StreamReader(Request.Body)) 
            {
                sJsonBody = reader.ReadToEndAsync().Result; 
            }
            Console.WriteLine(sJsonBody); 
            TaskToDo task = JsonConvert.DeserializeObject<TaskToDo>(sJsonBody);
            if (task != null)
            {
                tasksToDo.Add(task);
                oResult = CreatedAtAction(nameof(AddTaskToDoRepeating), task);
            }

            return oResult; 

        }

    }
}
