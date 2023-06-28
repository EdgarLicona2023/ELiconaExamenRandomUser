using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace SL.Controllers
{
    public class EstadoController : ApiController
    {
		// GET: Estado
		[HttpGet]
		[Route("api/Estado/GetAll")]
		public IHttpActionResult GetAll()
		{
			ML.Result result = BL.Estados.GetAll();

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