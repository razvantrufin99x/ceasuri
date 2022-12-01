using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ceasuri
{
    public partial class Form1 : Form
    {
        Graphics G;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            G = this.CreateGraphics();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            //Bucuresti
            ceas c1 = new ceas(170, 170, 150, DateTime.Now);
            c1.desenez(G);
            //Londra
            ceas c2 = new ceas(520, 170, 150, DateTime.Now.AddHours(-2));
            c2.desenez(G);
            //Seattle
            ceas c3 = new ceas(870, 170, 150, DateTime.Now.AddHours(-10));
            c3.desenez(G);
        }
    }
}
