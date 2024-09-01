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
    public class Cara
    {
        private Dictionary<string,Vertice> Vertices = null;
        public Punto Origen;
        
        public Cara() 
        {
                Vertices = new Dictionary<string, Vertice>();
            Origen = new Punto();
        }

        public Cara(Punto Centro, Dictionary<string, Vertice> V)
        {
                Vertices = V;
                Origen = Centro;
        }

        public void AgregarVertice(string s,Vertice V) 
        {
                Vertices.Add(s,V);    
        }

        public Dictionary<string, Vertice> ObtenerVertices()
        {
            return Vertices;
        }

        public int CantVertices()
        {
            return Vertices.Count();
        }

        public void BorrarVertice(string id) 
        {
            Vertices.Remove(id);
        }

        public Vertice ObtenerVertice(string id)
        {
            return Vertices[id];
        }

        public void Dibujar()
        {
            
            GL.Color4(Color4.Red);
            GL.Begin(PrimitiveType.LineLoop);
            foreach (var Vertice in Vertices)
            {
               
               

                GL.Vertex3(Vertice.Value.ObtenerArreglo()); // Vertice= x=10 y=10 z=0;


            }
            GL.End();
        }
        

    }
}

