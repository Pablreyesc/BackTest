using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using System.Data;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Cors;

namespace Prueba.Controllers
{
    [EnableCors("Cors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
        public readonly TestContext _dbacontext;

        public ImagenController(TestContext dbacontext)
        {
            _dbacontext = dbacontext;
        }
        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Imagen> lista = new List<Imagen>();
            try
            {
                lista = _dbacontext.Imagens.ToList();
                
                return StatusCode(StatusCodes.Status200OK, new {mensaje = "ok ", Response= lista});
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "error", Response = lista });

            }

        }




        

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(IFormFile imagen)
        {
            try
            {

                if (imagen == null || imagen.Length == 0)
                {
                    return BadRequest("No se ha proporcionado una imagen.");
                }

                // Lee el contenido del archivo en un array de bytes.
                using (var memoryStream = new MemoryStream())
                {
                    await imagen.CopyToAsync(memoryStream);
                    var co = new Imagen
                    {
                        Imagen1 = memoryStream.ToArray()
                    };

                    // Inserta la imagen en la base de datos.
                    _dbacontext.Add(co);
                    await _dbacontext.SaveChangesAsync();

                    return Ok("Imagen insertada exitosamente.");
                }
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Error "});
            }
            

            
        }

    }
}
