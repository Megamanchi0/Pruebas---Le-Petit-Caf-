using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SERVICE_LEPETITCAFE.Models;

namespace SERVICIO_PETIT.Clases
{
    public class clsPedido
    {
        le_petit_cafeEntities3 db = new le_petit_cafeEntities3();

        public Pedido Buscar(int id)
        {
            return db.Pedidoes.FirstOrDefault(e => e.Id == id);
        }
        
        //public List<Pedido> listarPedidos()
        //{
          //  return db.Pedido.ToList();
        //}

        public IQueryable listarPedidos()
        {
            IQueryable consulta = from P in db.Set<Pedido>()
                                  join C in db.Set<Cliente>()
                                  on P.ClienteCedula equals C.Cedula
                                  select new
                                  {
                                      Codigo = P.Id,
                                      NOMBRE = C.Nombre,
                                      TELEFONO = C.Celular,
                                      DIRECCION = C.Direccion
                                  };
            return consulta;
        }
    }
}