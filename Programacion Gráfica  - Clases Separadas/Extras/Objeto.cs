using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Proyecto1
{
    public class Objeto
    {
        private Dictionary<string,Cara> Caras = null;
        public Punto origen;
    

        public Objeto()
        {
            Caras = new Dictionary<string, Cara>();
            origen = new Punto();
        }

        public Objeto(Dictionary<string, Cara> C, Punto Centro) 
        {
            Caras = C;
            origen = Centro;
        }

        public void AgregarCara(string cad, Cara C)
        {
            Caras.Add(cad, C);
        }

        public Dictionary<string, Cara> ObtenerCaras()
        {
            return Caras;
        }

        public int CantCaras()
        {
            return Caras.Count();
        }

        public Cara ObtenerCara(string id)
        {
            return Caras[id];
        }

        public void Dibujar()
        {

            
            foreach (var Cara in Caras)
            {
                Cara.Value.Dibujar();
            }
            GL.End();
        }
    }
}
