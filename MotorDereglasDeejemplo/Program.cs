// En tu aplicación principal
using Common;
using DInamicStateMachine;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

class Program
{
    static void Main()
    {
        string jsonPath = "reglas.json";
        string jsonContent = File.ReadAllText(jsonPath);

        List<Rule> reglas = JsonConvert.DeserializeObject<List<Rule>>(jsonContent);

        Motor motor = new Motor(reglas);
        motor.AplicarReglas("Abierto", "Cerrado");
        motor.AplicarReglas("Cerrado", "En Carga");
    }
}

