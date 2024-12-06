using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Std
{
    //Код позволяет создать объект класса LineSplain, передать ему список точек и перо,
    //а затем использовать методы этого объекта для отрисовки кубического сплайна и
    //выполнения других операций с ним
    //Класс используется для отрисовки кубического сплайна на графическом объекте
    class LineSplain : Interface_Figure
    {
        // Список точек для построения кубического сплайна
        List<Point> Lp = new List<Point>();

        Graphics g;
        Pen pen;
        // Конструктор класса
        public LineSplain(Graphics g, List<Point> P, Pen pen)
        {
            this.pen = pen;// Устанавливает переданное перо для рисования сплайна
            PointF[] L = new PointF[4]; // Матрица вещественных коэффициентов
      
            Point Pv1 = P[0];// Инициализирует первый вектор касательной
            Point Pv2 = P[0];
            const double dt = 0.04;// Шаг при параметризации сплайна
            double t = 0;// Параметр t для сплайна
            double xt, yt;// Координаты x и y
            Point Ppred = P[0], Pt = P[0];// Предыдущая и текущая точки сплайна
            // Расчет касательных векторов
            Pv1.X = 4 * (P[1].X - P[0].X);
            Pv1.Y = 4 * (P[1].Y - P[0].Y);
            Pv2.X = 4 * (P[3].X - P[2].X);
            Pv2.Y = 4 * (P[3].Y - P[2].Y);
            // Расчет коэффициентов полинома для сплайна
            L[0].X = 2 * P[0].X - 2 * P[2].X + Pv1.X + Pv2.X; // Ax
            L[0].Y = 2 * P[0].Y - 2 * P[2].Y + Pv1.Y + Pv2.Y; // Ay
            L[1].X = -3 * P[0].X + 3 * P[2].X - 2 * Pv1.X - Pv2.X; // Bx
            L[1].Y = -3 * P[0].Y + 3 * P[2].Y - 2 * Pv1.Y - Pv2.Y; // By
            L[2].X = Pv1.X; // Cx
            L[2].Y = Pv1.Y; // Cy
            L[3].X = P[0].X; // Dx
            L[3].Y = P[0].Y; // Dy
             
           
            // Построение точек сплайна (алгоритм кубического сплайна) и добавление их в список точек Lp
            while (t < 1 + dt / 2)
            {
                // Расчет координат точек сплайна для текущего t
                xt = ((L[0].X * t + L[1].X) * t + L[2].X) * t + L[3].X;
                yt = ((L[0].Y * t + L[1].Y) * t + L[2].Y) * t + L[3].Y;
                Pt.X = (int)Math.Round(xt);// Округление координаты x
                Pt.Y = (int)Math.Round(yt);// Округление координаты y
                // Добавляет предыдущую точку в список точек сплайна
                Lp.Add(Ppred);
                // Добавляет текущую точку в список точек сплайна
                Lp.Add(Pt);

                Ppred = Pt;// Обновляет предыдущую точку
                t = t + dt;// Увеличивает параметр t
            }

            this.g = g;// Установка графического объекта
        }
        // Возвращает список точек кубического сплайна
        public List<Point> getLp()
        {
            return Lp;// Возвращает список точек сплайна
        }

        //Метод рисования кривой
        public void DrawFigure()
        {
            for (int i = 0; i < Lp.Count - 1; i++)
            {
                // Рисует отрезок между текущей точкой и следующей точкой сплайна
                g.DrawLine(pen, Lp[i], Lp[i + 1]);
            }
        }

        // Проверка, находится ли точка внутри фигуры
        public bool pointInside(Point p)
        {
            // Вычисление границ фигуры
            float xmax = Lp[0].X;
            float xmin = Lp[0].X;
            float ymax = Lp[0].Y;
            float ymin = Lp[0].Y;
            // Находит границы области, описываемой сплайном
            for (int i = 1; i < Lp.Count; i++)
            {
                if (xmax <= Lp[i].X)
                    xmax = Lp[i].X;

                if (ymax <= Lp[i].Y)
                    ymax = Lp[i].Y;

                if (xmin >= Lp[i].X)
                    xmin = Lp[i].X;

                if (ymin >= Lp[i].Y)
                    ymin = Lp[i].Y;
            }
            // Проверка координат точки в пределах границ фигуры
            if ((p.Y <= ymax && p.Y >= ymin) && (p.X <= xmax && p.X >= xmin))
            {
                return true;// Точка находится внутри области
            }

            return false;// Точка находится за пределами области
        }

        // Выполнение операции с матрицей центра и операцией
        public void runOperation(double[,] center, double[,] operation)
        {
            // Применение операции к точкам сплайна
            for (int i = 0; i < Lp.Count; i++)
            {
                // Преобразование точек с использованием матриц
                Point p = Lp[i];
                // Создание массива для хранения координат точки в виде трехмерного вектора
                double[] points = new double[3];
                points[0] = p.X;
                points[1] = p.Y;
                points[2] = 1;
                // Применение операции к точке сплайна через умножение матриц
                points = MulMatrix(points, center);
                points = MulMatrix(points, operation);
                // Инвертирование координаты Z для преобразования обратно в двумерное пространство
                center[2, 0] = -center[2, 0];
                center[2, 1] = -center[2, 1];
                // Обратное преобразование точки
                points = MulMatrix(points, center);
                // Возврат координат Z в исходное состояние
                center[2, 0] = -center[2, 0];
                center[2, 1] = -center[2, 1];
                // Преобразование координат точки обратно в целочисленные значения
                p.X = Convert.ToInt32(points[0]);
                p.Y = Convert.ToInt32(points[1]);
                // Обновление точки в списке точек сплайна
                Lp[i] = p;
            }
        }

        // Умножает вектор на матрицу
        private double[] MulMatrix(double[] W, double[,] P)
        {
            // Создает новый вектор для хранения результата
            double[] newW = new double[3];
            // Цикл для умножения вектора на матрицу
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Умножение и суммирование элементов для каждого элемента нового вектора
                    newW[i] += W[j] * P[j, i];
                }
            }
            return newW;// Возвращает результат умножения
        }
        // Возвращает центральную точку, описывающую область, охватывающую кубический сплайн
        public Point getCenter()
        {
            Point center = new Point();// Создает объект для хранения центральной точки
            int xmax = Lp[0].X;// Инициализирует переменную для максимальной координаты x
            int xmin = Lp[0].X;
            int ymax = Lp[0].Y;// Инициализирует переменную для максимальной координаты y
            int ymin = Lp[0].Y;
            // Находит границы области, охватывающей кубический сплайн
            for (int i = 1; i < Lp.Count; i++)
            {
                if (xmax <= Lp[i].X)
                    xmax = Lp[i].X;

                if (ymax <= Lp[i].Y)
                    ymax = Lp[i].Y;

                if (xmin >= Lp[i].X)
                    xmin = Lp[i].X;

                if (ymin >= Lp[i].Y)
                    ymin = Lp[i].Y;
            }
            // Вычисляет центральную точку области
            center.X = (xmax - xmin) / 2 + xmin;
            center.Y = (ymax - ymin) / 2 + ymin;

            return center;// Возвращает центральную точку
        }
        public bool isFigure()
        {
            return false;
        }
        // Возвращает максимальное значение координаты Y среди точек сплайна
        public int getMaxY() { return 0; }
        // Возвращает минимальное значение координаты Y среди точек сплайна
        public int getMinY() { return 0; }

        // Возвращает список точек слева от заданной координаты Y
        public List<int> getLpL(int Y) { return null; }
        // Возвращает список точек справа от заданной координаты Y
        public List<int> getLpR(int Y) { return null; }
    }
}
