using System;
using System.IO;

string rutaArchivo = "archivo.bin";
string cadenaBinaria = File.ReadAllText(rutaArchivo).Trim();
cadenaBinaria = cadenaBinaria.Replace(" ", "");

string textoConvertido = ConvertirBinarioATexto(cadenaBinaria);
Console.WriteLine("Texto convertido:");
Console.WriteLine(textoConvertido);

static string ConvertirBinarioATexto(string cadenaBinaria)
{
    string resultado = "";
    for (int i = 0; i < cadenaBinaria.Length; i += 8)
    {
        if (i + 8 <= cadenaBinaria.Length)
        {
            string byteBinario = cadenaBinaria.Substring(i, 8);
            resultado += (char)Convert.ToByte(byteBinario, 2);
        }
    }
    return resultado;
}
