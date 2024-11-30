using SERVICE_LEPETITCAFE.Models;
using Servicios_WEB_6_8.Clases;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios_WEB_6_8.Controllers
{
    [EnableCors(origins: "http://localhost:65403", headers: "*", methods: "*")]
    public class CarController : ApiController
    {
        private CarroCompras _carroCompras = new CarroCompras();

        // GET: api/carController/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                CarritoCompra carro = _carroCompras.Consultar(id);
                if (carro != null)
                {
                    return Ok(carro);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al consultar el carro de compras: {ex.Message}"));
            }
        }

        // POST: api/carController
        public IHttpActionResult Post([FromBody] CarritoCompra carro)
        {
            if (carro == null)
            {
                return BadRequest("El carro de compras no puede ser nulo.");
            }

            try
            {
                string resultado = _carroCompras.Insertar(carro);
                if (resultado.Contains("Se grabó el pedido"))
                {
                    return Ok(resultado);
                }
                else
                {
                    return InternalServerError(new Exception(resultado));
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al insertar el carro de compras: {ex.Message}"));
            }
        }

        // PUT: api/carController/5
        public IHttpActionResult Put(int id, [FromBody] CarritoCompra carro)
        {
            if (carro == null)
            {
                return BadRequest("El carro de compras no puede ser nulo.");
            }

            carro.Id = id;

            try
            {
                string resultado = _carroCompras.Actualizar(carro);
                if (resultado.Contains("Se actualizó los datos del pedido"))
                {
                    return Ok(resultado);
                }
                else
                {
                    return InternalServerError(new Exception(resultado));
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al actualizar el carro de compras: {ex.Message}"));
            }
        }

        // DELETE: api/carController/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                string resultado = _carroCompras.Eliminar(id);
                if (resultado.Contains("Se eliminó el pedido"))
                {
                    return Ok(resultado);
                }
                else
                {
                    return InternalServerError(new Exception(resultado));
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al eliminar el carro de compras: {ex.Message}"));
            }
        }
    }
}
