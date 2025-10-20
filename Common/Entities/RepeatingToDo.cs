using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.TransferObjects;

namespace Common.Entities
{
    public class RepeatingToDo: IToDo
    {
        private uint nId{ get; set; }
        private string sName{ get; set; }
        private DateOnly oDate{ get; set; }
        private uint nDayInterval{ get; set; }
        private bool bIsOverdue { get; set; }
        public RepeatingToDo(uint nId, string sName, DateOnly oDate,uint nDayInterval ,bool bIsOverdue = false)
        {
            this.nId = nId;
            this.sName = sName;
            this.oDate = oDate;
            this.bIsOverdue = bIsOverdue;
            this.nDayInterval = nDayInterval;
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
        public uint getDayInterval() 
        {
            return nDayInterval;
        }
        public void updateDueDate() 
        {
            oDate = oDate.AddDays((int)nDayInterval); 
        }

        public ToDoDTO createToDoDTO()
        {
            return new ToDoDTO(this); 
        }
    }
}
