using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Day1.ViewModel
{
 
    public class TaskViewModel 
    {
        public static readonly string[] PriorityTexts = { "Ráér", "Normál", "Sürgős" };

        public string Title { get; set; }
        public int Priority { get; set; } = 1;

        public string PriorityText { get { return PriorityTexts[Priority]; } }
        public DateTime Due { get; set; }
        public bool IsSolved { get; set; }

    }
}
