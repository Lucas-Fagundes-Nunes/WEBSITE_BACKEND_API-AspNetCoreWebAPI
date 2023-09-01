using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.webAPI.Data;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        public ProfessorController(IRepository repo) { 
            _repo = repo;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("O professor não foi encontrado");
            return Ok(professor);
        }


        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges()) {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado");
            
            _repo.Update(professor);
            if (_repo.SaveChanges()) {
                return Ok(professor);
            }
            return BadRequest("Professor não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado");
            
            _repo.Update(professor);
            if (_repo.SaveChanges()) {
                return Ok(professor);
            }
            return BadRequest("Professor não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não encontrado");

            _repo.Delete(professor);
            if (_repo.SaveChanges()) {
                return Ok(professor);
            }
            return BadRequest("Professor não removido");
        }
    }
}
