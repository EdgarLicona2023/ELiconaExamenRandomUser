using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
//using System.Web.Mvc;

namespace SL.Controllers
{
	public class EmpleadoController : ApiController
	{
		// GET: Empleado
		[HttpGet]
		[Route("api/Empleado/GetAll")]
		public IHttpActionResult GetAll()
		{
			ML.Result result = BL.Empleado.GetAll();

			if (result.Correct)
			{
				return Ok(result);
			}
			else //Error
			{
				return Content(HttpStatusCode.NotFound, result);
			}

		}

		// GET: api/SubCategoria/5
		[HttpGet]
		[Route("api/Empleado/GetById/{IdEmpleado}")]
		public IHttpActionResult GetById(int IdEmpleado)
		{
			ML.Result result = BL.Empleado.GetById(IdEmpleado);

			if (result.Correct)
			{
				return Ok(result);
			}
			else
			{
				return Content(HttpStatusCode.NotFound, result);
			}


		}


		[HttpPost]
		[Route("api/Empleado/Add")]
		// POST: api/SubCategoria
		public IHttpActionResult Post([FromBody] ML.Empleado empleado)
		{
			ML.Result result = BL.Empleado.Add(empleado);
			if (result.Correct)
			{
				return Ok(result);
			}
			else //Error
			{
				return Content(HttpStatusCode.NotFound, result);
			}
		}

		[HttpPost]
		[Route("api/Empleado/Update")]
		// PUT: api/SubCategoria/5
		public IHttpActionResult Put([FromBody] ML.Empleado empleado)
		{
			var result = BL.Empleado.Update(empleado);

			if (result.Correct)
			{
				return Ok(result);
			}
			else //Error
			{
				return Content(HttpStatusCode.NotFound, result);
			}
		}


		[HttpGet]
		[Route("api/Empleado/Delete/{IdEmpleado}")]
		// GET: api/SubCategoria/Delete
		public IHttpActionResult Delete(int IdEmpleado)
		{
			ML.Result result = BL.Empleado.Delete(IdEmpleado);

			if (result.Correct)
			{
				return Ok(result);
			}
			else //Error
			{
				return Content(HttpStatusCode.NotFound, result);
			}

		}
	}
}