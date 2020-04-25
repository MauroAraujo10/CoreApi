using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAgil.WebApi.Model;
using ProAgil.WebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProAgil.WebApi.dto;
using ProAgil.WebApi.dto.Evento;

namespace ProAgil.WebApi.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro com o Banco de Dados");
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<Evento>> Get(int id)
        {
            try
            {
                var results = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro com o Banco de Dados");
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] EventoPostDto dto)
        {
            if (dto != null)
            {
                var evento = new Evento
                {
                    Data = dto.Data,
                    ImagemURL = dto.ImagemURL,
                    Local = dto.Local,
                    Lote = dto.Lote,
                    QuantidadePessoas = dto.QuantidadePessoas,
                    Tema = dto.Tema,
                    Valor = dto.Valor
                };

                _context.Eventos.Add(evento);
                _context.SaveChangesAsync();
            }
        }

        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] EventoGetDto dto)
        {
            var evento = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);

            if (evento != null && dto != null)
            {
                evento.Data = dto.Data;
                evento.ImagemURL = dto.ImagemURL;
                evento.Local = dto.Local;
                evento.Lote = dto.Lote;
                evento.QuantidadePessoas = dto.QuantidadePessoas;
                evento.Tema = dto.Tema;
                evento.Valor = dto.Valor;

                await _context.SaveChangesAsync();
            }
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var evento = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);

            if (evento != null)
            {
                _context.Eventos.Remove(evento);
            }
        }
    }
}

