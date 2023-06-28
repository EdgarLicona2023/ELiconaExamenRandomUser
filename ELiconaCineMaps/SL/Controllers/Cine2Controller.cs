using Microsoft.AspNetCore.Mvc;


namespace SL.Controllers
{
    public class Cine2Controller : Controller
    {
        [HttpGet]
        [Route("api/Cine")]
        public IActionResult GetAll()
        {
            ML.Cine2 cine = new ML.Cine2();
            ML.Result result = BL.Cine.GetAll(cine);

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
        [Route("api/Cine/GetById/{IdCine}")]
        public IActionResult GetById(int IdCine)

        {
            ML.Result result = BL.Cine.GetById(IdCine);
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
        [Route("api/Cine/Add")]
        public IActionResult Post([FromBody] ML.Cine2 cine)
        {
            ML.Result result = BL.Cine.Add(cine);

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
        [Route("api/Cine/Update/{IdCine}")]
        public IActionResult Put([FromBody] ML.Cine2 IdCine)
        {
            ML.Result result = BL.Cine.Update(IdCine);
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
        [Route("api/Cine/Delete/{IdCine}")]

        public IActionResult Delete(int IdCine)
        {
            ML.Result result = BL.Cine.Delete(IdCine);
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
