using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SERVICIO_PETIT.Clases;
using SERVICE_LEPETITCAFE.Models;


namespace SERVICIO_PETIT.Controllers
{
    [EnableCors(origins: "http://localhost:65403", headers: "*", methods: "*")]
    public class PedidoController : ApiController
    {

        // GET: Pedido
       public IQueryable Get()
        {
            List<int> list = new List<int> { 2,4,53,3 };
            if (list.Count()>0)
            {
                string resultado;
            }
            clsPedido _Pedido = new clsPedido();
            return _Pedido.listarPedidos();
        }

        public Pedido Get(int id)
        {
            clsPedido _pedido = new clsPedido();
            return _pedido.Buscar(id);
        }
    }
}