using Day1.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Day1.Model
{
    public class NewList : ViewModelBase
    {
        private string newListName;

        //validációs argumentum, ilyenekkel lehet a validálást beállítani
        //itt vannak a beépített .NET validációk:
        //https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.validationattribute(v=vs.110).aspx
        //http://www.devtrends.co.uk/blog/the-complete-guide-to-validation-in-asp.net-mvc-3-part-1
        //itt pedig néhány példa, hogy lehet saját validációs attributumot létrehozni
        //https://msdn.microsoft.com/en-us/library/cc668224(v=vs.110).aspx
        //http://stackoverflow.com/questions/2280539/custom-model-validation-of-dependent-properties-using-data-annotations

        [Required(ErrorMessage = "Az új lista nevét kötelező megadni!")] 
        public string NewListName
        {
            get { return newListName; }
            set { SetProperty(value, ref newListName); }
        }

    }
}