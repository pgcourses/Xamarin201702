using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = "DisneyUser")]
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

        [HttpPut("{id}")] //Annyiban különbözik a Create-től, hogy id-vel azonosítjuk az erőforráselemet
        public IActionResult Update(int id, [FromBody] MyListRestApiAddModel model)
        {
            var list = new MyListRestApiModel
            {
                Id = id,
                Title = model.Title,
                Picture = model.Picture,
                Cards = model.Cards
            };
            repository.UpdateList(list);
            return Ok();
        }

        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            repository.DeleteList(id);
            return Ok();
        }
    }
}
