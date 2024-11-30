using SERVICE_LEPETITCAFE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SERVICE_LEPETITCAFE.Class
{
    public class clsIngrediente
    {
        le_petit_cafeEntities3 db = new le_petit_cafeEntities3();
        public Ingrediente ingrediente { get; set; }

        public string Insertar()
        {
            try
            {
                db.Ingredientes.Add(ingrediente);
                db.SaveChanges();
                return "Se guardó el ingrediente: " + ingrediente.Descripción;
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
                db.Ingredientes.AddOrUpdate(ingrediente);
                db.SaveChanges();
                return "Se actualizó el ingrediente: " + ingrediente.Descripción;
            }
            catch (DbEntityValidationException ex)
            {
                return ex.Message;
            }
        }

        public Ingrediente Buscar(int id)
        {
            return db.Ingredientes.FirstOrDefault(i => i.Id == id);
        }

        public List<Ingrediente> Tabla()
        {
            return db.Ingredientes.ToList();
        }
    }
}