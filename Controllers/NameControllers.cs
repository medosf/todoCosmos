
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using TodoComos.Service;


namespace TodoComos.Controllers
{
 [ApiController]
 [Route("api/[controller]")]
 public class NameController : Controller 
  {

    private readonly NameService _nameService;

    public NameController(NameService nameService){
        _nameService = nameService;
    }

    [HttpGet]
    public async Task<IActionResult> GetName([FromQuery] string nameQuery = "alya" )
  
    {
      var res =  await _nameService.GetNames(nameQuery);
        return Ok(res);

    }

    
    
  }

}