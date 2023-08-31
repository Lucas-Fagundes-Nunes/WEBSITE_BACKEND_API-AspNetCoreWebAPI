using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : Controller
    {
        public ProfessorController() { }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professores: Lucas, Felipe");
        }
    }
}
