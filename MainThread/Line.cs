using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std
{
    // Класс прямой, реализующий интерфейс Interface_Figure
    public class Line : Interface_Figure
    {
        // Объекты для рисования
        public Graphics g;// Графический объект
        public Pen DrawPen;// Карандаш для рисования линии
        private double[,] W;// Матрица преобразования

        // Данные для построения прямой
        Point P1, P2;  // Точки начала и конца прямой
        Boolean FirstPoint = true;   // Флаг для первой точки
        uint w = 1;   // Толщина линии по умолчанию

        // Конструктор класса Line
        public Line(Graphics g, Pen DrawPen, Point p1, Point p2)
        {
            this.g = g;
            this.DrawPen = DrawPen;
            this.P1 = p1;
            this.P2 = p2;

            // Инициализация матрицы преобразования
            W = new double[3, 3]
            {
                {1, 0, 0},
                {0, 1, 0},
                {0, 0, 1}
            };

        }

        // Метод для визуализации отрезка
        public void DrawFigure()
        {
            //Алгоритм построения прямой
            int x, y, dx, dy, Sx = 0, Sy = 0;
            int F = 0, Fx = 0, dFx = 0, Fy = 0, dFy = 0;

            // Вычисление разницы по координатам X и Y между точками
            dx = P2.X - P1.X;
            dy = P2.Y - P1.Y;

            // Определение направления изменения координаты X и Y
            Sx = Math.Sign(dx);
            Sy = Math.Sign(dy);

            // Вычисление начальных значений для алгоритма Брезенхэма
            if (Sx > 0) dFx = dy; else dFx = -dy;
            if (Sy > 0) dFy = dx; else dFy = -dx;
            x = P1.X;
            y = P1.Y;
            F = 0;

            // Выбор метода для отрисовки в зависимости от угла наклона отрезка
            if (Math.Abs(dx) >= Math.Abs(dy)) // Если угол наклона <= 45 градусов 
            {
                do
                {
                    // Отрисовка пикселя с координатами x, y
                    Draw(DrawPen, x, y);
                    // Переход к следующему пикселю на отрезке
                    if (x == P2.X)
                        break;
                    Fx = F + dFx;
                    F = Fx - dFy;
                    x = x + Sx;
                    if (Math.Abs(Fx) < Math.Abs(F)) F = Fx;
                    else y = y + Sy;
                } while (true);

            }
            else // Если угол наклона > 45 градусов
            {
                do
                {
                    // Отрисовка пикселя с координатами x, y
                    Draw(DrawPen, x, y);
                    // Переход к следующему пикселю на отрезке
                    if (y == P2.Y)
                        break;
                    Fy = F + dFy;
                    F = Fy - dFx;
                    y = y + Sy;
                    if (Math.Abs(Fy) < Math.Abs(F)) F = Fy;
                    else x = x + Sx;
                } while (true);
            }
            // Сброс флага для первой точки после завершения отрисовки
            FirstPoint = true;
        }


        // Метод для вывода точки на графическом объекте g с указанными координатами x, y и толщиной w
        private void Draw(Pen Brush, int x, int y)
        {
            g.DrawRectangle(Brush, x, y, w, w);// Используется метод DrawRectangle для рисования квадрата
        }

        // Метод для получения текущей толщины линии
        public uint getW()
        {
            return w;// Возвращает текущее значение толщины линии
        }
        // Метод для установки нового значения толщины линии
        public void setW(uint w)
        {
            this.w = w;// Устанавливает новое значение толщины линии
        }

        // Метод для сброса значений толщины линии к значению по умолчанию
        public void reset()
        {
            FirstPoint = true;// Сбрасывает флаг первой точки
        }

        // Метод для проверки принадлежности точки p прямой, определенной точками P1 и P2
        public bool pointInside(Point p)
        {
            //Логика проверки принадлежности точки прямой
            float xmax = P1.X;
            float xmin = P1.X;
            float ymax = P1.Y;
            float ymin = P1.Y;
            // Определение границ прямоугольника, образованного точками P1 и P2
            if (xmax <= P2.X)
                xmax = P2.X;

            if (ymax <= P2.Y)
                ymax = P2.Y;

            if (xmin >= P2.X)
                xmin = P2.X;

            if (ymin >= P2.Y)
                ymin = P2.Y;
            // Проверка принадлежности точки к прямоугольнику, образованному прямой
            if ((p.Y <= ymax && p.Y >= ymin) && (p.X <= xmax && p.X >= xmin))
            {
                return true;// Точка принадлежит прямой
            }

            return false;// Точка не принадлежит прямой
        }

        // Метод для выполнения операции над прямой посредством матричного преобразования
        public void runOperation(double[,] center, double[,] operation)
        {
            // Создание векторов для точек P1 и P2
            double[] points1 = new double[3];
            points1[0] = P1.X;
            points1[1] = P1.Y;
            points1[2] = 1;

            double[] points2 = new double[3];
            points2[0] = P2.X;
            points2[1] = P2.Y;
            points2[2] = 1;

            // Преобразование точек прямой с использованием матриц center и operation
            points1 = MulMatrix(points1, center);
            points2 = MulMatrix(points2, center);
            points1 = MulMatrix(points1, operation);
            points2 = MulMatrix(points2, operation);

            // Инвертирование центра для возвращения прямой в исходное положение
            center[2, 0] = -center[2, 0];
            center[2, 1] = -center[2, 1];

            points1 = MulMatrix(points1, center);
            points2 = MulMatrix(points2, center);

            // Возврат центра в исходное положение
            center[2, 0] = -center[2, 0];
            center[2, 1] = -center[2, 1];

            // Обновление координат точек прямой после операции
            P1.X = Convert.ToInt32(points1[0]);
            P1.Y = Convert.ToInt32(points1[1]);

            P2.X = Convert.ToInt32(points2[0]);
            P2.Y = Convert.ToInt32(points2[1]);
        }

        // Метод для умножения вектора W на матрицу P
        private double[] MulMatrix(double[] W, double[,] P)
        {
            double[] newW = new double[3];
            // Цикл для умножения вектора на матрицу
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Умножение соответствующих элементов вектора на элементы матрицы и их суммирование
                    newW[i] += W[j] * P[j, i];
                }
            }
            return newW;// Возвращает новый вектор после умножения на матрицу
        }

        // Метод для определения центра прямой
        public Point getCenter()
        {
            Point centre = new Point();
            // Определение максимальных и минимальных значений X и Y для точек P1 и P2
            int xmax = P1.X;
            int xmin = P1.X;
            int ymax = P1.Y;
            int ymin = P1.Y;

            if (xmax <= P2.X)
                xmax = P2.X;

            if (ymax <= P2.Y)
                ymax = P2.Y;

            if (xmin >= P2.X)
                xmin = P2.X;

            if (ymin >= P2.Y)
                ymin = P2.Y;
            // Вычисление центра по формуле(среднее значение X, среднее значение Y)
            centre.X = (xmax - xmin) / 2 + xmin;
            centre.Y = (ymax - ymin) / 2 + ymin;
            return centre;// Возвращает координаты центра прямой
        }

        // Метод проверки на то, что это фигура
        public bool isFigure()
        {
            return false;// Прямая не является фигурой
        }

        // Методы для работы с координатами Y
        public int getMaxY() { return 0; }// Максимальное значение Y для прямой
        public int getMinY() { return 0; }// Минимальное значение Y для прямой

        public List<int> getLpL(int Y) { return null; }// Список для левой границы сканирующей линии
        public List<int> getLpR(int Y) { return null; }// Список для правой границы сканирующей линии
    };
}
