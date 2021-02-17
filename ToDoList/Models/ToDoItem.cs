using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
        [DataType(DataType.Date)]   
        public DateTime Date { get; set; }
        public enum Priorities 
        {
            usual = 0,
            important,
            unimportant
        }
        public Priorities Priority { get; set; }

    }
}
