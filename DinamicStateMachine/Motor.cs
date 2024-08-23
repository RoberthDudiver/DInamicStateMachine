using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DInamicStateMachine
{

    public class Motor
    {
        private List<Rule> reglas;

        public Motor(List<Rule> reglas)
        {
            this.reglas = reglas;
        }

        public void AplicarReglas(string estadoActual, string estadoNuevo)
        {
            foreach (var regla in reglas)
            {
                if (regla.EstadoOrigen == estadoActual && regla.EstadoDestino == estadoNuevo)
                {
                    EjecutarAccionDesdeRegla(regla);
                    return;
                }
            }

            Console.WriteLine($"No se encontró ninguna regla para pasar de {estadoActual} a {estadoNuevo}.");
        }

        private void EjecutarAccionDesdeRegla(Rule regla)
        {
            if (regla.Accion != null)
            {
                string dllPath = Path.Combine("Procesos", regla.Accion.Dll);
                Assembly dllAssembly = Assembly.LoadFrom(dllPath);

                Type tipoImplementacion = dllAssembly.GetTypes()
                    .FirstOrDefault(type => type.Name == regla.Accion.Tipo && typeof(IActionRule).IsAssignableFrom(type));

                if (tipoImplementacion != null)
                {
                    var instanciaAccion = Activator.CreateInstance(tipoImplementacion) as IActionRule;

                    instanciaAccion?.Ejecutar(regla.EstadoOrigen, regla.EstadoDestino);
                }
                else
                {
                    Console.WriteLine($"No se encontró la implementación de IReglaAccion en la DLL {regla.Accion.Dll} para la acción {regla.Accion.Tipo}.");
                }
            }
        }
    }


}