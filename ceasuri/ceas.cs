using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ceasuri
{
    class ceas
    {
        private int x, y,r,h,m,s;
        
        public int X { set { x = value; } get { return x; } }
        public int Y { set { y = value; } get { return y; } }
        public int R { set { r = value; } get { return r; } }
        public int H { set { h = value; } get { return h; } }
        public int M { set { m = value; } get { return m; } }
        public int S { set { s = value; } get { return s; } }

        public ceas() { x = y = h = r = m = s = 0; }
        public ceas(int x, int y, int r, int h, int m, int s)
        {
            X = x; Y = y; R = r; H = h; M = m; S = s;
        }
        public ceas(int x, int y, int r, DateTime d)
        {
            X = x; Y = y; R = r;
            H = d.Hour;
            M = d.Minute;
            S = d.Second;
        }

        public void desenez(Graphics G)
        {
            Pen p1 = new Pen(Color.Black, 1);//pt contur
            SolidBrush b1 = new SolidBrush(Color.Red);//pt ore
            Pen p2 = new Pen(Color.Blue,2);//pt minute
            Pen p3 = new Pen(Color.Black,1);//secundarul
            Pen p4 = new Pen(Color.Green, 2); //minutarul
            Pen p5 = new Pen(Color.Red, 3);//orarul

            G.DrawEllipse(p1, x - r, y - r, 2 * r, 2 * r);//conturul
            //desenez marcajele pt ore
            for (int i = 0; i <= 11; i++) //12 ore
            {
                float u = i * (float)Math.PI / 6; //2PI/12
                //desenez cerculet rosu
                G.FillEllipse(b1, x -5 + (float)(r * Math.Cos(u)), y -5 + (float)(r * Math.Sin(u)),10,10);
            }
            //desenez marcajele pt minute
            for (int i = 0; i <= 59; i++) //60 minute
            {
                float u = i * (float)Math.PI / 30; //2PI/60
                //desenez linie albastra
                G.DrawLine(p2, x  + (float)((r+2) * Math.Cos(u)), y  + (float)((r+2)  * Math.Sin(u)), x  + (float)((r - 2) * Math.Cos(u)), y  + (float)((r - 2) * Math.Sin(u)));
            }
            //secundarul
            int sec = S;
            float us = (sec - 15) * (float)Math.PI / 30;
            G.DrawLine(p3, x - (float)((r * 0.1) * Math.Cos(us)), y - (float)((r *0.1) * Math.Sin(us)), x + (float)((r-4) * Math.Cos(us)), y + (float)((r-4) * Math.Sin(us)));
            //minutarul
            int min = M;
            float um = (min - 15+ (float)sec/60) * (float)Math.PI / 30 ;
            G.DrawLine(p4, x - (float)((r * 0.1) * Math.Cos(um)), y - (float)((r * 0.1) * Math.Sin(um)), x + (float)((r - 8) * Math.Cos(um)), y + (float)((r - 8) * Math.Sin(um)));
            //orarul
            int ora = H;
            float uo = (ora - 3 + (float)min/60) * (float)Math.PI / 6 ;
            G.DrawLine(p5, x - (float)((r * 0.1) * Math.Cos(uo)), y - (float)((r * 0.1) * Math.Sin(uo)), x + (float)((r - 15) * Math.Cos(uo)), y + (float)((r - 15) * Math.Sin(uo)));

        }
    }
}
