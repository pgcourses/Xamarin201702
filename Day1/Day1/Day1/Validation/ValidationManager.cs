using System;
using Day1.ViewModel;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Day1.Validation
{
    /// <summary>
    /// propertyName1       ErrorMessage11
    ///                     Errormessage12
    ///                     ...
    ///                     Errormessage1n
    ///                     
    /// propertyName2       ErrorMessage21
    ///                     Errormessage22
    ///                     ...
    ///                     Errormessage2n
    /// ...
    /// 
    /// propertyNamex       ErrorMessagex1
    ///                     Errormessagex2
    ///                     ...
    ///                     Errormessagexn
    /// </summary>

    public class ValidationManager : INotifyPropertyChanged
    {
        /// <summary>
        /// A ViewModel amit ez a manager validál
        /// </summary>
        private ViewModelBase viewModel;

        /// <summary>
        /// Hibák táblázata, ld a fenti rajzot
        /// </summary>
        private IDictionary<string, ReadOnlyCollection<string>> errors
            = new Dictionary<string, ReadOnlyCollection<string>>();

        /// <summary>
        /// Ahhoz, hogy a hibák megjelenítéset adatkötésben meg tudjuk jeleníteni, 
        /// meg kell valósítanunk az INotifyPropertyChanged-et
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Konstruktor, DI-vel kapja a validálandó ViewModelt
        /// </summary>
        /// <param name="viewModel"></param>
        public ValidationManager(ViewModelBase viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// Indexer, 
        /// </summary>
        /// <param name="propertyName">Amelyik property hibaüzeneteire kíváncsiak vagyunk</param>
        /// <returns>visszatér a hibaüzenetek listájával</returns>
        public ReadOnlyCollection<string> this[string propertyName]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(propertyName))
                {
                    throw new ArgumentNullException(nameof(propertyName));
                }

                if (errors.ContainsKey(propertyName))
                { //ha van ilyen a szótárban, akkor visszaadjuk
                    return errors[propertyName];
                }
                else
                { //ha nincs, akkor pedig üres listát adunk vissza
                    return GetROCollection(new List<string>());
                }
            }
        }

        /// <summary>
        /// Egy property validációja. A Viewmodel hivja, ha a property-t valaki módosította 
        /// </summary>
        /// <param name="propertyName">A property neve. amit validálni kell</param>
        public void ValidateProperty(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            { // nem kaptunk megfelelő nevet
                throw new ArgumentNullException(nameof(propertyName));
            }

            //Innentől pedig szükségünk van Reflection-re
            var pi = viewModel.GetType().GetRuntimeProperty(propertyName);
            if (pi == null)
            { //nem találjuk a property-t
                throw new ArgumentOutOfRangeException(propertyName, "Ezen a modellen nincs ilyen property.");
            }
            
            //kiolvassuk a property értékét
            var value = pi.GetValue(viewModel);
            
            //az eredmény lista
            var validationResult = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            //A validálási környezet, ahol az ellenőrzés lefut
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(viewModel)
            { //jelezzük, hogy melyik property-re validálunk
                MemberName = propertyName
            };

            //a validálás maga
            var isValid 
                = System.ComponentModel.DataAnnotations.Validator.TryValidateProperty(value, validationContext, validationResult);

            var errorList = new List<string>();
            //Az eredményt hogyan dolgozzuk fel:
            if (validationResult.Any())
            { //ha van hibaüzenet, akkor ezt elmentjük
                errorList.AddRange(validationResult.Select(x => x.ErrorMessage));
            }

            var isChanged = false;
            if (errors.ContainsKey(propertyName))
            { //már van ilyen a szótárban-ban (Dictionary-ben)
                if (errorList.Any())
                { //van hibánk, módosítunk a meglévőn
                    errors[propertyName] = GetROCollection(errorList);
                    isChanged = true;
                }
                else
                { //megszűntek a hibák, törlünk
                    errors.Remove(propertyName);
                    isChanged = true;
                }
            }
            else
            { //nincs még ilyen a szótárban
                if (errorList.Any())
                {
                    errors.Add(propertyName, GetROCollection(errorList));
                    isChanged = true;
                }
            }

            if (isChanged)
            {
                OnPropertyChanged($"Item[{propertyName}]");
            }
        }

        private static ReadOnlyCollection<string> GetROCollection(List<string> errorList)
        {
            return new ReadOnlyCollection<string>(errorList);
        }

        /// <summary>
        /// Az egész ViewModel-t validálja, azért kell, hogy ne lehessen ellépni az oldalról
        /// </summary>
        /// <returns>True, ha az adatok érvényesek (tovább lehet menni), False, ha nem</returns>
        public bool IsValid()
        {
            //A kérdés valamennyi property-re vonatkozik
            var toValidate = viewModel.GetType()
                                      .GetRuntimeProperties() //Elkérjük az összes property-t
                                      .Where(
                                        pi => //Ezek közül pedig szűrünk azokra, amelyiknek van ValidationAttribute dekorációja
                                            pi.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.ValidationAttribute))
                                              .Any());
            foreach (PropertyInfo pi in toValidate)
            { //Ezeken validálunk a korábbi módon
                ValidateProperty(pi.Name);
            }

            //Ha nincs egy hibaüzenet sem, akkor az adatok érvényesek
            return errors.Count == 0;
        }
    }
}