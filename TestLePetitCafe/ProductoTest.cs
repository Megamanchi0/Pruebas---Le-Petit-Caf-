using Moq;

using SERVICE_LEPETITCAFE.Class;
using SERVICE_LEPETITCAFE.Models;
using System.Data.Entity;

namespace TestLePetitCafe
{
    public class ProductoTest
    {
        [Fact]
        public void AgregarProductoCorrectamente()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<Producto>>();
            var mockContext = new Mock<le_petit_cafeEntities3>();

            mockContext.Setup(m => m.Productoes).Returns(mockDbSet.Object);

            var producto = new Producto { Nombre = "Caf� Latte", Descripci�n = "Caf� Latte", Cantidad = 10, Precio = 5000, Estado = true };

            // Instancia de clsProducto
            var claseProducto = new clsProducto()
            {
                db = mockContext.Object,
                producto = producto
            };

            var resultado = claseProducto.Insertar();

            // Assert
            mockDbSet.Verify(m => m.Add(It.IsAny<Producto>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
            Assert.Equal("Se guard� el producto: Caf� Latte", resultado);
        }

        [Fact]
        public void BuscarProductoCorrectamente()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<Producto>>();
            var mockContext = new Mock<le_petit_cafeEntities3>();

            var productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Caf� Espresso", Precio = 2.5m },
            new Producto { Id = 2, Nombre = "Caf� Latte", Precio = 3.0m }
        }.AsQueryable();

            mockDbSet.As<IQueryable<Producto>>().Setup(m => m.Provider).Returns(productos.Provider);
            mockDbSet.As<IQueryable<Producto>>().Setup(m => m.Expression).Returns(productos.Expression);
            mockDbSet.As<IQueryable<Producto>>().Setup(m => m.ElementType).Returns(productos.ElementType);
            mockDbSet.As<IQueryable<Producto>>().Setup(m => m.GetEnumerator()).Returns(productos.GetEnumerator());

            mockContext.Setup(c => c.Productoes).Returns(mockDbSet.Object);

            var productoService = new clsProducto
            {
                db = mockContext.Object
            };

            // Act
            var resultado = productoService.Buscar(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(1, resultado.Id);
            Assert.Equal("Caf� Espresso", resultado.Nombre);
        }

        [Fact]
        public void ConsultarListaDeProductosExitosamente()
        {
            // Arrange
            var productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Caf� Expreso", Estado = true },
            new Producto { Id = 2, Nombre = "Caf� Capuchino", Estado = true }
        };

            var mockDbSet = new Mock<DbSet<Producto>>();

            // Configurar el mock para que se comporte como un IQueryable de productos
            mockDbSet.As<IQueryable<Producto>>()
                .Setup(m => m.Provider).Returns(productos.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Producto>>()
                .Setup(m => m.Expression).Returns(productos.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Producto>>()
                .Setup(m => m.ElementType).Returns(productos.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Producto>>()
                .Setup(m => m.GetEnumerator()).Returns(productos.GetEnumerator());

            // Configurar el contexto para que devuelva el DbSet simulado
            var mockContext = new Mock<le_petit_cafeEntities3>();
            mockContext.Setup(c => c.Productoes).Returns(mockDbSet.Object);

            // Crear una instancia de la clase que estamos probando.
            var cls = new clsProducto
            {
                db = mockContext.Object
            };

            // Act
            var result = cls.Tabla();

            // Assert
            Assert.NotNull(result);  // Verifica que no sea nulo
            Assert.Equal(2, result.Count);  // Verifica que haya 2 productos en la lista
            Assert.Contains(result, p => p.Nombre == "Caf� Expreso");  // Verifica que "Caf� Expreso" est� en la lista
            Assert.Contains(result, p => p.Nombre == "Caf� Capuchino");  // Verifica que "Caf� Capuchino" est� en la lista
        }
    }
}