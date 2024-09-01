using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    public class Escenario
    {
        private Dictionary<string, Objeto> Objetos = null;
        public Proyecto1.Punto origen;

        public Escenario()
        {
            Objetos = new Dictionary<string, Objeto>();
            origen = new Proyecto1.Punto();
        }

        public Escenario(Punto Centro,Dictionary<string, Objeto> O)
        {
            Objetos = O;
            origen = Centro;

        }

        public void AddObjeto(string s, Objeto O)
        {
            Objetos.Add(s,O);
        }

        public void DeleteObjeto(string s, Objeto O)
        {
            Objetos.Remove(s);
        }
        public void Dibujar()
        {
              

            foreach (var Objeto in Objetos)
            {
                Objeto.Value.Dibujar();
            }
        }
        
    }
}
