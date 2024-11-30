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
    public class RegistrarController : ApiController
    {
       
        public string Post([FromBody] Cliente cliente)
        {
            clsRegistrar _registrar = new clsRegistrar();
            _registrar.cliente = cliente;
            return _registrar.Insertar();
        }

    }
}