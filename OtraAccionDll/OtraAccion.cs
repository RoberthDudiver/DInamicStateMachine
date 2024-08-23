using Common;
using System;

namespace ReglasLibrary;
public class OtraAccion : IActionRule
{
    public void Ejecutar(string estadoActual, string estadoNuevo)
    {
        Console.WriteLine($"OtraAccion  pepito ejecutada: {estadoActual} -> {estadoNuevo}");
    }
}
