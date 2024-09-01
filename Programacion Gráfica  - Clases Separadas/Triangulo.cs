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
    public class triangulo
    {
        private float punto1;
        private float ancho;
        private float profundidad;
        private Punto origen;

        public triangulo(Punto p, float punto1, float ancho, float profundidad) 
        {
            origen = p;
            this.punto1 = punto1;
            this.ancho=ancho;
            this.profundidad = profundidad;
        }

        public void Dibujar()
        {
            GL.Rotate(2, 1, 1, 0);
            PrimitiveType primitiveType = PrimitiveType.LineLoop;
            back(primitiveType);  //rosado
            left(primitiveType);   //rojo
            right(primitiveType);  //amarillo
            front(primitiveType);  //verde
            bottom(primitiveType); //azul
        }

        public void front(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(origen.x, origen.y + punto1, origen.z + profundidad);
            GL.Vertex3(origen.x + ancho, origen.y , origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y , origen.z + profundidad);
            GL.End();
        }

        public void back(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(1, 0.2, 1);//rosado
            GL.Vertex3(origen.x, origen.y + punto1, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y, origen.z - profundidad);
            GL.Vertex3(origen.x - ancho, origen.y, origen.z - profundidad);
            GL.End();
        }

        public void left(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(1, 0.0, 0.0);//rojo
            GL.Vertex3(origen.x  , origen.y + punto1, origen.z - profundidad);//1
            GL.Vertex3(origen.x , origen.y + punto1, origen.z + profundidad);//2
            GL.Vertex3(origen.x - ancho, origen.y , origen.z + profundidad);//3
            GL.Vertex3(origen.x - ancho, origen.y , origen.z - profundidad);//4
            GL.End();
        }

        public void right(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(origen.x , origen.y + punto1, origen.z - profundidad);//1
            GL.Vertex3(origen.x, origen.y + punto1, origen.z + profundidad);//2
            GL.Vertex3(origen.x + ancho, origen.y, origen.z + profundidad);//3
            GL.Vertex3(origen.x + ancho, origen.y, origen.z - profundidad);//4
            GL.End();
        }
        public void bottom(PrimitiveType primitiveType)
        {   
            GL.Begin(primitiveType);
            GL.Color3(0.0, 0.0, 1.0);//azul;
            GL.Vertex3(origen.x - ancho, origen.y, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y, origen.z - profundidad);
            GL.Vertex3(origen.x + ancho, origen.y, origen.z + profundidad);
            GL.Vertex3(origen.x - ancho, origen.y, origen.z + profundidad);
            GL.End();
        }

    
    }
}
