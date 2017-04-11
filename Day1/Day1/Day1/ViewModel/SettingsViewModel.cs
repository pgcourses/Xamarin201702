using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {

        //nincs szükség backing field-re, mivel a Settings-ben már megvan az érték
        public string NickName
        {
            get { return Helpers.Settings.NickName; }
            set
            {
                var setting = Helpers.Settings.NickName;
                SetProperty(value, ref setting);
                Helpers.Settings.NickName = setting; 
            }
        }


        public bool NetworkOnlyIfWifi
        {
            get { return Helpers.Settings.NetworkOnlyIfWifi; }
            set
            {
                var setting = Helpers.Settings.NetworkOnlyIfWifi;
                SetProperty(value, ref setting);
                Helpers.Settings.NetworkOnlyIfWifi = setting;
            }
        }

    }
}
