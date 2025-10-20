using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.TransferObjects
{
    public class ToDoDTO
    {
        public uint nID { get; set;}
        public string sName{ get; set;}
        public DateOnly oDueDate{ get; set;}
        public bool bOverdue{ get; set;}
        public uint nDayInterval{ get; set;}
        public ToDoType oToDoType{ get; set;}
        public ToDoDTO(SingeToDo oToDo) 
        {
            nID = oToDo.getId();
            sName = oToDo.getName();
            oDueDate = oToDo.getDate();
            bOverdue = oToDo.getOverdue();
            oToDoType = ToDoType.SingleToDo; 
        }

        public ToDoDTO(RepeatingToDo oToDo)
        {
            nID = oToDo.getId();
            sName = oToDo.getName();
            oDueDate = oToDo.getDate();
            bOverdue = oToDo.getOverdue();
            nDayInterval = oToDo.getDayInterval();
            oToDoType = ToDoType.RepeatingToDo;
        }

        public IToDo toIToDo()
        {
            switch (oToDoType)
            {
                case ToDoType.SingleToDo:
                    return new SingeToDo(nID, sName, oDueDate, bOverdue);
                case ToDoType.RepeatingToDo:
                    return new RepeatingToDo(nID, sName, oDueDate, nDayInterval, bOverdue); 
                default:
                    return null; 
            }
        }

        public enum ToDoType 
        {
            SingleToDo,
            RepeatingToDo 
        }
    }

}
