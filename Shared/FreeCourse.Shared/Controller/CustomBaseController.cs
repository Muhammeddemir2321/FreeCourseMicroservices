using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Shared.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController:ControllerBase
    {
        public IActionResult CreateActionResult<T>(Response<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = response.StatusCode };
            }
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
