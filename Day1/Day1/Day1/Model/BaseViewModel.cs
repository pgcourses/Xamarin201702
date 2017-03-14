using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Model
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
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

        internal void SetProperty<T>(T value, ref T backingField, [CallerMemberName]string propertyName = null)
        {
            if (
                (backingField!=null && backingField.Equals(value))
                ||
                (backingField==null && value==null)
               )
            {
                return;
            }
            backingField = value;
            OnPropertyChanged(propertyName);
        }
    }
}
