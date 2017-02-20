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
        Bitmap buffer;
        Graphics bufferg;
        Thread t = new Thread(new ThreadStart(szal));
        t.Start();
        
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
                    if (Primszamok.PrimeSearcher.primszamlalo(x + y * w) == true)
                        lock (buffer)
                            buffer.SetPixel(x, y, Color.Black);
        }
        }
}
