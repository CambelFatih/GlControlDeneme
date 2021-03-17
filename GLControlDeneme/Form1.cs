using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.IO.Ports;

namespace GLControlDeneme
{
    public partial class Form1 : Form
    {
        float x=0,y=0,z=0;
        public Form1()
        {
            InitializeComponent();
            serialPort1.BaudRate = 115200;
            timer1.Interval = 100;
            string[] portlar = SerialPort.GetPortNames();
            foreach (string portAdi in portlar)
            {
                comboBox1.Items.Add(portAdi);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.FromArgb(143, 212, 150));//();
            button2.Enabled = false;
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);//sonradan yazdık
        }
        private void silindir(float step , float topla , float radius,float dikey1,float dikey2)
        {
            float eski_step = 0.1f;
            GL.Begin(BeginMode.Quads);//Y EKSEN CIZIM DAİRENİN
            while (step <= 360)
            {
                if (step < 45)
                    GL.Color3(Color.FromArgb(255,0,0));
                else if (step < 90)
                    GL.Color3(Color.FromArgb(255, 255, 255));
                else if (step < 135)
                    GL.Color3(Color.FromArgb(255, 0, 0));
                else if (step < 180)
                    GL.Color3(Color.FromArgb(255, 255, 255));
                else if (step < 225)
                    GL.Color3(Color.FromArgb(255, 0, 0));
                else if (step < 270)
                    GL.Color3(Color.FromArgb(255, 255, 255));
                else if (step < 315)
                    GL.Color3(Color.FromArgb(255, 0, 0));
                else if (step < 360)
                    GL.Color3(Color.FromArgb(255, 255, 255));


                float ciz1_x = (float)(radius * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey1, ciz1_y);

                float ciz2_x = (float)(radius * Math.Cos((step + 2) * Math.PI / 180F));
                float ciz2_y = (float)(radius * Math.Sin((step + 2) * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey1, ciz2_y);

                GL.Vertex3(ciz1_x, dikey2, ciz1_y);
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);
                step += topla;
            }
            GL.End();
            GL.Begin(BeginMode.Lines);
            step = eski_step;
            topla = step;
            while (step <= 180)// UST KAPAK
            {
                if (step < 45)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 90)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 135)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 180)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 225)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 270)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 315)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 360)
                    GL.Color3(Color.FromArgb(250, 250, 200));


                float ciz1_x = (float)(radius * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey1, ciz1_y);

                float ciz2_x = (float)(radius * Math.Cos((step + 180) * Math.PI / 180F));
                float ciz2_y = (float)(radius * Math.Sin((step + 180) * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey1, ciz2_y);

                GL.Vertex3(ciz1_x, dikey1, ciz1_y);
                GL.Vertex3(ciz2_x, dikey1, ciz2_y);
                step += topla;
            }
            step = eski_step;
            topla = step;
            while (step <= 180)//ALT KAPAK
            {
                if (step < 45)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 90)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 135)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 180)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 225)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 270)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 315)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 360)
                    GL.Color3(Color.FromArgb(250, 250, 200));

                float ciz1_x = (float)(radius * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey2, ciz1_y);

                float ciz2_x = (float)(radius * Math.Cos((step + 180) * Math.PI / 180F));
                float ciz2_y = (float)(radius * Math.Sin((step + 180) * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);

                GL.Vertex3(ciz1_x, dikey2, ciz1_y);
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);
                step += topla;
            }
            GL.End();
        }
        private void koni(float step, float topla, float radius1,float radius2 ,float dikey1, float dikey2)
        {
            float eski_step = 0.1f;
            GL.Begin(BeginMode.Lines);//Y EKSEN CIZIM DAİRENİN
            while (step <= 360)
            {
                if (step < 45)
                    GL.Color3(1.0, 1.0, 1.0);
                else if (step < 90)
                    GL.Color3(1.0, 0.0, 0.0);
                else if (step < 135)
                    GL.Color3(1.0, 1.0, 1.0);
                else if (step < 180)
                    GL.Color3(1.0, 0.0, 0.0);
                else if (step < 225)
                    GL.Color3(1.0, 1.0, 1.0);
                else if (step < 270)
                    GL.Color3(1.0, 0.0, 0.0);
                else if (step < 315)
                    GL.Color3(1.0, 1.0, 1.0);
                else if (step < 360)
                    GL.Color3(1.0, 0.0, 0.0);


                float ciz1_x = (float)(radius1 * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius1 * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey1, ciz1_y);

                float ciz2_x = (float)(radius2 * Math.Cos(step  * Math.PI / 180F));
                float ciz2_y = (float)(radius2 * Math.Sin(step  * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);
                step += topla;
            }
            GL.End();
            
            GL.Begin(BeginMode.Lines);
            step = eski_step;
            topla = step;
            while (step <= 180)// UST KAPAK
            {
                if (step < 45)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 90)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 135)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 180)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 225)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 270)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 315)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 360)
                    GL.Color3(Color.FromArgb(250, 250, 200));


                float ciz1_x = (float)(radius2 * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius2 * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey2, ciz1_y);

                float ciz2_x = (float)(radius2 * Math.Cos((step + 180) * Math.PI / 180F));
                float ciz2_y = (float)(radius2 * Math.Sin((step + 180) * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);

                GL.Vertex3(ciz1_x, dikey2, ciz1_y);
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);
                step += topla;
            }
            step = eski_step;
            topla = step;
            GL.End();
        }
        private void Pervane(float yukseklik,float uzunluk,float kalinlik,float egiklik)
        {
            float radius=10, angle=45.0f;
            GL.Begin(BeginMode.Quads);
          
            GL.Color3(Color.Red);
            GL.Vertex3(uzunluk, yukseklik, kalinlik);
            GL.Vertex3(uzunluk, yukseklik+ egiklik, -kalinlik);
            GL.Vertex3(0.0, yukseklik+ egiklik, -kalinlik);
            GL.Vertex3(0.0, yukseklik, kalinlik);

            GL.Color3(Color.Red);
            GL.Vertex3(-uzunluk, yukseklik+ egiklik, kalinlik);
            GL.Vertex3(-uzunluk, yukseklik, -kalinlik);
            GL.Vertex3( 0.0, yukseklik , -kalinlik);
            GL.Vertex3( 0.0, yukseklik+ egiklik, kalinlik);

            GL.Color3(Color.White);
            GL.Vertex3(kalinlik, yukseklik, -uzunluk);
            GL.Vertex3(-kalinlik, yukseklik + egiklik, -uzunluk);
            GL.Vertex3(-kalinlik, yukseklik + egiklik, 0.0);//+
            GL.Vertex3(kalinlik, yukseklik, 0.0);//-

            GL.Color3(Color.White);
            GL.Vertex3(kalinlik, yukseklik+ egiklik, +uzunluk);
            GL.Vertex3(-kalinlik, yukseklik , +uzunluk);
            GL.Vertex3(-kalinlik, yukseklik , 0.0);
            GL.Vertex3(kalinlik, yukseklik+ egiklik, 0.0);

            /*
            float ciz1_x = (float)(radius * Math.Cos(angle * Math.PI / 180F));
            float ciz1_z = (float)(radius * Math.Sin(angle * Math.PI / 180F));
            GL.Color3(Color.Black);
            GL.Vertex3(ciz1_x-0.5, 6.0, ciz1_z+ 0.5);
            GL.Vertex3(ciz1_x+ 0.5, 5.0, ciz1_z-0.5);
            GL.Vertex3(0.5, 5.0, -0.5);
            GL.Vertex3(-0.5, 6.0, 0.5);*/
            GL.End();

        }
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            float step = 1.0f;
            float topla = step;
            float radius = 5.0f;
            float dikey1 = radius,dikey2=-radius;
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(1.04f,4/3,1, 10000);
            Matrix4 lookat = Matrix4.LookAt(25, 0, 0, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.LoadMatrix(ref lookat);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Rotate(x, 1.0, 0.0, 0.0);//ÖNEMLİ
            GL.Rotate(z, 0.0, 1.0, 0.0);
            GL.Rotate(y, 0.0, 0.0, 1.0);

            silindir(step,topla,radius,3,-5);
            silindir(0.01f, topla, 0.5f, 9, 9.7f);
            silindir(0.01f, topla, 0.1f, 5, dikey1 + 5);
            koni(0.01f, 0.01f, radius, 3.0f, 3, 5);
            koni(0.01f, 0.01f, radius ,2.0f, -5.0f, -10.0f);
            Pervane(9.0f,11.0f,0.2f,0.5f);

            GL.Begin(BeginMode.Lines);

            GL.Color3(Color.FromArgb(250,0,0));
            GL.Vertex3(-30.0, 0.0, 0.0);
            GL.Vertex3(30.0, 0.0, 0.0);
            
            
            GL.Color3(Color.FromArgb(0,0,0));
            GL.Vertex3(0.0, 30.0, 0.0);
            GL.Vertex3(0.0, -30.0, 0.0);

            GL.Color3(Color.FromArgb(0, 0, 250));
            GL.Vertex3(0.0, 0.0, 30.0);
            GL.Vertex3(0.0, 0.0, -30.0);

            GL.End();
            //GraphicsContext.CurrentContext.VSync = true;
            glControl1.SwapBuffers();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
        
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            glControl1.Invalidate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            glControl1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string sonuc = serialPort1.ReadLine();
            string[] paket = sonuc.Split('*');
            

            try
            {
                string[] dn = paket[0].Split('.');
                string[] dn2 = paket[1].Split('.');
                string[] dn3 = paket[2].Split('.');


                x = Convert.ToInt16(dn[0]);  
                y = Convert.ToInt16(dn2[0]);  
                z = Convert.ToInt16(dn3[0]); 
                glControl1.Invalidate();

                label1.Text = dn[0];
                label2.Text = dn2[0];
                label3.Text = dn3[0];
            }
            catch
            {

            }
            
            


            //serialPort1.DiscardInBuffer();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            x = 100;
            y = 20;
            z = 50;
            glControl1.Invalidate();
            timerX.Start();
        }

        private void btnX_KeyDown(object sender, KeyEventArgs e)
        {
            timerX.Start();
        }

        private void btnX_KeyUp(object sender, KeyEventArgs e)
        {
           // timerX.Stop();
        }

        private void timerX_Tick(object sender, EventArgs e)
        {
            if (x < 180)
                x += 1;
            else
                x = 0;
            label1.Text = x.ToString();
            glControl1.Invalidate();
        }

        private void btnY_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text;
                if (!serialPort1.IsOpen)
                {
                    timer1.Start();
                    serialPort1.Open();
                    MessageBox.Show("BAĞLANTI KURULDU");
                    button1.Enabled = false;
                    button2.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("BAĞLANTI KURULAMADI");
                button1.Enabled = true;
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.DiscardInBuffer();
            serialPort1.Close();
            timer1.Stop();
            button1.Enabled = true;
            button2.Enabled = false;
            MessageBox.Show("BAĞLANTI KESİLDİ");
        }
    }
}
