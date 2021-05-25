using CRUD.Data;
using CRUD.Models;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodyController : Controller
    {
        private ModelsContext db;

        public BodyController(ModelsContext context)
        {
            db = context;

            if (!db.Bodies.Any())
            {
                db.Bodies.Add(new Body { Type = "Пикап", BodyModel = "Грузопассажирный" });
                db.Bodies.Add(new Body { Type = "Хэтчбэк", BodyModel = "Грузопассажирный" });
                db.Bodies.Add(new Body { Type = "Купэ", BodyModel = "Закрытый" });

                db.SaveChanges();
            }
        }

        [HttpGet("list")]
        public IEnumerable<Body> GetAll()
        {
            return db.Bodies.ToList();
        }

        [HttpGet("list/{id}")]
        public Body Get(int id)
        {
            var body = db.Bodies.FirstOrDefault(x => x.Id == id);
            return body;
        }

        [HttpPost("add")]
        public IActionResult Add(Body body)
        {
            if (ModelState.IsValid)
            {
                db.Bodies.Add(body);
                db.SaveChanges();
                return Ok(db.Bodies.ToList());
            }
            return BadRequest(ModelState);
        }

        [HttpPut("edit")]
        public IActionResult Edit(Body body)
        {
            var editedBody = db.Bodies.FirstOrDefault(b => b.Id == body.Id);

            if (editedBody != null)
            {
                db.Entry(editedBody).CurrentValues.SetValues(body);
                db.SaveChanges();
                return Ok(body);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var body = db.Bodies.FirstOrDefault(x => x.Id == id);
            if (body != null)
            {
                db.Bodies.Remove(body);
                db.SaveChanges();
            }
            return Ok(body);
        }
    }
}
