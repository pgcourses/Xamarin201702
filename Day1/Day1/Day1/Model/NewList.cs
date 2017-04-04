using Day1.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Day1.Model
{
    public class NewList : ViewModelBase
    {
        private string newListName;
        [Required(ErrorMessage = "Az új lista nevét kötelező megadni!")]
        public string NewListName
        {
            get { return newListName; }
            set { SetProperty(value, ref newListName); }
        }

    }
}