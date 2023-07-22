using Microsoft.AspNetCore.Mvc;

namespace SL_WebAPI.Controllers
{
	public class ProductoController : Controller
	{
		[HttpGet]
		[Route("api/Producto")]
		public IActionResult GetAll()
		{
			ML.Producto producto = new ML.Producto();	
			ML.Result result = BL.Producto.GetAll(producto);

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
		[Route("api/Producto/GetById/{IdProducto}")]
		public IActionResult GetById(int IdProducto)

		{
			ML.Result result = BL.Producto.GetById(IdProducto);
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
		[Route("api/Producto/Add")]
		public IActionResult Post([FromBody] ML.Producto producto)
		{
			ML.Result result = BL.Producto.Add(producto);

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
		[Route("api/Producto/Update/{IdProducto}")]
		public IActionResult Put([FromBody] ML.Producto IdProducto)
		{
			ML.Result result = BL.Producto.Update(IdProducto);
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
		[Route("api/Producto/Delete/{IdProducto}")]

		public IActionResult Delete(int IdProducto)
		{
			ML.Result result = BL.Producto.Delete(IdProducto);
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
