using SERVICE_LEPETITCAFE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SERVICE_LEPETITCAFE.Class
{

    public class clsEmpleado
    {
        public le_petit_cafeEntities3 db = new le_petit_cafeEntities3();
        public Empleado empleado { get; set; }

        public string Insertar()
        {
            try
            {
                db.Empleadoes.Add(empleado);
                db.SaveChanges();
                return "Se guardó el empleado: " + empleado.Nombre + " " + empleado.Apellido;
            }
            catch (DbEntityValidationException ex)
            {
                return ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                db.Empleadoes.AddOrUpdate(empleado);
                db.SaveChanges();
                return "Se actualizó el empleado: " + empleado.Nombre + " " + empleado.Apellido;
            }
            catch (DbEntityValidationException ex)
            {
                return ex.Message;
            }
        }

        public Empleado Buscar(string cedula)
        {
            return db.Empleadoes.FirstOrDefault(e => e.Cedula == cedula);
        }

        public List<Empleado> Tabla()
        {
            return db.Empleadoes.ToList();     
        }
    }
}