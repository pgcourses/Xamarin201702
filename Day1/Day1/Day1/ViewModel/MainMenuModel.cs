using Day1.View;
using Day1.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Model
{
    public class MainMenuModel
    {
        public List<MainMenuItem> MainMenuItems { get; set; }

        public MainMenuModel()
        {
            MainMenuItems = new List<MainMenuItem>(
                new MainMenuItem[] {
                    new MainMenuItem { Title="Névjegy", PageType=typeof(About) },
                    new MainMenuItem { Title="Tennivalók", PageType=typeof(TodoList) },
                    new MainMenuItem { Title="Telefonkönyv", PageType=typeof(ContactList) },
                    new MainMenuItem { Title="Beállítások", PageType=typeof(Settings) },
                    new MainMenuItem { Title="RestApiTest", PageType=typeof(RestApiPage) }
                    //new MainMenuItem { Title="Névjegy", GetPage=()=> { return new About(); } },
                    //new MainMenuItem { Title="Tennivalók", GetPage=()=> { return new TodoList(); } },
                    //new MainMenuItem { Title="Telefonkönyv", GetPage=()=> { return new ContactList(); } }
            });
        }
    }
}
