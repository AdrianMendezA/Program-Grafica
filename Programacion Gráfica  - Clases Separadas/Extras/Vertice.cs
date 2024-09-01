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
    public class Vertice
    {
        private double X1;
        private double Y1;
        private double Z1;


        public Vertice()
        {
            X1 = 0;
            Y1 = 0;
            Z1 = 0;
        }

        public Vertice(int X, int Y)
        {
            X1 = X;
            Y1 = Y;
            Z1 = 0;
        }

        public Vertice(int X, int Y, int Z)
        {
            X1 = X;
            Y1 = Y;
            Z1 = Z;
        }

        public double X
        {
            get { return X1; }
            set { X1 = value; }
        }

        public double Y
        {
            get { return Y1; }
            set { Y1 = value; }
        }

        public double Z
        {
            get { return Z1; }
            set { Z1 = value; }
        }

        public double[] ObtenerArreglo()
        {
            return new double[] { X, Y, Z };
        }


    }
}
