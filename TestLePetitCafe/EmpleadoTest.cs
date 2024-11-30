using Moq;
using SERVICE_LEPETITCAFE.Class;
using SERVICE_LEPETITCAFE.Models;

using System.Data.Entity;

namespace TestLePetitCafe
{
    public class EmpleadoTest
    {
        [Fact]
        public void AgregarEmpleadoCorrectamente()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<Empleado>>();
            var mockContext = new Mock<le_petit_cafeEntities3>();

            mockContext.Setup(m => m.Empleadoes).Returns(mockDbSet.Object);

            var empleado = new Empleado { Nombre = "Luis", Apellido = "López", Cedula = "345753", Celular = "50003466", Estado = true, Correo = "luis@gmail.com", Contraseña = "luis123" };

            // Instancia de clsEmpleado
            var claseEmpleado = new clsEmpleado()
            {
                db = mockContext.Object,
                empleado = empleado
            };

            var resultado = claseEmpleado.Insertar();

            // Assert
            mockDbSet.Verify(m => m.Add(It.IsAny<Empleado>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
            Assert.Equal("Se guardó el empleado: Luis López", resultado);
        }

        [Fact]
        public void BuscarEmpleadoCorrectamente()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<Empleado>>();
            var mockContext = new Mock<le_petit_cafeEntities3>();

            // Simulamos que el DbSet tiene empleados
            var empleados = new List<Empleado>
            {
                new Empleado { Nombre = "Luis", Apellido = "López", Cedula = "12345678", Celular = "50003466", Estado = true, Correo = "luis@gmail.com", Contraseña = "luis123" },
                new Empleado { Nombre = "Pedro", Apellido = "Muriel", Cedula = "54564654", Celular = "86565464", Estado = true, Correo = "pedro@gmail.com", Contraseña = "pedro123" }
            }.AsQueryable();

            // Configuramos el DbSet para que devuelva la lista de empleados simulados
            mockDbSet.As<IQueryable<Empleado>>().Setup(m => m.Provider).Returns(empleados.Provider);
            mockDbSet.As<IQueryable<Empleado>>().Setup(m => m.Expression).Returns(empleados.Expression);
            mockDbSet.As<IQueryable<Empleado>>().Setup(m => m.ElementType).Returns(empleados.ElementType);
            mockDbSet.As<IQueryable<Empleado>>().Setup(m => m.GetEnumerator()).Returns(empleados.GetEnumerator());

            // Configuramos el contexto para que devuelva el DbSet simulado
            mockContext.Setup(c => c.Empleadoes).Returns(mockDbSet.Object);

            // Creamos la instancia de la clase que estamos testeando
            var empleadoService = new clsEmpleado
            {
                db = mockContext.Object
            };

            // Act
            var resultado = empleadoService.Buscar("12345678");

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("12345678", resultado.Cedula);
            Assert.Equal("Luis", resultado.Nombre);
            Assert.Equal("López", resultado.Apellido);
        }

        [Fact]
        public void ConsultarListaDeEmpleadosExitosamente()
        {
            // Arrange
            var empleados = new List<Empleado>
            {
                new Empleado { Nombre = "Luis", Apellido = "López", Cedula = "12345678", Celular = "50003466", Estado = true, Correo = "luis@gmail.com", Contraseña = "luis123" },
                    new Empleado { Nombre = "Pedro", Apellido = "Muriel", Cedula = "54564654", Celular = "86565464", Estado = true, Correo = "pedro@gmail.com", Contraseña = "pedro123" }
            };

            var mockDbSet = new Mock<DbSet<Empleado>>();

            // Configurar el mock para que se comporte como un IQueryable de empleados
            mockDbSet.As<IQueryable<Empleado>>()
                .Setup(m => m.Provider).Returns(empleados.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Empleado>>()
                .Setup(m => m.Expression).Returns(empleados.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Empleado>>()
                .Setup(m => m.ElementType).Returns(empleados.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Empleado>>()
                .Setup(m => m.GetEnumerator()).Returns(empleados.GetEnumerator());

            // Configurar el contexto para que devuelva el DbSet simulado
            var mockContext = new Mock<le_petit_cafeEntities3>();
            mockContext.Setup(c => c.Empleadoes).Returns(mockDbSet.Object);

            // Crear una instancia de la clase que estamos probando.
            var cls = new clsEmpleado
            {
                db = mockContext.Object
            };

            // Act
            var result = cls.Tabla();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, e => e.Nombre == "Luis");
            Assert.Contains(result, e => e.Nombre == "Pedro");
        }
    }
}
