using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Model
{
    public class MyList : INotifyPropertyChanged
    {
        public MyList()
        {
            Cards = new List<Card>();
        }

        public List<Card> Cards { get; set; }
        public string Title { get; set; }

        // innentől Viewmodel
        public bool IsLastPage { get; set; } = false;

        private string newListName;
        public string NewListName
        {
            get
            {
                return newListName;
            }
            set
            {
                if (value == newListName) { return; }
                newListName = value;
                OnPropertyChanged(nameof(NewListName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            //régi módszer
            //var handler = PropertyChanged;
            //if (handler!=null)
            //{
            //    handler(this, new PropertyChangedEventArgs(propertyName));
            //    //Ez ugyanaz:
            //    //handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //}
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
