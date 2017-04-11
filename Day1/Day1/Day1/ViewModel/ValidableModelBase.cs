using Day1.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Day1.ViewModel
{
    /// <summary>
    /// Ha a modellünket validálni kell, akkor innen kell leszármaztatni,
    /// ha nem kell a validáció, akkor pedig a ViewModelBase-ből
    /// </summary>
    public class ValidableModelBase : ViewModelBase
    {
        /// <summary>
        /// Az adott ViewModel példány ValidationManager-e
        /// </summary>
        private ValidationManager validationManager;

        public ValidableModelBase()
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

        protected override void SetProperty<T>(T value, ref T backingField, [CallerMemberName] string propertyName = null)
        {
            base.SetProperty<T>(value, ref backingField, propertyName);
            //Mivel ez a változási pont minden esetben, 
            //Itt a változott értékre validálunk
            validationManager.ValidateProperty(propertyName);

        }

    }
}
