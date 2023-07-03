using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class LibroController : Controller
    {
        [HttpGet]
        [Route("api/Libro")]
        public IActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            ML.Result result = BL.Libro.GetAll(libro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("api/Libro/GetById/{IdLibro}")]
        public IActionResult GetById(int IdLibro)

        {
            ML.Result result = BL.Libro.GetById(IdLibro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }

        }


        // POST: api/Producto
        [HttpPost]
        [Route("api/Libro/Add")]
        public IActionResult Post([FromBody] ML.Libro libro)
        {
            ML.Result result = BL.Libro.Add(libro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        // PUT: api/Producto/5
        [HttpPut]
        [Route("api/Libro/Update/{IdLibro}")]
        public IActionResult Put([FromBody] ML.Libro IdLibro)
        {
            ML.Result result = BL.Libro.Update(IdLibro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }

        }



        //// DELETE: api/Producto/5

        [HttpDelete]
        [Route("api/Libro/Delete/{IdLibro}")]

        public IActionResult Delete(int IdLibro)
        {
            ML.Result result = BL.Libro.Delete(IdLibro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }

        }
    }
}
