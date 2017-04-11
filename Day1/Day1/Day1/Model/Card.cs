using Day1.Services;
using Day1.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Day1.Model
{
    public class Card : ViewModelBase
    {

        public Card()
        {
            //PhoneCallCommand = new Command(OnPhoneCallClicked, IsExecutable);
            PhoneCallCommand = new Command(OnPhoneCallClicked);
        }

        //https://github.com/Xamarin201702/Xamarin201702/issues/12
        //private bool IsExecutable(object param)
        //{
        //    return IsValid();
        //}

        private void OnPhoneCallClicked(object obj)
        {
            //Megjött a kattintás, és mivel az osztálypéldányban vagyunk, 
            //megvan a paraméter is.
            //Debug.WriteLine("Description: {0}", this.Description);

            var pw = DependencyService.Get<IPhoneWrapper>();
            if (pw!=null)
            {
                pw.PhoneCall(this.Description);
            }
        }
        [Required(ErrorMessage = "Ezt a mezőt mindenképpen ki kell tölteni!")]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPhoneCallCard { get; set; }

        /// <summary>
        /// ICommand felületet kell megvalósítani, 
        /// hogy a Button Command propertyjére tudjuk binding-olni
        /// </summary>
        public ICommand PhoneCallCommand { get; private set; }

    }
}