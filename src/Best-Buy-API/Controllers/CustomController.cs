using Best.Buy.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Best.Buy.API.Controllers
{
    public class CustomController : ControllerBase
    {
        [NonAction]
        public IActionResult ResponseGet<T>(PagedList<T> data = null, string error = null) 
        {
            StatusResponse<T> status = new StatusResponse<T>();
            if (data != null)
            {
                status.Total = data.Total;
                status.CurrentPage = data.CurrentPage;
                status.Pages = data.Pages;
                status.CurrentPage = data.CurrentPage;
                status.Data = data;

                if (status.Total > 0)
                    status.StatusCode = 200;
                else
                    status.StatusCode = 204;

                return Ok(status);
            }
            else
            {
                status.StatusCode = 400;
                status.Errors = error;
                return BadRequest(status);
            }
        }
    }
}
