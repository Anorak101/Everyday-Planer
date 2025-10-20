using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Entities;
using Common.TransferObjects;
using Newtonsoft.Json;

namespace PlanerBackEnd.Controllers
{
    [Route("api/IToDo/")]
    [ApiController]
    public class IToDoController : ControllerBase
    {
        static private List<IToDo> tasksToDo = new List<IToDo>  
        {
            new SingeToDo(0, "AHH", new DateOnly(2000, 10, 10), false),
            new SingeToDo(1, "AHH2", new DateOnly(2000, 10, 10), false)
        };
            
        
        

        [HttpGet]
        public ActionResult<List<TaskToDo>> GetTasksToDo()
        {
            List<ToDoDTO> tasksDTO = new List<ToDoDTO>();
            foreach (IToDo toDo in tasksToDo)
            {
                tasksDTO.Add(toDo.createToDoDTO());
            }
            return (Ok(tasksDTO));
        }


        [HttpGet("{id}")]
        public ActionResult<ToDoDTO> getTaskById(int id)
        {
            IToDo task = tasksToDo.FirstOrDefault(x => x.getId() == id);
            if (task == null)
            {
                return NotFound();
            }
            return (Ok(task.createToDoDTO()));
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
            ToDoDTO task = JsonConvert.DeserializeObject<ToDoDTO>(sJsonBody);
            if (task != null)
            {
                tasksToDo.Add(task.toIToDo());
                oResult = CreatedAtAction(nameof(AddTaskToDo), task);
            }

            return oResult;

        }

        [HttpDelete]
        public IActionResult DeleteTaskToDo(int id)
        {
            IActionResult oResult = NotFound();
            
            IToDo task = tasksToDo.FirstOrDefault(x => x.getId() == id);
            if (task != null)
            {
                tasksToDo.Remove(task); 
                oResult = Ok();
            }
            return oResult; 
        }

        [HttpPut]
        public IActionResult UpdateTaskToDo()
        {
            IActionResult oResult = new BadRequestResult();
            string sJsonBody;
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                sJsonBody = reader.ReadToEndAsync().Result;
            }
            ToDoDTO task = JsonConvert.DeserializeObject<ToDoDTO>(sJsonBody);
            
            IToDo tempTask = tasksToDo.FirstOrDefault(x => x.getId() == task.nID);
            if (tempTask != null)
            {
                tasksToDo.Remove(tempTask);
                tasksToDo.Add(task.toIToDo());
                oResult = Ok();
            }
            return oResult; 
        }

    }
    
}
