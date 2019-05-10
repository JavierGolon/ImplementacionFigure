using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

      

        public void rectangulolleno(String color,int pt1,int pt2,int pt3,int pt4)

        {
            System.Drawing.Color mycolor = System.Drawing.ColorTranslator.FromHtml(color);
            System.Drawing.SolidBrush my = new System.Drawing.SolidBrush(mycolor);
            System.Drawing.Graphics form;
            form = pictureBox1.CreateGraphics();
            form.FillRectangle(my, new Rectangle(pt1, pt2, pt3, pt4));
            my.Dispose();
            form.Dispose();


        }

        public void circulorelleno(String color, int x, int y, int diametro1, int diametro2)
        {
            System.Drawing.Color mycolor = System.Drawing.ColorTranslator.FromHtml(color);
            System.Drawing.SolidBrush my = new System.Drawing.SolidBrush(mycolor);
            System.Drawing.Graphics form;
            form = pictureBox1.CreateGraphics();
            form.FillEllipse(my, new RectangleF(x,y, diametro1, diametro2));
            
            my.Dispose();
            form.Dispose();
        }

        public void triangulorelleno(String color,int p1,int p1_1,int p2,int p2_2,int p3, int p3_2)
        {
            System.Drawing.Color mycolor = System.Drawing.ColorTranslator.FromHtml(color);
            Point[] pnt = new Point[3];
            pnt[0].X = p1;
            pnt[0].Y = p1_1;

            pnt[1].X = p2;
            pnt[1].Y = p2_2;

            pnt[2].X = p3;
            pnt[2].Y = p3_2;
            System.Drawing.SolidBrush my = new System.Drawing.SolidBrush(mycolor);
            System.Drawing.Graphics form;
            form = pictureBox1.CreateGraphics();
            form.FillPolygon(my, pnt);
                    
            my.Dispose();
            form.Dispose();
        }

        public void linea(String color,int x,int y,int width,int height,int thickness)
        {
            System.Drawing.Color mycolor = System.Drawing.ColorTranslator.FromHtml(color);
            Graphics papel;
            papel = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(mycolor);
            lapiz.Width = thickness;
            papel.DrawLine(lapiz, x, y, width, height);
            
        }

        public void triangulosinrelleno(String color, int p1, int p1_1, int p2, int p2_2, int p3, int p3_2,int thick)
        {
            System.Drawing.Color mycolor = System.Drawing.ColorTranslator.FromHtml(color);
            Point[] pnt = new Point[3];
            pnt[0].X = p1;
            pnt[0].Y = p1_1;

            pnt[1].X = p2;
            pnt[1].Y = p2_2;

            pnt[2].X = p3;
            pnt[2].Y = p3_2;
        
            Graphics papel;
            papel = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(mycolor);
            lapiz.Width = thick;
            papel.DrawPolygon(lapiz,pnt);

        }

        public void circulosinrelleno(String color,int p1,int p2, int p3, int p4 , int thick)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml(color);
            Graphics papel;
            papel = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(col);
            lapiz.Width = thick;
            papel.DrawEllipse(lapiz,p1,p2,p3,p4);
        }

        public void rectangulosinrelleno(String color, int p1,int p2, int p3, int p4, int thick)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml(color);
            Graphics papel;
            papel = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(col);
            lapiz.Width = 3;
            papel.DrawRectangle(lapiz, p1,p2,p3,p4);
        }

        public void BufferDeImagenes()
        {
            List<Figure> asdf = new List<Figure>(); // NO CREAR NUEVA SINO LLAMAR DE LA CLASE DONDE ESTE

            foreach (var item in asdf)
            {



                String nombre = item.Tipofigura;// obtener de la pila
                switch (nombre)
                {
                    case "triangle":
                        string solido = item.Solid1; // obtener la propiead solid de la tabla
                        switch (solido)
                        {
                            case "true":
                                // primer valor es el color

                                triangulorelleno(item.Color,item.Pt1,item.Pt2,item.Pt3,item.Pt4, item.Pt5, item.Pt6); // mandar los valores y convertirlos a int
                                break;

                            case "false":
                                // primer valor es el color
                                triangulosinrelleno(item.Color, item.Pt1, item.Pt2, item.Pt3, item.Pt4, item.Pt5, item.Pt6,item.Thickness); // mandar valores
                                                                              // el ultimo valor en sin relleno es el grosor
                                break;
                        }
                        break;
                    case "rectangle":
                        string solido2 = item.Solid1; // obtener la propiead solid de la tabla
                        switch (solido2)
                        {
                            case "true":
                                // primer valor es el color
                                rectangulolleno(item.Color, item.Pt1, item.Pt2, item.Pt3, item.Pt4);
                                break;
                            case "false":
                                // primer valor es el color
                                rectangulosinrelleno(item.Color, item.Pt1, item.Pt2, item.Pt3, item.Pt4, item.Thickness); // ultimo valor es el grosor
                                break;
                        }
                        break;
                    case "circle":
                        string solido3 = item.Solid1; // obtener la propiead solid de la tabla
                        switch (solido3)
                        {
                            case "true":
                                // primer valor es el color
                                circulorelleno(item.Color, item.Pt1, item.Pt2, item.Pt3, item.Pt4);
                                break;
                            case "false":
                                // primer valor es el color
                                circulosinrelleno(item.Color, item.Pt1, item.Pt2, item.Pt3, item.Pt4, item.Thickness); // ultimo valor es el grososor
                                break;
                        }
                        break;
                    case "line":
                        linea(item.Color, item.Pt1, item.Pt2, item.Pt3, item.Pt4, item.Thickness); // ultimo valor es el grosor
                                                  // primer valor es el color

                        break;

                }


            }
        }
    }
}
