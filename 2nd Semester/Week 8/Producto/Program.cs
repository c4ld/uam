using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public struct Producto  //Crea struct
{
    public int Codigo { get; set; }
    public string Descripcion { get; set; }
    public float Precio { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Producto> productos = new List<Producto>  //Crea Lista
        {
            new Producto { Codigo = 1, Descripcion = "Producto 1", Precio = 10.5f },
            new Producto { Codigo = 2, Descripcion = "Producto 2", Precio = 20.0f },
            new Producto { Codigo = 3, Descripcion = "Producto 3", Precio = 30.75f }
        };

        // Configuración para escribir JSON con indentación
        var options = new JsonSerializerOptions { WriteIndented = true };

        string ruta = "productos.json";

        // Escribir la lista de productos en un archivo JSON
        using (FileStream fs = new FileStream(ruta, FileMode.Create))
        {
            JsonSerializer.Serialize(fs, productos, options);  // Se pasa 'options' aquí
        }

        Console.WriteLine("Productos escritos exitosamente en el archivo JSON.");

        // Leer la lista de productos desde el archivo JSON
        List<Producto> productosLeidos;
        using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
        {
            productosLeidos = JsonSerializer.Deserialize<List<Producto>>(fs);
        }

Console.WriteLine(@"╔═══════════════════════╦════════════════════╦══════════════╗
║ Código                ║ Descripción        ║ Precio       ║
╠═══════════════════════╩════════════════════╩══════════════╣");

foreach (var producto in productosLeidos)
{
    Console.WriteLine("║                                                           ║");
    Console.WriteLine($"║ {producto.Codigo,-21}   {producto.Descripcion,-18}   {producto.Precio,-12} ║");
    Console.WriteLine("║                                                           ║");

Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");

    }
}
}
