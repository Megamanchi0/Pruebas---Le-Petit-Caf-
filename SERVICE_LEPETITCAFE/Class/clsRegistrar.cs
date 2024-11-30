using SERVICE_LEPETITCAFE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SERVICE_LEPETITCAFE.Class
{
    public class clsRegistrar
    {
        le_petit_cafeEntities3 datos = new le_petit_cafeEntities3();

        public Cliente cliente { get; set; }

        public string Insertar()
        {
            try
            {
                datos.Clientes.Add(cliente);
                datos.SaveChanges();
                return "Registro exitoso";
            }
            catch (DbEntityValidationException ex)
            {
                return ex.Message;
            }
        }
        //public Producto Buscar(int Correo)
        //{
        //   //return datos.Clientes.FirstOrDefault(p => p.Correo == Correo);
        //}
    }
}