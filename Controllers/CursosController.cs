using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ExemploWEB_API.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExemploWEB_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly CursoDbContext _context;

        public CursosController(CursoDbContext context)
        {
            _context = context;
        }

        // Metodo GET que busca todos os objetos na tabela Curso do banco de dados
        [HttpGet]
        public IEnumerable<Curso> GetCursos()
        {
            return _context.Cursos;
        }

        // Metodo GET que busca um curso especificado por uma chave primária
        [HttpGet("{id}")]
        public IActionResult GetCursoPorId(int id)
        {
            Curso curso = _context.Cursos.SingleOrDefault(modelo => modelo.ID == id);
            if (curso == null)
            {
                return NotFound();
            }
            return new ObjectResult(curso);
        }

        // Método POST que adiciona um objeto a tabela Curso
        [HttpPost]
        public IActionResult CriarCurso([FromBody] Curso item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _context.Cursos.Add(item);
            _context.SaveChanges();

            return CreatedAtAction("GetCursos", new { id = item.ID }, item);
        }

        // Método PUT que atualiza o estado do contexto e salva no banco de dados atualizando um objeto com a chave primaria especificada
        [HttpPut("{id}")]
        public IActionResult AtualizarCurso(int id, [FromBody] Curso item)
        {
            if (id != item.ID){
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult(); // Se o requerimento for concluido com sucesso não há nenhum conteúdo no retorno
        }

        [HttpDelete("{id}")]
        public  IActionResult DeletarCurso(int id)
        {
            Curso curso = _context.Cursos.SingleOrDefault(modelo => modelo.ID == id);

            if (curso == null)
            {
                return NotFound();
            }

            _context.Cursos.Remove(curso);
            _context.SaveChanges();

            return Ok(curso);
        }
    }
}
