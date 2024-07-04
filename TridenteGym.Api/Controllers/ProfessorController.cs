using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace TridenteGym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        // GET -> https://IP/professor/getall
        [HttpGet("GetAll")]
        public IEnumerable<Professor> GetAll()
        {
            return _professorService.GetAll();
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public ActionResult<Professor> Get(int id)
        {
            var professor = _professorService.Get(id);

            return Ok(professor);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public ActionResult<Professor> Post([FromBody] Professor professor)
        {
            var newProfessor = _professorService.Add(professor);

            return Ok(newProfessor);
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _professorService.Delete(id);
        }
    }
}
