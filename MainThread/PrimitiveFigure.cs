using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std
{
    struct ListsFromY
    {
        public int Y;
        public List<int> Lpl;// Список левых точек
        public List<int> Lpr;// Список правых точек
    }

    // Класс, представляющий простую фигуру на основе массива точек
    class PrimitiveFigure : Interface_Figure
    {

        // Поля класса
        private List<PointF> pointsFigure;// Массив точек фигуры
        private double[,] W;// Матрица преобразования
        private List<ListsFromY> listsFigure;// Список списков точек по Y
        Graphics g;// Графический объект
        Pen pen;// Ручка для отрисовки
        PointF centerFigure;// Центр фигуры

        // Конструктор для флага
        public PrimitiveFigure(Point center, int size_flag, Graphics g, Pen pen)
        {
            // Инициализация полей
            this.g = g;// Присваивание объекта Graphics для рисования
            this.pen = new Pen(pen.Brush);// Создание нового объекта Pen для сохранения параметров ручки
            W = new double[3, 3] 
            { 
                {1, 0, 0}, 
                {0, 1, 0}, 
                {0, 0, 1} 
            };// Инициализация матрицы преобразования

            pointsFigure = new List<PointF>();// Создание списка точек фигуры
            centerFigure = center;// Установка центра фигуры

            // Добавление точек фигуры
            //Деление позволяет сместить точку вправо от центра фигуры на половину размера флага.
            pointsFigure.Add(new Point(center.X, center.Y));// Центр флага
            pointsFigure.Add(new Point(center.X + size_flag * 3 / 2, center.Y + size_flag));// Верхняя правая часть флага
            pointsFigure.Add(new Point(center.X - 2 * size_flag, center.Y + size_flag));// Верхняя левая часть флага
            pointsFigure.Add(new Point(center.X - 2 * size_flag, center.Y - size_flag));// Нижняя левая часть флага
            pointsFigure.Add(new Point(center.X + size_flag * 3 / 2, center.Y - size_flag));// Нижняя правая часть флага

            setListPoints();// Формирование списка точек по Y для фигуры
        }

        // Конструктор для создания фигуры в виде параллелограмма
        public PrimitiveFigure(Point center, int width, int height, Graphics g, Pen pen)
        {
            // Инициализация полей
            this.g = g;// Присваивание объекта Graphics для рисования
            this.pen = new Pen(pen.Brush);// Создание нового объекта Pen для сохранения параметров ручки
            // Инициализация матрицы преобразования
            W = new double[3, 3]
            {
                {1, 0, 0},
                {0, 1, 0},
                {0, 0, 1}
            };

            pointsFigure = new List<PointF>();// Создание списка точек фигуры
            centerFigure = center;// Установка центра фигуры
            // Добавление точек фигуры 
            pointsFigure.Add(new Point(center.X + width , center.Y - height));// Верхний правый угол параллелограмма
            pointsFigure.Add(new Point(center.X + width + width/2 , center.Y + height));// Нижний правый угол параллелограмма
            pointsFigure.Add(new Point(center.X - width + width/2 , center.Y + height));// Нижний левый угол параллелограмма
            pointsFigure.Add(new Point(center.X - width, center.Y - height));// Верхний левый угол параллелограмма

            setListPoints();// Формирование списка точек по Y для фигуры
        }

        // Метод для вычисления центра фигуры на основе списка точек
        public PointF find_centre(List<PointF> list_points)
        {
            PointF centre = new PointF();// Создание объекта PointF для центра фигуры
            float xmax = list_points[0].X;// Инициализация переменной для максимального значения по X
            float xmin = list_points[0].X;
            float ymax = list_points[0].Y;// Инициализация переменной для максимального значения по Y
            float ymin = list_points[0].Y;

            // Цикл для определения крайних значений по X и Y среди переданных точек
            for (int i = 1; i < list_points.Count; i++)
            {
                if (xmax <= list_points[i].X)
                    // Обновление максимального значения по X, если текущее значение больше
                    xmax = list_points[i].X;

                if (ymax <= list_points[i].Y)
                    // Обновление максимального значения по Y, если текущее значение больше
                    ymax = list_points[i].Y;

                if (xmin >= list_points[i].X)
                    // Обновление минимального значения по X, если текущее значение меньше
                    xmin = list_points[i].X;

                if (ymin >= list_points[i].Y)
                    // Обновление минимального значения по Y, если текущее значение меньше
                    ymin = list_points[i].Y;
            }
            // Вычисление координат центра фигуры по X и Y
            centre.X = (xmax - xmin) / 2 + xmin;// Вычисление координаты X центра по крайним значениям X
            centre.Y = (ymax - ymin) / 2 + ymin;// Вычисление координаты Y центра по крайним значениям Y
            return centre;// Возвращение вычисленного центра фигуры
        }

        // Метод для определения центра фигуры
        public Point getCenter()
        {
            return new Point((int)(centerFigure.X * W[0, 0] + centerFigure.Y * W[1, 0] + W[2, 0]), (int)(centerFigure.X * W[0, 1] + centerFigure.Y * W[1, 1] + W[2, 1])); ;
        }

        // Метод для отрисовки фигуры на графическом объекте с использованием текущих параметров
        public void DrawFigure()
        {
            // Заполнение полигона в графическом объекте, используя координаты точек фигуры после преобразования
            g.FillPolygon(pen.Brush, outMonitor());
        }

        // Метод, возвращающий преобразованный массив точек фигуры для вывода на экран
        public Point[] outMonitor()
        {
            Point[] list = new Point[pointsFigure.Count];// Создание массива точек для фигуры
            // Проход по всем точкам фигуры и применение текущей матрицы преобразования к координатам каждой точки
            for (int i = 0; i < pointsFigure.Count; i++)
            {
                // Присвоение новых координат преобразованной точке массива
                list[i] = new Point((int)(pointsFigure[i].X * W[0, 0] + pointsFigure[i].Y * W[1, 0] + W[2, 0]), (int)(pointsFigure[i].X * W[0, 1] + pointsFigure[i].Y * W[1, 1] + W[2, 1]));
            }
            setListPoints();// Обновление списка точек по Y для фигуры после преобразования
            return list;// Преобразованный массив точек фигуры
        }


        // Получение массива левых точек по заданной координате Y
        public List<int> getLpL(int Y)
        {
            for (int i = 0; i < listsFigure.Count; i++)
            {
                if (listsFigure[i].Y == Y)
                {
                    // Возвращение массива левых точек, если найдено совпадение по координате Y
                    return listsFigure[i].Lpl;
                }
            }
            // Возвращение пустого списка, если не найдено совпадение по координате Y
            return new List<int>();
        }

        // Получение массива правых точек по заданной координате Y
        public List<int> getLpR(int Y)
        {
            for (int i = 0; i < listsFigure.Count; i++)
            {
                if (listsFigure[i].Y == Y)
                {
                    // Возвращение массива правых точек, если найдено совпадение по координате Y
                    return listsFigure[i].Lpr;
                }
            }
            // Возвращение пустого списка, если не найдено совпадение по координате Y
            return new List<int>();
        }

        // Получение максимальной координаты Y фигуры после преобразования
        public int getMaxY()
        {
            // Инициализация начальной максимальной координаты Y
            int max = (int)(pointsFigure[0].Y * W[1, 1] + W[2, 1] + pointsFigure[0].X * W[0, 1]);
            // Поиск максимальной координаты Y после преобразования для каждой точки фигуры
            for (int i = 1; i < pointsFigure.Count; i++)
            {
                // Обновление максимальной координаты Y, если текущая координата больше
                if (max < (int)(pointsFigure[i].Y * W[1, 1] + W[2, 1] + pointsFigure[i].X * W[0, 1]))
                {
                    max = (int)(pointsFigure[i].Y * W[1, 1] + W[2, 1] + pointsFigure[i].X * W[0, 1]);
                }
            }
            return max;// Максимальная координата Y фигуры после преобразования
        }

        //Получение минимальной координаты Y фигуры после преобразования
        public int getMinY()
        {
            // Инициализация начальной минимальной координаты Y
            int min = (int)(pointsFigure[0].Y * W[1, 1] + W[2, 1] + pointsFigure[0].X * W[0, 1]);
            // Поиск минимальной координаты Y после преобразования для каждой точки фигуры
            for (int i = 1; i < pointsFigure.Count; i++)
            {
                // Обновление минимальной координаты Y, если текущая координата меньше
                if (min > (int)(pointsFigure[i].Y * W[1, 1] + W[2, 1] + pointsFigure[i].X * W[0, 1]))
                {
                    min = (int)(pointsFigure[i].Y * W[1, 1] + W[2, 1] + pointsFigure[i].X * W[0, 1]);
                }
            }
            return min;// Минимальная координата Y фигуры после преобразования
        }

        //Проверка принадлежности точки фигуре после преобразования
        public bool pointInside(Point p)
        {
            // Проверка, находится ли заданная точка в пределах Y-координат фигуры после преобразования
            if (p.Y > getMinY() && p.Y < getMaxY())
            {
                int num = 0;
                // Поиск списка точек по заданной координате Y в списке списков точек фигуры
                for (int i = 0; i < listsFigure.Count; i++)
                {
                    if (listsFigure[i].Y == p.Y)
                    {
                        // Сохранение индекса списка точек для данной Y-координаты
                        num = i;
                    }
                }
                // Проверка, попадает ли точка в какой-либо из интервалов на этой Y-координате
                for (int i = 0; i < listsFigure[num].Lpl.Count; i++)
                {
                    if (p.X > listsFigure[num].Lpl[i] && p.X < listsFigure[num].Lpr[i])
                    {
                        // Точка находится внутри фигуры после преобразования
                        return true;
                    }
                }
            }
            return false;// Точка не находится внутри фигуры после преобразования
        }

        // Метод для применения непрерывной операции к фигуре
        public void runOperation(double[,] center, double[,] operation)
        {
            W = MulMatrix(W, center);// Умножение текущей матрицы на матрицу преобразования центра
            W = MulMatrix(W, operation);// Умножение на матрицу операции
            center[2, 0] = -center[2, 0];// Инвертирование элементов матрицы преобразования центра
            center[2, 1] = -center[2, 1];
            W = MulMatrix(W, center);// Повторное умножение на инвертированную матрицу центра для компенсации
            center[2, 0] = -center[2, 0];// Возвращение элементов матрицы центра к исходным значениям
            center[2, 1] = -center[2, 1];
            setListPoints();// Обновление списка точек фигуры после операции
        }


        //Заполняет списки фигуры
        private void setListPoints()
        {
            // Создание временного списка списков точек
            List<ListsFromY> tmpList = new List<ListsFromY>();
            // Получение минимальной координаты Y после преобразования
            int Y = getMinY();
            int maxY = getMaxY();
            // Проход по Y-координатам и формирование списков точек фигуры для каждой Y-координаты
            for (; Y < maxY; Y++)
            {
                int k = 0;
                List<int> xl = new List<int>();// Создание списка левых точек для текущей Y-координаты
                List<int> xr = new List<int>();// Создание списка правых точек для текущей Y-координаты
                List<int> Xall = new List<int>();// Создание списка всех X-координат для текущей Y-координаты
                // Обход всех точек фигуры и определение интервалов X-координат для текущей Y-координаты
                for (int i = 0; i < pointsFigure.Count; i++)
                {
                    if (i < pointsFigure.Count - 1)
                    {
                        k = i + 1;
                    }
                    else
                    {
                        k = 0;
                    }
                    // Вычисление преобразованных координат X и Y для текущей и следующей точек
                    int piy = (int)(pointsFigure[i].Y * W[1, 1] + W[2, 1] + pointsFigure[i].X * W[0, 1]);
                    int pky = (int)(pointsFigure[k].Y * W[1, 1] + W[2, 1] + pointsFigure[k].X * W[0, 1]);
                    int pix = (int)(pointsFigure[i].X * W[0, 0] + pointsFigure[i].Y * W[1, 0] + W[2, 0]);
                    int pkx = (int)(pointsFigure[k].X * W[0, 0] + pointsFigure[k].Y * W[1, 0] + W[2, 0]);

                    // Проверка и добавление X-координат в список для текущей Y-координаты
                    if (((piy < Y) && (pky >= Y)) || ((piy >= Y) && (pky < Y)))
                    {
                        double x = (((double)(Y - piy) / (pky - piy)) * (pkx - pix)) + pix;
                        Xall.Add((int)x);
                    }


                }
                // Сортировка списка X-координат и формирование списков левых и правых точек для текущей Y-координаты
                SortList(Xall);
                for (int a = 0; a < Xall.Count - 1; a += 2)
                {
                    xl.Add(Xall[a]);
                    xr.Add(Xall[a + 1]);
                }

                SortList(xl);
                SortList(xr);
                // Создание объекта списка точек для текущей Y-координаты и добавление его во временный список
                ListsFromY l = new ListsFromY();
                l.Y = Y;
                l.Lpl = xl;
                l.Lpr = xr;

                tmpList.Add(l);
            }
            listsFigure = new List<ListsFromY>(tmpList);// Обновление списка списков точек фигуры
        }

        // Метод для сортировки списка целых чисел по возрастанию
        private void SortList(List<int> Lp)
        {
            for (int h = 0; h < Lp.Count - 1; h++)
            {
                for (int j = h + 1; j < Lp.Count; j++)
                {
                    // Внутренний цикл перебирает элементы от следующего индекса после 'h' до последнего индекса в списке
                    if (Lp[j] < Lp[h])
                    {
                        // Если последующий элемент меньше текущего, выполняется обмен значениями
                        int temp = Lp[h];// Обмен значений, если текущий элемент меньше предыдущего
                        Lp[h] = Lp[j];
                        Lp[j] = temp;
                    }
                }
            }
        }

        // Метод для умножения двух матриц
        private double[,] MulMatrix(double[,] W, double[,] P)
        {
            // Создание новой матрицы для хранения результата умножения
            double[,] newW = new double[3, 3];
            // Циклы для умножения элементов матрицы W на элементы матрицы P
            // Цикл перебирает индексы строк (i) от 0 до количества строк в матрице W минус 1
            for (int i = 0; i < W.GetLength(1); i++)
            {
                // Внутренний цикл для умножения элементов матриц
                for (int j = 0; j < P.GetLength(0); j++)
                {
                    // Второй внутренний цикл для умножения элементов итоговой матрицы
                    // Цикл перебирает индексы столбцов в матрице W и строк в матрице P
                    for (int k = 0; k < W.GetLength(1); k++)
                    {
                        // Вычисление нового значения элемента матрицы по правилу перемножения матриц
                        newW[i, j] += W[i, k] * P[k, j];
                    }
                }
            }
            return newW;// Возвращение результата умножения матриц
        }

        //Является ли объект фигурой
        public bool isFigure()
        {
            return true;
        }
    }
}

