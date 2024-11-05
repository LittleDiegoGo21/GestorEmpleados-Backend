using GestorEmpleados.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiWebAPI.Data;
using MiWebAPI.Models;

namespace MiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly CompraData _compraData;
        public CompraController(CompraData compraData)
        {
            _compraData = compraData;
        }

        [HttpPost]
        [Route("GetCompra")]
        public async Task<IActionResult> Lista([FromBody] String filtro)
        {
            List<Compra> Lista = await _compraData.GetCompra(filtro);
            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpPost]
        [Route("AddCompra")]
        public async Task<IActionResult> AddEmpleado([FromBody] Compra objeto)
        {
            var respuesta = await _compraData.AddCompra(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpPost]
        [Route("UpdateCompra")]
        public async Task<IActionResult> UpdateEmpleado([FromBody] Compra objeto)
        {
            var respuesta = await _compraData.UpdateCompra(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpPost]
        [Route("DeleteCompra")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var respuesta = await _compraData.DeleteCompra(id);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }
    }
}

