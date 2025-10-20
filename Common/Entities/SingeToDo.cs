using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.TransferObjects;

namespace Common.Entities
{
    public class SingeToDo : IToDo
    {
        private  uint nId { get; set; }
        private string sName{ get; set; }
        private DateOnly oDate{ get; set; }
        private bool bIsOverdue { get; set; } 
        public SingeToDo(uint nId, string sName, DateOnly oDate, bool bIsOverdue = false)
        {
            this.nId = nId;
            this.sName = sName;
            this.oDate = oDate;
            this.bIsOverdue = bIsOverdue;
        }

        public uint getId() 
        {
            return nId; 
        }
        public string getName() 
        {
            return sName;
        }
        public DateOnly getDate() 
        {
            return oDate;
        }

        public bool getOverdue()
        {
            return bIsOverdue;
        } 

        public ToDoDTO createToDoDTO()
        {
            return new ToDoDTO(this); 
        }
    }
}
