using Microsoft.AspNetCore.Mvc;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using lib_aplicaciones;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly IMotosAplicacion _aplicacion;

        public MotosController(IMotosAplicacion aplicacion)
        {
            _aplicacion = aplicacion;
        }

        // GET: api/motos
        [HttpGet]
        public IActionResult Listar()
        {
            var motos = _aplicacion.Listar();
            return Ok(motos);
        }

        // GET: api/motos/5
        [HttpGet("{id}")]
        public IActionResult Obtener(int id)
        {
            var moto = _aplicacion.ObtenerPorId(id);
            if (moto == null) return NotFound();
            return Ok(moto);
        }

        // POST: api/motos
        [HttpPost]
        public IActionResult Guardar([FromBody] Motos moto)
        {
            var nueva = _aplicacion.Guardar(moto);
            return CreatedAtAction(nameof(Obtener), new { id = nueva.Id }, nueva);
        }

        // PUT: api/motos/5
        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody] Motos moto)
        {
            var actualizado = _aplicacion.Modificar(id, moto);
            if (actualizado == null) return NotFound();
            return Ok(actualizado);
        }

        // DELETE: api/motos/5
        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            var eliminado = _aplicacion.Borrar(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}