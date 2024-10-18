using System;
using System.Collections.Generic;

public struct Producto
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
}

class Program
{
    static List<Producto> inventario = new List<Producto>();

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.WriteLine("===== Menú Principal =====");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Eliminar producto");
            Console.WriteLine("3. Modificar producto");
            Console.WriteLine("4. Consultar productos");
            Console.WriteLine("5. Mostrar todos los productos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarProducto();
                    break;
                case 2:
                    EliminarProducto();
                    break;
                case 3:
                    ModificarProducto();
                    break;
                case 4:
                    MostrarProductos();
                    break;
                case 5:
                    MostrarProductos();
                    break;
                case 6:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 6);
    }

static void AgregarProducto()
{
    Producto producto = new Producto();
    Console.Write("Ingrese el código del producto: ");
    producto.Codigo = Console.ReadLine();
    Console.Write("Ingrese el nombre del producto: ");
    producto.Nombre = Console.ReadLine();
    Console.Write("Ingrese la cantidad del producto: ");
    producto.Cantidad = int.Parse(Console.ReadLine());

    // Validar que el precio no sea negativo
    decimal precio;
    while (true)
    {
        Console.Write("Ingrese el precio del producto: ");
        if (decimal.TryParse(Console.ReadLine(), out precio) && precio >= 0)
        {
            producto.Precio = precio;
            break;
        }
        else
        {
            Console.WriteLine("Error: El precio no puede ser negativo. Inténtelo de nuevo.");
        }
    }

    inventario.Add(producto);
    Console.WriteLine("Producto agregado correctamente.");
}


    static void EliminarProducto()
    {
        Console.Write("Ingrese el código del producto a eliminar: ");
        string codigo = Console.ReadLine();
        Producto? productoAEliminar = inventario.Find(p => p.Codigo == codigo);

        if (productoAEliminar.HasValue)
        {
            inventario.Remove(productoAEliminar.Value);
            Console.WriteLine("Producto eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void ModificarProducto()
    {
        Console.Write("Ingrese el código del producto a modificar: ");
        string codigo = Console.ReadLine();
        int indice = inventario.FindIndex(p => p.Codigo == codigo);

        if (indice != -1)
        {
            Producto producto = inventario[indice];

            Console.Write("Ingrese el nuevo nombre del producto (anterior: {0}): ", producto.Nombre);
            producto.Nombre = Console.ReadLine();
            Console.Write("Ingrese la nueva cantidad (anterior: {0}): ", producto.Cantidad);
            producto.Cantidad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el nuevo precio (anterior: {0}): ", producto.Precio);
            producto.Precio = decimal.Parse(Console.ReadLine());

            inventario[indice] = producto;
            Console.WriteLine("Producto modificado correctamente.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void MostrarProductos()
    {
        if (inventario.Count > 0)
        {
            Console.WriteLine("===== Inventario de Productos =====");
            Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10}", "Código", "Nombre", "Cantidad", "Precio");

            foreach (var producto in inventario)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10:C}", 
                producto.Codigo, producto.Nombre, producto.Cantidad, producto.Precio);
            }
        }
        else
        {
            Console.WriteLine("No hay productos en el inventario.");
        }
    }
}
