using SERVICE_LEPETITCAFE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SERVICE_LEPETITCAFE.Class
{
    public class clsProducto
    {
        public le_petit_cafeEntities3 db = new le_petit_cafeEntities3();
        public Producto producto { get; set; }

        public string Insertar()
        {
            try
            {
                db.Productoes.Add(producto);
                db.SaveChanges();
                return "Se guardó el producto: " + producto.Nombre;
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
                db.Productoes.AddOrUpdate(producto);
                db.SaveChanges();
                return "Se actualizó el producto: " + producto.Nombre;
            }
            catch (DbEntityValidationException ex)
            {
                return ex.Message;
            }
        }

        public Producto Buscar(int id)
        {
            return db.Productoes.FirstOrDefault(p => p.Id == id);
        }

        public string DesactivarProducto(int idProducto)
        {
            try
            {
                var _producto = Buscar(idProducto);
                _producto.Estado = false;
                db.Entry(_producto).CurrentValues.SetValues(_producto);
                db.SaveChanges();
                return "Se desactivó el producto: " + _producto.Nombre;
            }
            catch (DbEntityValidationException ex)
            {
                return ex.Message;
            }
        }

        public List<Producto> Tabla()
        {
            return db.Productoes.ToList();
        }
    }
}