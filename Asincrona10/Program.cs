using Asincrona10.Models;
using Asincrona10.DAO;
using System.Runtime.CompilerServices;

CrudProducto CrudProducto = new CrudProducto();
Producto Producto = new Producto();

bool continuar = true;
while (continuar)
{

    Console.WriteLine("Menu");
    Console.WriteLine("Por favor pulsar el boton 1 para insertar un nuevo producto");
    Console.WriteLine("Por favor pulsar el boton 2 para Actuliazar un producto");
    Console.WriteLine("Por favor pulsar el boton 3 para eliminar un producto");
    Console.WriteLine("Por favor pulsar el boton 4 para listar los productos");

    var Menu = Convert.ToInt32(Console.ReadLine());

    switch (Menu)
    {

        case 1:
            int bucle = 1;
            while (bucle == 1)
            {
                Console.WriteLine("Por favor ingrese el nombre del producto que quiere");
                Producto.Nombre = Console.ReadLine();
                Console.WriteLine("Por favor ingrese la descripcion del producto que desea");
                Producto.Descripcion = Console.ReadLine();
                Console.WriteLine("Por favor ingrese el precio del producto 00.00");
                Producto.Precio = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Por favor ingrese la cantidad de producto en stock");
                Producto.Stock = Convert.ToInt32(Console.ReadLine());
                CrudProducto.AgregarProducto(Producto);
                Console.WriteLine("El que eligio producto se agrego correctamente ");
                Console.WriteLine("Por favor ingrse el boton 1 para agregar otro producto");
                Console.WriteLine("Ingrse el boton 0 para salir");
                bucle = Convert.ToInt32(Console.ReadLine());
            }
            break;

        case 2:
            Console.WriteLine("actualizar datos");
            Console.WriteLine("ingresa el ID del producto que va a actualizar");
            var productoIndividual = CrudProducto.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            if (productoIndividual == null)
            {
                Console.WriteLine("Este producto no exite");
            }
            else
            {

                Console.WriteLine($"Nombre {productoIndividual.Nombre},descripcion {productoIndividual.Descripcion}, Precio {productoIndividual.Precio}, Stock{productoIndividual.Stock}");
                Console.WriteLine("Si desea actualizar nombre presione 1");
                Console.WriteLine("Si desea actualizar la descripcion coloca el numero 2 ");
                Console.WriteLine("Si desea actualizar  el precio presione 3");
                Console.WriteLine("Si desea actualizar la catidad en stock presione 4");

                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    Console.WriteLine("Por favor ingrese el nombre");
                    productoIndividual.Nombre = Console.ReadLine();
                }
                if (Lector == 2)
                {
                    Console.WriteLine("Por favor ingrese la descripcion");
                    productoIndividual.Descripcion = Console.ReadLine();
                }
                if (Lector == 3)
                {
                    Console.WriteLine("Por favor ingrese el precio");
                    productoIndividual.Precio = Convert.ToDecimal(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Por favor ingrese la cantidad en stock");
                    productoIndividual.Stock = Convert.ToInt32(Console.ReadLine());
                }
                CrudProducto.ActualizarProducto(productoIndividual, Lector);
            }
            break;
        case 3:
            Console.WriteLine("Por favor ingrese el ID que va a eliminar");
            var ProductoIndividualD = CrudProducto.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            if (ProductoIndividualD == null)
            {
                Console.WriteLine("Este producto no existe");
            }
            else
            {
                Console.WriteLine("Eliminar producto");

                Console.WriteLine($"Nombre {ProductoIndividualD.Nombre},descripcion {ProductoIndividualD.Descripcion}, Precio {ProductoIndividualD.Precio}, Stock{ProductoIndividualD.Stock}");
                Console.WriteLine("El producto es el correcto si desea eliminarlo tiene que precionar la tecla 1");

                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    var id = Convert.ToInt32(ProductoIndividualD.Id);
                    Console.WriteLine(CrudProducto.EliminarProducto(id));
                }

            }

            break;
        case 4:
            Console.WriteLine("Lista de productos");
            var ListarProductos = CrudProducto.ListarProductos();
            foreach (var iteracionProductos in ListarProductos)
            {
                Console.WriteLine($"{iteracionProductos.Id},{iteracionProductos.Nombre},{iteracionProductos.Descripcion},{iteracionProductos.Precio},{iteracionProductos.Stock}");
            }
            break;



    }



    Console.WriteLine("Quiere continuar? de ser asi, Presione Z para Si M para NO");
    var cont = Console.ReadLine();
    if (cont.Equals("N"))
    {
        continuar = false;
    }
}
