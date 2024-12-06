using System.Collections.Generic;
using System.Drawing;

namespace Std
{
    struct M
    {
        public int x;// Представляет координату X точки в фигуре
        public int dQ;
    }
    class TMOFigure : Interface_Figure
    {

        //Поля
        Interface_Figure first;// Первая фигура для операции
        Interface_Figure second;// Вторая фигура для операции
        Graphics g;
        Pen pen;
        private List<ListsFromY> listsFigure;// Список фигур
        Point centerFigure;// Центр фигуры
        int[] SetQ = new int[2];// Массив для хранения параметров операции

        //Конструктор
        public TMOFigure(Interface_Figure first, Interface_Figure second, Graphics g, Pen pen, int operation)
        {
            this.first = first;// Устанавливает первую фигуру для операции
            this.second = second;// Устанавливает вторую фигуру для операции
            this.g = g;
            this.pen = new Pen(pen.Brush);

            setQ(operation);// Устанавливает параметры операции на основе переданного кода операции
            setListFigure();// Инициализирует список фигуры на основе установленных фигур и параметров операции
        }

        public Point getCenter()
        {
            procBorder();// Вычисляет границы фигуры для определения центра
            return centerFigure;// Возвращает точку, представляющую центр фигуры
        }


        //Отрисовка
        public void DrawFigure()
        {
            // Внешний цикл перебирает каждый элемент в списке фигуры listsFigure
            for (int i = 0; i < listsFigure.Count; i++)
            {
                // Внутренний цикл перебирает каждую левую точку Lpl в текущем элементе фигуры
                for (int j = 0; j < listsFigure[i].Lpl.Count; j++)
                {
                    // Рисует линии между левыми и правыми точками списка фигуры
                    g.DrawLine(pen, new Point(listsFigure[i].Lpl[j], listsFigure[i].Y), new Point(listsFigure[i].Lpr[j], listsFigure[i].Y));
                }
            }
        }
         

        //Возвращает по заданному У массив левых точек
        public List<int> getLpL(int Y)
        {
            // Перебираем элементы списка фигуры listsFigure
            for (int i = 0; i < listsFigure.Count; i++)
            {
                // Проверяем совпадение Y-координаты текущего элемента с заданной координатой Y
                if (listsFigure[i].Y == Y)
                {
                    return listsFigure[i].Lpl;// Возвращает массив левых точек для заданной координаты Y
                }
            }
            return new List<int>();// Возвращает пустой массив, если соответствующая координата Y не найдена
        }

        //Возвращает по заданному У массив правых точек
        public List<int> getLpR(int Y)
        {
            // Перебор элементов списка фигуры listsFigure
            for (int i = 0; i < listsFigure.Count; i++)
            {
                // Проверка совпадения Y-координаты текущего элемента с заданной координатой Y
                if (listsFigure[i].Y == Y)
                {
                    return listsFigure[i].Lpr;// Возврат массива правых точек для заданной координаты Y
                }
            }
            return new List<int>();// Возврат пустого массива, если соответствующая координата Y не найдена
        }

        //Получить максимальную точку фигуры по У
        public int getMaxY()
        {
            return listsFigure[listsFigure.Count - 1].Y;// Возвращает Y-координату последнего элемента списка фигуры
        }

        //Получить минимальную точку фигуры по У
        public int getMinY()
        {
            return listsFigure[0].Y;// Возвращает Y-координату первого элемента списка фигуры
        }

        //Проверяет попала ли точка в фигуру
        public bool pointInside(Point p)
        {
            for (int i = 0; i < listsFigure.Count; i++)
            {
                // Проверяем совпадение Y-координаты текущего элемента с Y-координатой проверяемой точки
                if (listsFigure[i].Y == p.Y)
                {
                    // Проверка попадания по X между левыми и правыми точками на заданной Y-координате
                    for (int k = 0; k < listsFigure[i].Lpl.Count; k++)
                    {
                        if (listsFigure[i].Lpl[k] < p.X && p.X < listsFigure[i].Lpr[k])
                        {
                            return true;// Точка попадает внутрь фигуры
                        }
                    }
                }
            }
            return false;// Точка находится за пределами фигуры
        }

        //Выполняем непрерывную операцию
        public void runOperation(double[,] center, double[,] operation)
        {
            // Выполнение операции для первой и второй фигур
            first.runOperation(center, operation);
            second.runOperation(center, operation);
            setListFigure();// Обновление списка фигуры после операции
        }

        //Получение диапазона из кода операции
        public void setQ(int code)
        {
            switch (code)
            {
                //Пересечение
                case 1:
                    SetQ[0] = 3;// Нижний предел диапазона
                    SetQ[1] = 3;// Верхний предел диапазона
                    break;
                //Разность A - B
                case 2:
                    SetQ[0] = 2;
                    SetQ[1] = 2;
                    break;
                //Симметрическая разность
                case 3:
                    SetQ[0] = 1;
                    SetQ[1] = 2;
                    break;
                //Объединение
                case 4:
                    SetQ[0] = 1;
                    SetQ[1] = 3;
                    break;
            }
        }


        //Заполняет список фигуры
        private void setListFigure()
        {
            // Инициализация списка, содержащего информацию о фигуре
            listsFigure = new List<ListsFromY>();

            int start = first.getMinY();// Получение минимальной Y-координаты из первой фигуры
            int end = first.getMaxY();// Получение максимальной Y-координаты из первой фигуры
            // Определение общего диапазона Y-координат для обеих фигур
            if (start > second.getMinY())
            {
                start = second.getMinY();
            }
            if (start > second.getMaxY())
            {
                start = second.getMaxY();
            }
            if (end < second.getMinY())
            {
                end = second.getMinY();
            }
            if (end < second.getMaxY())
            {
                end = second.getMaxY();
            }
            // Создание списков для хранения левых и правых точек
            List<int> Xal = new List<int>();
            List<int> Xar = new List<int>();

            List<int> Xbl = new List<int>();
            List<int> Xbr = new List<int>();

            List<M> m = new List<M>();
            List<int> Xrl = new List<int>();
            List<int> Xrr = new List<int>();

            // Перебор Y-координат в заданном диапазоне
            for (int Y = start; Y <= end; Y++)
            {
                // Очистка списков перед заполнением
                Xrl.Clear();
                Xrr.Clear();
                m.Clear();

                // Получение левых и правых точек для обеих фигур на текущей Y-координате
                Xal = first.getLpL(Y);
                Xar = first.getLpR(Y);
                Xbl = second.getLpL(Y);
                Xbr = second.getLpR(Y);
                // Заполнение списка M для всех точек обеих фигур на текущей Y-координате
                for (int i = 0; i < Xal.Count; i++)
                {
                    // M - структура, содержащая координату X точки и ее отношение к операциям над фигурами
                    M temp;
                    temp.x = Xal[i];// Установка X-координаты из списка левых точек первой фигуры
                    temp.dQ = 2;// Установка отношения точки к операциям (для левой точки первой фигуры)
                    m.Add(temp);// Добавление точки в список M
                }
                // Аналогично добавляем остальные точки из списка Xar, Xbl и Xbr с
                // соответствующими значениями dQ
                for (int i = 0; i < Xar.Count; i++)
                {
                    M temp;
                    temp.x = Xar[i];
                    temp.dQ = -2;
                    m.Add(temp);
                }
                for (int i = 0; i < Xbl.Count; i++)
                {
                    M temp;
                    temp.x = Xbl[i];
                    temp.dQ = 1;
                    m.Add(temp);
                }
                for (int i = 0; i < Xbr.Count; i++)
                {
                    M temp;
                    temp.x = Xbr[i];
                    temp.dQ = -1;
                    m.Add(temp);
                }


                // Сортировка списка точек M по X-координате
                for (int h = 0; h < m.Count - 1; h++)
                {
                    for (int j = h + 1; j < m.Count; j++)
                    {
                        // Если X-координата следующей точки меньше, чем текущей точки, меняем их местами
                        if (m[j].x < m[h].x)
                        {
                            M temp = m[h];// Сохраняем текущую точку во временной переменной temp
                            m[h] = m[j];// Заменяем текущую точку на следующую
                            m[j] = temp;// Заменяем следующую точку сохраненной временной переменной
                        }
                    }
                }

                int Q = 0;
                int Qnew;
                int x;
                // Проверка, что список M не пустой
                if (m.Count == 0)
                {
                    continue;// Продолжаем итерацию, если список M пустой
                }
                // Проверка и установка начального значения Q в зависимости от первой
                // точки списка M
                if (m[0].x >= 0 && m[0].dQ < 0)
                {
                    // Добавляем точку с координатой 0 в список левых точек новой фигуры
                    Xrl.Add(0);
                    // Устанавливаем значение Q в соответствии с первой точкой списка M
                    Q = -m[0].dQ;
                }

                // Обработка всех точек в списке M для формирования списков Xrl и Xrr
                for (int i = 0; i < m.Count; i++)
                {
                    x = m[i].x;
                    Qnew = Q + m[i].dQ;
                    // Проверка условий для добавления точек в списки Xrl и Xrr в соответствии с SetQ
                    if ((Q < SetQ[0] || Q > SetQ[1]) && (Qnew >= SetQ[0] && Qnew <= SetQ[1]))
                    {
                        Xrl.Add(x);
                    }
                    if ((Q >= SetQ[0] && Q <= SetQ[1]) && (Qnew < SetQ[0] || Qnew > SetQ[1]))
                    {
                        Xrr.Add(x);
                    }

                    Q = Qnew;// Обновление значения Q для следующей точки списка M
                }
                // Добавление последней точки (если применимо) в список Xrr
                if (Q >= SetQ[0] && Q <= SetQ[1])
                {
                    Xrr.Add(1149);// Добавление точки в список правых точек новой фигуры
                }
                // Сортировка списков Xrl и Xrr
                SortList(Xrl);
                SortList(Xrr);
                // Создание и заполнение объекта ListsFromY для текущей Y-координаты
                ListsFromY l = new ListsFromY();
                // Установка Y-координаты для объекта
                l.Y = Y;
                l.Lpl = new List<int>(Xrl);// Инициализация списка левых точек для объекта
                l.Lpr = new List<int>(Xrr);// Инициализация списка правых точек для объекта

                listsFigure.Add(l);// Добавление объекта в список фигуры
                //Удаляем верхние и нижние пустые строки
                while (listsFigure.Count > 0 && listsFigure[0].Lpl.Count == 0)
                {
                    listsFigure.RemoveAt(0);// Удаляем верхнюю строку списка, если она пуста
                }
                while (listsFigure.Count > 0 && listsFigure[listsFigure.Count - 1].Lpl.Count == 0)
                {
                    listsFigure.RemoveAt(listsFigure.Count - 1);// Удаляем нижнюю строку списка, если она пуста
                }

            }
        }

        //Сортировка списка целых чисел в порядке возрастания
        //с использованием алгоритма сортировки пузырьком
        private void SortList(List<int> Lp)
        {
            // Внешний цикл, проходящий через каждый элемент списка Lp
            for (int h = 0; h < Lp.Count - 1; h++)
            {
                // Внутренний цикл, сравнивающий каждый элемент с последующими элементами списка
                for (int j = h + 1; j < Lp.Count; j++)
                {
                    // Если следующий элемент меньше текущего, меняем их местами
                    if (Lp[j] < Lp[h])
                    {
                        int temp = Lp[h];// Сохраняем текущий элемент во временной переменной temp
                        Lp[h] = Lp[j];// Заменяем текущий элемент на следующий
                        Lp[j] = temp;// Заменяем следующий элемент сохраненной временной переменной
                    }
                }
            }
        }

        private void procBorder()
        {
            // Получаем максимальную и минимальную Y-координату из списка фигуры
            int Y1 = getMaxY();
            int Y2 = getMinY();
            // Получаем максимальную и минимальную X-координату из списка фигуры
            int X1 = getMinX();
            int X2 = getMaxX();
            // Находим середину по осям X и Y и устанавливаем ее как центр фигуры
            centerFigure = new Point(((X2 + X1) / 2), (Y2 + Y1) / 2);
        }

        private int getMinX()
        {
            // Инициализируем переменную x максимально возможным значением int
            int x = int.MaxValue;
            // Проходимся по всем элементам списка фигуры для поиска минимального значения X
            for (int i = 0; i < listsFigure.Count; i++)
            {
                for (int j = 0; j < listsFigure[i].Lpl.Count; j++)
                {
                    // Если текущее значение X меньше сохраненного минимального значения X,
                    // обновляем минимальное значение X
                    if (x > listsFigure[i].Lpl[j])
                    {
                        x = listsFigure[i].Lpl[j];
                    }
                }
            }
            return x;// Возвращаем минимальное значение X

        }

        private int getMaxX()
        {
            int x = 0;// Инициализируем переменную x минимально возможным значением
            // Проходимся по всем элементам списка фигуры для поиска максимального значения X
            for (int i = 0; i < listsFigure.Count; i++)
            {
                for (int j = 0; j < listsFigure[i].Lpr.Count; j++)
                {
                    // Если текущее значение X больше сохраненного максимального значения X,
                    // обновляем максимальное значение X
                    if (x < listsFigure[i].Lpr[j])
                    {
                        x = listsFigure[i].Lpr[j];
                    }
                }
            }
            return x;// Возвращаем максимальное значение X
        }

        public bool isFigure()
        {
            return true;
        }
    }
}

