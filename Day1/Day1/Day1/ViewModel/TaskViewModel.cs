using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.ViewModel
{
    public class TaskViewModel
    {
        public string Title { get; set; }
        public int Priority { get; set; } = 1;
        public DateTime Due { get; set; }
        public bool IsSolved { get; set; }

    }
}
