
using SERVICE_LEPETITCAFE.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Servicios_WEB_6_8.Clases
{
    public class CarroCompras
    {
        private readonly le_petit_cafeEntities3 dbpeti = new le_petit_cafeEntities3();

        public string Insertar(CarritoCompra carro)
        {
            try
            {
                dbpeti.CarritoCompras.Add(carro);
                dbpeti.SaveChanges();
                return "Se grabó el pedido: " + carro.Id;
            }
            catch (Exception ex)
            {
                return $"Error al insertar el carro de compras: {ex.Message}";
            }
        }

        public string Actualizar(CarritoCompra carro)
        {
            try
            {
                dbpeti.CarritoCompras.AddOrUpdate(carro);
                dbpeti.SaveChanges();
                return "Se actualizó los datos del pedido: " + carro.Id;
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el carro de compras: {ex.Message}";
            }
        }

        public CarritoCompra Consultar(int id)
        {
            try
            {
                return dbpeti.CarritoCompras.FirstOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                CarritoCompra carro = Consultar(id);
                if (carro != null)
                {
                    dbpeti.CarritoCompras.Remove(carro);
                    dbpeti.SaveChanges();
                    return "Se eliminó el pedido con ID: " + id;
                }
                else
                {
                    return "No se encontró el carro de compras con ID: " + id;
                }
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el carro de compras: {ex.Message}";
            }
        }
    }
}

