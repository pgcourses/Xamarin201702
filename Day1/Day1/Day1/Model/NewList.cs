using Day1.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Day1.Model
{
    public class NewList : ViewModelBase
    {
        private string newListName;

        //validációs argumentum, ilyenekkel lehet a validálást beállítani
        [Required(ErrorMessage = "Az új lista nevét kötelező megadni!")] 
        public string NewListName
        {
            get { return newListName; }
            set { SetProperty(value, ref newListName); }
        }

    }
}