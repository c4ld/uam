using Microsoft.VisualBasic.FileIO;

string archivo = "binario.bin";

string mensaje;
int cif = 23020134;

using (BinaryWriter Escritor = new BinaryWriter(File.Open(archivo, FileMode.Append)))
{
    Escritor.Write(cif);
    Escritor.Write($"Su CIF es {cif}");
}

using (BinaryReader Lector = new BinaryReader(File.Open(archivo, FileMode.Open)))
{
    mensaje = Lector.ReadString();
}
Console.WriteLine(mensaje);