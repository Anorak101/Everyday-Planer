using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace PlanerFrontEnd.Services
{
    internal class TaskToDoService
    {
        private List<TaskToDo> tasks = new List<TaskToDo>();

        private HttpClient? httpClient;

        private const string sApiUrl = "http://192.168.178.50:5110/api/tasks"; 

        SocketsHttpHandler socketHandler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(15)
        };

        private  async Task<string> updateTasks() 
        {
            httpClient = new HttpClient(socketHandler);
            string json = "lol get fucked"; 
            try
            {
                json = await httpClient.GetStringAsync(sApiUrl);
                //Console.WriteLine(json);
                            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                
            }
            return json;
        }

        public async  Task<List<TaskToDo>> getUpdatedTasksAsync()
        {
            Task<string> resultingTask = updateTasks();
            string json = await resultingTask;
            Console.WriteLine(json);
            tasks = JsonConvert.DeserializeObject<List<TaskToDo>>(json); 
            return tasks;
        }
    }
}
