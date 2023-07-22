using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
	public class UsuarioController : Controller
	{
		[HttpGet]
		[Route("api/Usuario")]
		public IActionResult GetAll()
		{
			ML.Usuario usuario = new ML.Usuario();
			ML.Result result = BL.Usuario.GetAll(usuario);

			if (result.Correct)
			{
				return Ok(result);
			}
			else
			{
				return NotFound();
			}
		}

		// GET: api/Producto/5
		//[HttpGet]
		//[Route("api/Producto/{IdProducto}")]

		//public IActionResult GetById(int IdProducto)

		//{
		//	ML.Result result = BL.Producto.GetById(IdProducto);
		//	if (result.Correct)
		//	{
		//		return Ok(result);
		//	}
		//	else
		//	{
		//		return NotFound(result);
		//	}

		//}

		[HttpGet]
		[Route("api/Usuario/GetById/{IdUsuario}")]
		public IActionResult GetById(int IdUsuario)

		{
			ML.Result result = BL.Usuario.GetById(IdUsuario);
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
		[Route("api/Usuario/Add")]
		public IActionResult Post([FromBody] ML.Usuario usuario)
		{
			ML.Result result = BL.Usuario.Add(usuario);

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
		[Route("api/Usuario/Update/{IdUsuario}")]
		public IActionResult Put([FromBody] ML.Usuario IdUsuario)
		{
			ML.Result result = BL.Usuario.Update(IdUsuario);
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
		[Route("api/Usuario/Delete/{IdUsuario}")]

		public IActionResult Delete(int IdUsuario)
		{
			ML.Result result = BL.Usuario.Delete(IdUsuario);
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
