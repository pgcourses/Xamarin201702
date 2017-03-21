using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Services
{
    /// <summary>
    /// Interface a platform FÜGGŐ megvalósításokhoz
    /// </summary>
    public interface IPhoneWrapper
    {
        /// <summary>
        /// Egy telefonhívás indítása az adott platformnak megfelelő módon
        /// </summary>
        /// <param name="phoneNumber">A telefonszám, amit hívni akarunk</param>
        /// <returns>A függvényhívás sikerességével tér vissza. True: sikeres, false: sikertelen</returns>
        bool PhoneCall(string phoneNumber);
    }
}
