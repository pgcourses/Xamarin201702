using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Model
{
    /// <summary>
    /// Ezt az interface-t fogjuk minden platformon megvalósítani.
    /// </summary>
    public interface IFileService
    {
        string GetLocalPath(string filename);
    }
}
