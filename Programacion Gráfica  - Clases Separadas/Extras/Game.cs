using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    public class Game : GameWindow
    {

        public Escenario Escena= new Escenario();
        public Objeto T =new Objeto();


        
        //-----------------------------------------------------------------------------------------------------------------
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            

            GL.ClearColor(Color4.Black);
            //CREAR LAS CARAS
            //BASE T
            Cara Cara1 = new Cara();
            Cara1.AgregarVertice("1", new Vertice(-2, 0, 0)); //FRONTAL
            Cara1.AgregarVertice("2", new Vertice(2, 0, 0));
            Cara1.AgregarVertice("3", new Vertice(2, 15, 0));
            Cara1.AgregarVertice("4", new Vertice(-2, 15, 0));

            Cara Cara2 = new Cara();
            Cara2.AgregarVertice("1", new Vertice(2, 15, 0));
            Cara2.AgregarVertice("2", new Vertice(2, 15, -5));//DERECHA
            Cara2.AgregarVertice("3", new Vertice(2, 0, -5));
            Cara2.AgregarVertice("4", new Vertice(2, 0, 0));

            Cara Cara3 = new Cara();
            Cara3.AgregarVertice("1", new Vertice(-2, 0, -5));
            Cara3.AgregarVertice("2", new Vertice(-2, 15, -5)); //ATRAS
            Cara3.AgregarVertice("3", new Vertice(2, 15, -5));
            Cara3.AgregarVertice("4", new Vertice(2, 0, -5));

            Cara Cara4 = new Cara();
            Cara4.AgregarVertice("1", new Vertice(-2, 15, 0));//IZQ
            Cara4.AgregarVertice("2", new Vertice(-2, 15, -5));
            Cara4.AgregarVertice("3", new Vertice(-2, 0, -5));
            Cara4.AgregarVertice("4", new Vertice(-2, 0, 0));

            Cara Cara5 = new Cara();
            Cara5.AgregarVertice("1", new Vertice(-2, 0, 0));//ABAJO
            Cara5.AgregarVertice("2", new Vertice(2, 0, 0));
            Cara5.AgregarVertice("3", new Vertice(2, 0, -5));
            Cara5.AgregarVertice("4", new Vertice(-2, 0, -5));

            // SUPERIOR T
            Cara Cara6 = new Cara();
            Cara6.AgregarVertice("1", new Vertice(-6, 15, 0)); //FRONTAL
            Cara6.AgregarVertice("2", new Vertice(6, 15, 0));
            Cara6.AgregarVertice("3", new Vertice(6, 19, 0));
            Cara6.AgregarVertice("4", new Vertice(-6, 19, 0));

            Cara Cara7 = new Cara();
            Cara7.AgregarVertice("1", new Vertice(6, 15, 0));
            Cara7.AgregarVertice("2", new Vertice(6, 15, -5));
            Cara7.AgregarVertice("3", new Vertice(6, 19, -5));
            Cara7.AgregarVertice("4", new Vertice(6, 19, 0));

            Cara Cara8 = new Cara();
            Cara8.AgregarVertice("1", new Vertice(-6, 15, -5));
            Cara8.AgregarVertice("2", new Vertice(6, 15, -5));
            Cara8.AgregarVertice("3", new Vertice(6, 19, -5));
            Cara8.AgregarVertice("4", new Vertice(-6, 19, -5));

            Cara Cara9 = new Cara();
            Cara9.AgregarVertice("1", new Vertice(-6, 15, 0));
            Cara9.AgregarVertice("2", new Vertice(-6, 15, -5));
            Cara9.AgregarVertice("3", new Vertice(-6, 19, -5));
            Cara9.AgregarVertice("4", new Vertice(-6, 19, 0));

            // AÑADIR LAS CARAS AL OBJETO "T"
            T.AgregarCara("Cara1", Cara1);
            T.AgregarCara("Cara2", Cara2);
            T.AgregarCara("Cara3", Cara3);
            T.AgregarCara("Cara4", Cara4);
            T.AgregarCara("Cara5", Cara5);
            T.AgregarCara("Cara6", Cara6);
            T.AgregarCara("Cara7", Cara7);
            T.AgregarCara("Cara8", Cara8);
            T.AgregarCara("Cara9", Cara9);

            //AÑADIR OBJETOS A LA ESCENA
            Escena.AddObjeto("T_Letter", T);


            base.OnLoad(e);     
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            GL.LoadIdentity();

            Vector3 cameraPosition = new Vector3(-10.0f, 20.0f, 40.0f); // Posición de la cámara
            Vector3 targetPosition = new Vector3(0.0f, 10.0f, 0.0f); // Punto de enfoque                                                         
            Vector3 upDirection = Vector3.UnitY; // Dirección hacia arriba (eje Y)

            Matrix4 view = Matrix4.LookAt(cameraPosition, targetPosition, upDirection);
            GL.LoadMatrix(ref view);

            // Dibujar la escena
            this.Escena.Dibujar();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            float aspectRatio = Width / (float)Height;
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 0.1f, 100.0f);
            GL.LoadMatrix(ref perspective);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            base.OnResize(e);
        }

       

    }
}
