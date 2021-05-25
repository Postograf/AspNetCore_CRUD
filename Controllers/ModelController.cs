using CRUD.Data;
using CRUD.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController : Controller
    {
        private ModelsContext db;

        public ModelController(ModelsContext context)
        {
            db = context;

            if (!db.Models.Any())
            {
                db.SaveChanges();
            }
        }

        [HttpGet("list")]
        public IEnumerable<Model> GetAll()
        {
            return db.Models.ToList();
        }

        [HttpGet("list/{id}")]
        public Model Get(int id)
        {
            var Model = db.Models.FirstOrDefault(x => x.Id == id);
            return Model;
        }

        [HttpPost("add")]
        public IActionResult Add(Model model)
        {
            if (ModelState.IsValid)
            {
                db.Models.Add(model);
                db.SaveChanges();
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("edit")]
        public IActionResult Edit(Model model)
        {
            var editedModel = db.Models.FirstOrDefault(m => m.Id == model.Id);

            if (editedModel != null)
            {
                db.Entry(editedModel).CurrentValues.SetValues(model);
                db.SaveChanges();
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var Model = db.Models.FirstOrDefault(x => x.Id == id);
            if (Model != null)
            {
                db.Models.Remove(Model);
                db.SaveChanges();
            }
            return Ok(Model);
        }
    }
}
