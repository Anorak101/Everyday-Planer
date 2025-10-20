namespace Common.Entities
{
    public class TaskToDo
    {
        public uint nId { get; set; }
        public String sName { get; set; }
        public DateOnly oDate {  get; set; }
        public TaskToDo(uint nId, string sName, DateOnly oDate)
        {
            this.nId = nId;
            this.sName = sName;
            this.oDate = oDate;
        }
    }
}
