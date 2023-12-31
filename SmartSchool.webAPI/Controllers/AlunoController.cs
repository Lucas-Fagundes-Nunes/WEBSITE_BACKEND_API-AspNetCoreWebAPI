﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.webAPI.Data;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }
        

        // [HttpGet("byId")] =>   api/aluno/byId?id=1
        // api/aluno/byId/1
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");
            return Ok(aluno);
        }


        //api/aluno/
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges()) {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado");
        }

        //api/aluno/
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges()) {
                return Ok(aluno);
            }
            return BadRequest("Aluno não atualizado");
        }

        //api/aluno/
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges()) {
                return Ok(aluno);
            }
            return BadRequest("Aluno não atualizado");
        }

        //api/aluno/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            
            _repo.Delete(aluno);
            if (_repo.SaveChanges()) {
                return Ok(aluno);
            }
            return BadRequest("Aluno não removido");
        }
    }
}

