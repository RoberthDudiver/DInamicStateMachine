using Common;
using System;

namespace ReglasLibrary;
public class EjemploEventoAccion : IActionRule
{
    public void Ejecutar(string estadoActual, string estadoNuevo)
    {
        Console.WriteLine($"EjemploEventoAccion ejecutada: {estadoActual} -> {estadoNuevo}");
    }
}
