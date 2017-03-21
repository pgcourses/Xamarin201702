using Day1.Services;
using Day1.WinPhone.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneWrapper))]
namespace Day1.WinPhone.Services
{
    public class PhoneWrapper : IPhoneWrapper
    {
        public bool PhoneCall(string phoneNumber)
        {
            try
            {
                Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(phoneNumber, "Kimenő hívás");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
