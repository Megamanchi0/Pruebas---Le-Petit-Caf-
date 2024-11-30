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
    public class IngredienteController : ApiController
    {
        // GET api/<controller>
        public List<Ingrediente> Get()
        {
            clsIngrediente _ing = new clsIngrediente();
            return _ing.Tabla();
        }

        // GET api/<controller>/5
        public Ingrediente Get(int id)
        {
            clsIngrediente _ing = new clsIngrediente();
            return _ing.Buscar(id);
        }

        // POST api/<controller>
        public string Post([FromBody] Ingrediente ingrediente)
        {
            clsIngrediente _ing = new clsIngrediente();
            _ing.ingrediente = ingrediente;
            return _ing.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Ingrediente ingrediente)
        {
            clsIngrediente _ing = new clsIngrediente();
            _ing.ingrediente = ingrediente;
            return _ing.Actualizar();
        }
    }
}