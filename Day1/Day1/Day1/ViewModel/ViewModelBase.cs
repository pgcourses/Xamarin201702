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
    /// <summary>
    /// Ez az ősosztálya a ViewModel-eknek
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Az adott ViewModel példány ValidationManager-e
        /// </summary>
        private ValidationManager validationManager;

        public ViewModelBase()
        {
            validationManager = new ValidationManager(this);
        }

        /// <summary>
        /// A ValidationManager indexerének a publikálásához,
        /// így a View hozzáfér a hibaüzenetekhez az egyes propertyName-eken
        /// </summary>
        public ValidationManager Errors
        {
            get { return validationManager; }
        }

        /// <summary>
        /// A ViewModel validációja
        /// </summary>
        /// <returns>True, ha az adatok érvényesek, False, ha nem</returns>
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

        protected void SetProperty<T>(T value, ref T backingField, [CallerMemberName]string propertyName = null)
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
            //Itt a változott értékre validálunk
            validationManager.ValidateProperty(propertyName);

            OnPropertyChanged(propertyName);
        }
    }
}
