using SERVICE_LEPETITCAFE.Class;
using SERVICE_LEPETITCAFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SERVICE_LEPETITCAFE.Controllers
{
    [EnableCors(origins: "http://localhost:65403", headers: "*", methods: "*")]
    public class ProductoController : ApiController
    {
        // GET api/<controller>
        public List<Producto> Get()
        {
            clsProducto _prod = new clsProducto();
            return _prod.Tabla();
        }

        // GET api/<controller>/5
        public Producto Get(int id)
        {
            clsProducto _prod = new clsProducto();
            return _prod.Buscar(id);
        }

        // POST api/<controller>
        public string Post([FromBody] Producto producto)
        {
            clsProducto _prod = new clsProducto();
            _prod.producto = producto;
            return _prod.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Producto producto)
        {
            clsProducto _prod = new clsProducto();
            _prod.producto = producto;
            return _prod.Actualizar();
        }
    }
}