using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.TransferObjects;

namespace Common.Entities
{
    public interface IToDo
    {
        uint getId(); 
        string getName();
        DateOnly getDate();
        bool getOverdue();
        ToDoDTO createToDoDTO(); 
    }
}
