using Microsoft.AspNetCore.Mvc;

namespace CitiesManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // for validation of binding like modelState and return 400 with list of error message in model , for return json by default
    public class CustomControllerBase : ControllerBase
    {
    }
}