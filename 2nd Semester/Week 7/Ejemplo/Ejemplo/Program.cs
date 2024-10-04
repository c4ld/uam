string ruta = "archivo.bin";
string escrito = "¡Adiós, mundo!";

try
{
    string contenido = File.ReadAllText(ruta);
    Console.WriteLine(contenido);
    File.WriteAllText(ruta, escrito);
}
catch (FileNotFoundException e)
{
    Console.WriteLine("Archivo no encontrado: " + e.Message);
}