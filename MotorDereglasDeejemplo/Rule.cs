using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DInamicStateMachine
{
    public class Rule
    {
        public string EstadoOrigen { get; set; }
        public string EstadoDestino { get; set; }
        public Action Accion { get; set; }

    }

    public class Action
    {
        public string Tipo { get; set; }
        public string Dll { get; set; }

    }

}
