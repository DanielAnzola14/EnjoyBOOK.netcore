using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly EnjoyBookContext _baseDatos;

        public LibroController(EnjoyBookContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Libros()
        {
            var listaLibros = await _baseDatos.Libros.ToListAsync();
            return Ok(listaLibros);
        }
        //________________________________________________________________________________________________________
        [HttpPost]
        [Route("Agregar")]

        public async Task<IActionResult> Agregar([FromBody] Libro request)
        {
            await _baseDatos.Libros.AddAsync(request);
            await _baseDatos.SaveChangesAsync();
            return Ok(request);
        }
        //-------------------------------------------------------------------------------------------
        [HttpDelete]
        [Route("Eliminar/{id:int}")]

        public async Task<IActionResult> Eliminar(int id) 
        {
            var EliminarLibro = await _baseDatos.Libros.FindAsync(id);
            if (EliminarLibro == null)
                return BadRequest("No existe el libro");

            _baseDatos.Libros.Remove(EliminarLibro);
            await _baseDatos.SaveChangesAsync();
            return Ok();
        }
    }
}
