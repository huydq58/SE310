    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE310
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush b1 = new SolidBrush(Color.Black);
            g.FillEllipse(b1, 40,40,80,80);
            
            HatchBrush b2 =new HatchBrush(HatchStyle.ZigZag,Color.Red);
            g.FillEllipse(b2, 80, 80, 80, 80);

            Rectangle rect = new Rectangle(0, 0, 100, 100);
            LinearGradientBrush b3 = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.Horizontal);
            g.FillEllipse(b3, 120, 120, 80, 80);

            Image img = Image.FromFile("E:\\CSharp\\SE310\\SE310\\bitmap.jpg");
            TextureBrush b4 = new TextureBrush(img);
            g.FillEllipse(b4, 160, 160, 80, 80);

        }
    }
}
