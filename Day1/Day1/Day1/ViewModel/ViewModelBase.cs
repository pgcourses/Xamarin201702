using Day1.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day1.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private ValidationManager validationManager;

        public ViewModelBase()
        {
            validationManager = new ValidationManager(this);
        }

        public ValidationManager Errors
        {
            get
            {
                return validationManager;
            }
        }

        public bool IsValid()
        {
            return validationManager.IsValid();
        }

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
            //Mivel ez a változási pont minden esetben, 
            //itt kéne a validációnak lefutnia
            validationManager.ValidateProperty(propertyName);

            OnPropertyChanged(propertyName);
        }
    }
}
