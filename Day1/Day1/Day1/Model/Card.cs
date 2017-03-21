using Day1.Services;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Day1.Model
{
    public class Card
    {

        public Card()
        {
            PhoneCallCommand = new Command(OnPhoneCallClicked);
        }

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