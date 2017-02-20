using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Primszamok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int>primszamok = new List<int>();
        Bitmap buffer;
        Graphics bufferg;
        Thread t;

        void szal()
        {
            bufferg.Clear(Color.White);

            int h, w;

            lock (buffer)
            {
                h = buffer.Height;
                w = buffer.Width;
            }

            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                    if (Primszamok.PrimeSearcher.primszamlalo(x + (y * w) + 1) == true)
                    {
                        primszamok.Add((int)(x + (y * w) + 1));
                        lock (buffer)
                            buffer.SetPixel(x, y, Color.Black);
                    }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            buffer = new Bitmap(panel1.Width, panel1.Height);
            lock (buffer)
                bufferg = Graphics.FromImage(buffer);
            t = new Thread(new ThreadStart(szal));
            t.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (buffer == null)
                return;

            using (Graphics g = panel1.CreateGraphics())
            {
                lock (buffer)
                    g.DrawImage(buffer, 0, 0);
            }
        }
    }
}

