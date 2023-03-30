using Asincrona10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asincrona10.DAO
{
    internal class CrudProducto
    {
      
        public void AgregarProducto(Producto ParametroProducto)
        {
            using (AlmacenContexto db = new AlmacenContexto())
            {
                Producto producto = new Producto();
                producto.Nombre = ParametroProducto.Nombre;
                producto.Descripcion = ParametroProducto.Descripcion;
                producto.Precio = ParametroProducto.Precio;
                producto.Stock = ParametroProducto.Stock;
                db.Add(producto);
                db.SaveChanges();

            }
        }
        public Producto ProductoIndividual(int id)
        {
            using (AlmacenContexto db = new AlmacenContexto())
            {
                var buscar = db.Productos.FirstOrDefault(x => x.Id == id);
                return buscar;
            }
        }
        public void ActualizarProducto(Producto ParametrosProducto, int Lector)
        {
            using (AlmacenContexto db =
                new AlmacenContexto())
            {

                var buscar = db.Productos.FirstOrDefault(x => x.Id == ParametrosProducto.Id);
                if (buscar == null)
                {

                    Console.WriteLine("El ID no existe");

                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.Nombre = ParametrosProducto.Nombre;
                    }
                    if (Lector == 2)
                    {
                        buscar.Descripcion = ParametrosProducto.Descripcion;
                    }
                    if (Lector == 3)
                    {
                        buscar.Precio = ParametrosProducto.Precio;
                    }
                    else
                    {
                        buscar.Stock = ParametrosProducto.Stock;
                    }


                    db.Update(buscar);
                    db.SaveChanges();



                }

            }
        }
        public string EliminarProducto(int id)
        {
            using (AlmacenContexto db = new AlmacenContexto())
            {
                var buscar = ProductoIndividual(id);
                if (buscar == null)
                {
                    return "Este producto no existe ";
                }
                else
                {
                    db.Productos.Remove(buscar);
                    db.SaveChanges();
                    return "Este producto se ha eliminado";
                }
            }
        }
        public List<Producto> ListarProductos()
        {
            using (AlmacenContexto db = new AlmacenContexto())
            { return db.Productos.ToList(); }
        }
    }
}
    

