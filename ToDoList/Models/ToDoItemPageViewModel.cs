using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Model;

namespace ToDoList.Model
{
    public class ToDoItemPageViewModel
    {
        public IEnumerable<ToDoItem> Items { get; set; }

        public string PageTitle;
    }
}
