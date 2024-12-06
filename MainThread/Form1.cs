using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Std
{
    public partial class Form1 : Form
    {
        byte typeOperation;
        //матрица центра преобразования
        double[,] centerArray = new double[3, 3];

        //Для двойной буферизации, на этот объект отрисовывается изображение, а затем оно пекреносится на экран
        Bitmap btmBack;

        //массив для выбора фигур ТМО
        Interface_Figure[] twoFigure = new Interface_Figure[2];

        //количество фигур в массиве
        int count = 0;

        //предыдущее положение мыши
        Point position;

        //выделение первой точки линии
        private bool firstPoint = true;

        Point point_line_begin;

        //выделенная фигура
        int numFigure;

        //Выделенная точка на панели рисования
        Point selectedCoordinate;

        //центр трансформации
        Point center;

        //Список фигур
        List<Interface_Figure> figures;
        Graphics g;

        //список точек для Кубического Сплайна
        List<Point> Lp = new List<Point>();

        Pen DrawPen = new Pen(Color.Black, 3);

        public Form1()
        {
            // Инициализация компонентов Windows Forms, созданных в дизайнере
            InitializeComponent();

            // Получение графического объекта для рисования на PictureBox
            g = pictureBox.CreateGraphics();

            // Создание объекта Bitmap для буферизации изображения перед
            // его отображением на экране
            btmBack = new Bitmap(pictureBox.Width, pictureBox.Height);

            // Создание графического объекта из Bitmap для рисования на нем
            g = Graphics.FromImage(btmBack);

            // Инициализация списка для хранения фигур
            figures = new List<Interface_Figure>();

            // Инициализация матрицы для преобразования центра
            centerArray = new double[3, 3]
            {
                {1, 0, 0},
                {0, 1, 0},
                {0, 0, 1},
            };
        }

        //Отрисовка всех обьектов
        public void DrawAll()
        {
            // Устанавливаем изображение в PictureBox для отображения на экране
            pictureBox.Image = btmBack;

            // Очищаем графический объект от предыдущих рисунков
            g.Clear(Color.White);

            // Отрисовываем все фигуры из списка figures
            for (int i = 0; i < figures.Count; i++)
            {
                figures[i].DrawFigure();
            }

            // Отрисовываем кубический сплайн (если есть точки в списке Lp)
            for (int j = 0; j < Lp.Count; j++)
            {
                // Рисуем точку
                g.DrawRectangle(DrawPen, Lp[j].X, Lp[j].Y, 1, 1);
                // Если не первая точка, соединяем ее с предыдущей линией
                if (j != 0)
                    g.DrawLine(new Pen(Color.Red, 1), Lp[j - 1], Lp[j]);
            }
            // Отрисовываем центр трансформации
            g.DrawEllipse(new Pen(Color.DarkRed,3), center.X, center.Y, 3, 3);

            // Обновляем PictureBox, чтобы отобразить изменения
            pictureBox.Refresh();
        }


        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Устанавливаем изображение в PictureBox для отображения на экране
            pictureBox.Image = btmBack;

            switch (typeOperation)
            {
                case 0: //сплайн
                    // Добавление точек для построения кубического сплайна
                    if (Lp.Count < 4)
                        Lp.Add(new Point(e.X, e.Y));
                    // При наборе 4 точек, создаем сплайн и добавляем его в список figures
                    if (Lp.Count == 4)
                    {
                        // Создаем сплайн по точкам из списка Lp и добавляем его в список figures
                        figures.Add(new LineSplain(g, Lp, new Pen(colorDialog1.Color, 2)));
                        // Очищаем список точек Lp для следующего сплайна
                        Lp = new List<Point>();
                    }
                    // Перерисовываем все
                    DrawAll();

                    break;
                case 1: //Фигура - флаг
                    try
                    {
                        // Добавляем новую фигуру (флаг) в список figures
                        figures.Add(new PrimitiveFigure(new Point(e.X, e.Y), Convert.ToInt32(numericUpDownSizeFlag.Value), g, DrawPen));
                        DrawAll();
                    }
                    catch
                    {
                        MessageBox.Show("Некорректно введены данные: размер флага");
                    }
                    break;

                case 2: //фигура - параллелограмм
                    try
                    {
                        // Добавляем новую фигуру (параллелограмм) в список figures
                        figures.Add(new PrimitiveFigure(new Point(e.X, e.Y), Convert.ToInt32(numericUpDownWidth.Value), Convert.ToInt32(numericUpDownNHeight.Value), g, DrawPen));
                        DrawAll();
                    }
                    catch
                    {
                        MessageBox.Show("Некорректно введены данные: ширина или высота параллелограмма");
                    }
                    break;

                case 3: //Выделение фигуры
                    // Запоминаем координаты клика мыши для последующего выделения фигуры
                    selectedCoordinate = new Point(e.X, e.Y);
                    // Находим фигуру по координатам и выделяем ее
                    FindFigure(e.X, e.Y);
                    break;

                case 4: //перемещение
                    // Сохраняем текущее положение мыши для последующего
                    // использования при перемещении
                    position.X = e.X;
                    position.Y = e.Y;

                    // Определяем центр относительно которого происходит преобразование
                    centerArray = new double[3, 3]
                    {
                        {1, 0, 0},
                        {0, 1, 0},
                        {-figures[numFigure].getCenter().X, -figures[numFigure].getCenter().Y, 1}
                    };
                    break;

                case 5: //ТМО симметрическая разность
                    // Добавляем фигуру для выполнения операции ТМО
                    addFigureForTMO(3, e.X, e.Y);
                    break;

                case 6: //ТМО пересечение
                    addFigureForTMO(1, e.X, e.Y);
                    break;

                case 7: //линия
                    if (firstPoint)
                    {
                        // Рисуем первую точку линии
                        g.DrawRectangle(DrawPen, e.X, e.Y, 1, 1);
                        point_line_begin = new Point(e.X, e.Y);
                        firstPoint = false;
                    }
                    else
                    {
                        // Рисуем вторую точку линии и добавляем новый объект типа Line в список figures
                        g.DrawRectangle(DrawPen, e.X, e.Y, 1, 1);
                        figures.Add(new Line(g, new Pen(colorDialog1.Color, 1), point_line_begin, new Point(e.X, e.Y)));
                        firstPoint = true;
                    }
                    DrawAll();
                    return;

                case 8: //задать центр
                    // Устанавливаем координаты центра по положению клика мыши
                    center.X = e.X;
                    center.Y = e.Y;
                    // Обновляем матрицу центра преобразования для учета нового центра
                    centerArray[2, 0] = -e.X;
                    centerArray[2, 1] = -e.Y;
                    break;

                    double[,] scaleMatrix;

                //Отражение относительно центра фигуры
                case 9:
                    // Матрица для операции отражения
                    scaleMatrix = new double[3, 3]{
                        {-1,  0,  0},
                        { 0, -1,  0},
                        { 0,  0,  1}
                    };
                    // Матрица для центра фигуры
                    centerArray = new double[3, 3]{
                        {1, 0, 0},
                        {0, 1, 0},
                        {-figures[numFigure].getCenter().X,  -figures[numFigure].getCenter().Y,  1}
                    };
                    // Применяем операцию отражения к фигуре
                    figures[numFigure].runOperation(centerArray, scaleMatrix);
                    DrawAll();

                    pictureBox.Refresh();
                    return;

                //Горизонтальное отражение
                case 10:
                    // Матрица для операции отражения по горизонтали
                    scaleMatrix = new double[3, 3]{
                        {1,  0,  0},
                        {0, -1,  0},
                        {0,  0,  1}
                    };
                    // Матрица для центра фигуры
                    centerArray = new double[3, 3]{
                        {1,  0,  0},
                        {0, 1,  0},
                        {-figures[numFigure].getCenter().X,  -e.Y,  1}
                    };
                    // Применяем операцию горизонтального отражения к фигуре
                    figures[numFigure].runOperation(centerArray, scaleMatrix);
                    DrawAll();
                    // Рисуем линию зеркала
                    g.DrawLine(Pens.DarkBlue, e.X - 1200, e.Y, e.X + 1200, e.Y);

                    pictureBox.Refresh();

                    return;
            }
            // Обновляем PictureBox, чтобы отобразить все изменения
            pictureBox.Refresh();
            DrawAll();
        }

        //Задать тип операции - параллелограмм
        private void PrlgButton_Click(object sender, EventArgs e)
        {
            typeOperation = 2;
        }
        //Задать тип операции - задать центр фигуры
        private void SetCenterButton_Click(object sender, EventArgs e)
        {
            typeOperation = 8;
        }

        //Задается тип операции - выделение
        private void SelectFigure_Click(object sender, EventArgs e)
        {
            typeOperation = 3;
        }

        //Задать тип операции - перемещение
        private void MoveButton_Click(object sender, EventArgs e)
        {
            typeOperation = 4;
        }

        //Выбор режима ТМО симметрическая разность
        private void Intersection_Click(object sender, EventArgs e)
        {
            typeOperation = 5;
            count = 0;
        }

        //Выбор режима ТМО пересечение
        private void Diff_Click(object sender, EventArgs e)
        {
            typeOperation = 6;
            count = 0;
        }

        //Очистка окна отрисовки
        private void ClearBox_Click(object sender, EventArgs e)
        {
            count = 0;// Сброс счетчика
            firstPoint = true;// Сброс флага первой точки линии
            twoFigure = new Interface_Figure[2];// Сброс массива выбранных фигур
            figures.Clear();// Очистка списка фигур
            g.Clear(Color.White);// Очистка изображения на холсте, делая его белым
            center = new Point(0, 0);// Сброс координат центра
            pictureBox.Refresh();// Обновление отображения на холсте
            Lp = new List<Point>();// Очистка списка точек для Кубического Сплайна
        }

        //Задать тип операции - зеркальное отражение относительно центра фигуры
        private void MfButton_Click(object sender, EventArgs e)
        {
            typeOperation = 9;
        }

        //Обработчик зажатой мыши(перемещение)
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (figures.Count == 0)
                return;// Если на холсте нет фигур, выход из метода

            if (typeOperation == 4 && e.Button == MouseButtons.Left)
            {
                // Перемещение фигуры при зажатой левой кнопке мыши
                double[,] moveArray = new double[3, 3]
                {
                    {1, 0, 0},
                    {0, 1, 0},
                    {e.X - position.X, e.Y - position.Y, 1}
                };
                // Выполнение операции перемещения для выбранной фигуры
                figures[numFigure].runOperation(centerArray, moveArray);
                // Обновление позиции для следующего смещения
                position.X = e.X;
                position.Y = e.Y;
                DrawAll();
            }
        }

        //Добавить результат ТМО
        public void addFigureForTMO(int type, int X, int Y)
        {
            count = 0;// Сброс счетчика
            // Поиск фигур, входящих в заданные координаты (X, Y)
            for (int i = 0; i < figures.Count; i++)
            {
                // Проверка вхождения точки (X, Y) в фигуру и ее типа
                if (figures[i].pointInside(new Point(X, Y)) && figures[i].isFigure())
                {
                    if (count < 2)
                    {
                        twoFigure[count] = figures[i];// Добавление фигуры в массив для ТМО
                        count++;
                        if (count == 2)
                        {
                            // Создание фигуры ТМО (теории множеств)
                            figures.Add(new TMOFigure(twoFigure[0], twoFigure[1], g, DrawPen, type));
                            // Удаление выбранных фигур из списка
                            figures.Remove(twoFigure[0]);
                            figures.Remove(twoFigure[1]);
                            DrawAll();
                            count = 0;// Сброс счетчика для следующих операций

                        }
                    }
                }
            }
        }


        //Задать тип операции - Spline
        private void SplineButton_Click(object sender, EventArgs e)
        {
            typeOperation = 0;
        }

        //Задать тип операции - линия
        private void LineButton_Click(object sender, EventArgs e)
        {
            typeOperation = 7;
        }

        //Удаление фигуры
        private void DelFigureButton_Click(object sender, EventArgs e)
        {
            //Если выделена не фигура - попытаемся найти отрезок или кривую
            if (FindFigure(selectedCoordinate.X, selectedCoordinate.Y))
            {
                // Если на холсте есть фигуры и выбранная фигура не относится к типу фигуры
                if (figures.Count > 0)
                {
                    figures.RemoveAt(numFigure);// Удаление выбранной фигуры из списка фигур
                    numFigure = 0;// Сброс номера выбранной фигуры
                    DrawAll();
                }
            }
        }

        private bool FindFigure(int x, int y)
        {
            // Поиск фигуры по координатам (x, y)
            for (int i = figures.Count - 1; i != -1; i--)
            {
                // Проверка вхождения координат (x, y) в каждую фигуру
                if (figures[i].pointInside(new Point(x, y)))
                {
                    numFigure = i;// Установка номера выбранной фигуры
                    return true;// Возвращаем true, если фигура найдена
                }
            }
            return false;// Возвращаем false, если фигура не найдена
        }

        //Задать тип операции - горизонтальное отражение
        private void MHButton_Click(object sender, EventArgs e)
        {
            typeOperation = 10;
        }


        //Задать тип операции - флаг
        private void FlagButton_Click(object sender, EventArgs e)
        {
            typeOperation = 1;
        }

        //Нажатие на кнопку Rc
        //Поворот вокруг заданного центра на произвольный угол
        private void RcButton_Click(object sender, EventArgs e)
        {
            // Поворот вокруг заданного центра на произвольный угол (Rc - Rotate around center)
            int alfa = 0;
            try
            {
                // Получение угла поворота из элемента управления
                alfa = Convert.ToInt32(numericUpDownAngle.Value);
            }
            catch
            {
                // Вывод сообщения об ошибке, если угол введен некорректно
                MessageBox.Show("Некорректно введен угол поворота");
            }

            if (figures.Count == 0)
                return;// Если на холсте нет фигур, выход из метода
            // Матрица для поворота
            double[,] rcArray = new double[3, 3]           
            {
                {Math.Cos(alfa * Math.PI / 180), Math.Sin(alfa * Math.PI / 180), 0},
                {-Math.Sin(alfa * Math.PI / 180), Math.Cos(alfa * Math.PI / 180), 0},
                {0, 0, 1}
            };
            // Применение операции поворота к выбранной фигуре вокруг центра
            figures[numFigure].runOperation(centerArray, rcArray);

            DrawAll();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            // Обновление цвета пера после нажатия на кнопку ОК в диалоге 
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                // Установка цвета пера после выбора цвета в диалоговом окне
                DrawPen.Color = colorDialog1.Color;
        }
    }
}
