using Microsoft.AspNetCore.Mvc;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : Controller
    {
        public List<Models.Aluno> Alunos = new List<Models.Aluno>() {
            new Models.Aluno()
            {
                Id = 1,
                Nome = "Marco",
                Sobrenome = "Souza",
                Telefone = "123456"
            },
            new Models.Aluno()
            {
                Id = 2,
                Nome = "Lucas",
                Sobrenome = "Nunes",
                Telefone = "26266"
            },
            new Models.Aluno()
            {
                Id = 3,
                Nome = "Filipe",
                Sobrenome = "Fagundes Nunes",
                Telefone = "5216"
            },
            new Models.Aluno()
            {
                Id = 4,
                Nome = "Selmar",
                Sobrenome = "Nunes",
                Telefone = "5181181"
            },
        };
        public AlunoController() { }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // [HttpGet("byId")] =>   api/aluno/byId?id=1
        // api/aluno/byId/1
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");
            return Ok(aluno);
        }

        //api/aluno/byName?nome=Lucas&sobrenome=Nunes
        [HttpGet("byName")]
        public IActionResult GetByName(string Nome, string Sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => 
                a.Nome.Contains(Nome) && a.Sobrenome.Contains(Sobrenome)
            );
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");
            return Ok(aluno);
        }

        //api/aluno/
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno/
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno/
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(id);
        }
    }
}

