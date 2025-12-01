using System;
using System.Threading.Tasks;
using api.data;
using Microsoft.AspNetCore.Mvc;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly DataContent _dc;

        public PessoaController(DataContent context)
        {
            _dc = context;
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] Pessoa pessoa)
        {
            _dc.Pessoa.Add(pessoa);
            await _dc.SaveChangesAsync();
            return Created("/api/pessoa", pessoa);
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            var dados = await _dc.Pessoa.ToListAsync();
            return Ok(dados);
        }
        [HttpGet("{id}")]
        public ActionResult<Pessoa> filtrarPorId(int id)
        {
            var pessoa = _dc.Pessoa.FirstOrDefault(p => p.Id == id);
            if (pessoa == null)
                return NotFound();
            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Pessoa pessoaAtualizada)
        {
            var pessoa = await _dc.Pessoa.FindAsync(id);
            if (pessoa == null)
                return NotFound();
            pessoa.Nome = pessoaAtualizada.Nome;
            pessoa.Idade = pessoaAtualizada.Idade;
            await _dc.SaveChangesAsync();
            return NoContent();
            // _dc.Pessoa.Update(pessoaAtualizada);
            // await _dc.SaveChangesAsync();
            // return Ok(pessoaAtualizada);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            var pessoa = await _dc.Pessoa.FindAsync(id);
            if (pessoa == null)
                return NotFound();
            _dc.Pessoa.Remove(pessoa);
            await _dc.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet("oi")]
        public string Get()
        {
            return "Hello World!";
        }
    }
}
