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
    public class EmpleadoController : ApiController
    {
        public List<Empleado> Get()
        {
            clsEmpleado _emp = new clsEmpleado();
            return _emp.Tabla();
        }

        // GET api/<controller>/5
        public Empleado Get(string cedula)
        {
            clsEmpleado _emp = new clsEmpleado();
            return _emp.Buscar(cedula);
        }

        // POST api/<controller>
        public string Post([FromBody] Empleado empleado)
        {
            clsEmpleado _emp = new clsEmpleado();
            _emp.empleado = empleado;
            return _emp.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Empleado empleado)
        {
            clsEmpleado _emp = new clsEmpleado();
            _emp.empleado = empleado;
            return _emp.Actualizar();
        }
    }
}