using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin201702.WebApp.Controllers
{
    //Minden metódus ilyet fog visszaadni a kliensnek
    [Produces("application/json")]
    //Routing: attributum alapú definíció
    [Route("api/MyList")]
    public class MyListController : Controller
    {
        private readonly IMyListRepository repository;

        public MyListController(IMyListRepository repository)
        {
            this.repository = repository;
        }

        //Lekérdezi az összes listát és visszatér vele
        [HttpGet]
        public IActionResult GetLists()
        {
            return Ok(repository.GetLists());
        }

        [HttpPost]
        public IActionResult Create([FromBody] MyListRestApiAddModel model) //FromBody: az átadott JSON-ből szedi a paramétereket
        {//figyelem, létrehozáskor id-t nem kapunk, ezért jobb az AddModel
            var id = repository.AddList(model);
            return Ok(id);
        }
    }
}
