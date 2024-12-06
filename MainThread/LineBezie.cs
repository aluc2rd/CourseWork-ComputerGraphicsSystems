using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Std
{
    class LineBezie
    {
        //данные для построения кривой Безье
        List<Point> Lp = new List<Point>();
        double[] factorials = new double[50];
        Graphics g;
        Pen p = new Pen(Color.Brown, 2);
        public LineBezie(Graphics g, double[] factorials, List<Point> Lp)
        {
            this.Lp = Lp;
            this.g = g;
            this.factorials = factorials;
        }

        public List<Point> getLp()
        {
            return Lp;
        }

        //метод рисования кривой Безье
        public void ProcDrawBezie()
        {

            double nFact = factorials[Lp.Count-1];
            double dt = 0.01;
            double t = dt;
            int xPred = (int)Lp[0].X;
            int yPred = (int)Lp[0].Y;
            while (t < 1 + dt / 2)
            {
                double xt = 0;
                double yt = 0;
                int i = 0;
                while (i <= Lp.Count - 1)
                {
                    double J = Math.Pow(t, i) * Math.Pow((1 - t), Lp.Count - 1 - i) * nFact / (factorials[i] * factorials[Lp.Count - 1 - i]);
                    xt = xt + Lp[i].X * J;
                    yt = yt + Lp[i].Y * J;
                    i++;
                }
                g.DrawLine(p, new Point(xPred, yPred), new Point((int)xt, (int)yt));
                t += dt;
                xPred = (int)xt;
                yPred = (int)yt;
            }
        }
    }
}
