using CRUD.Data;
using CRUD.Models;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EngineController : Controller
    {
        private ModelsContext db;

        public EngineController(ModelsContext context)
        {
            db = context;

            if (!db.Engines.Any())
            {
                db.Engines.Add(new Engine { Type = "V-образный", Volume = 2, Power = 1150 });
                db.Engines.Add(new Engine { Type = "Оппозитный", Volume = 3, Power = 1500 });
                db.Engines.Add(new Engine { Type = "Рядный", Volume = 1, Power = 850 });

                db.SaveChanges();
            }
        }

        [HttpGet("list")]
        public IEnumerable<Engine> GetAll()
        {
            return db.Engines.ToList();
        }

        [HttpGet("list/{id}")]
        public Engine Get(int id)
        {
            return db.Engines.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("add")]
        public IActionResult Add(Engine engine)
        {
            if (ModelState.IsValid)
            {
                db.Engines.Add(engine);
                db.SaveChanges();
                return Ok(engine);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("edit")]
        public IActionResult Edit(Engine engine)
        {
            var editedEngine = db.Engines.FirstOrDefault(e => e.Id == engine.Id);

            if (editedEngine != null)
            {
                db.Entry(editedEngine).CurrentValues.SetValues(engine);
                db.SaveChanges();
                return Ok(engine);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var Engine = db.Engines.FirstOrDefault(x => x.Id == id);
            if (Engine != null)
            {
                db.Engines.Remove(Engine);
                db.SaveChanges();
            }
            return Ok(Engine);
        }
    }
}
