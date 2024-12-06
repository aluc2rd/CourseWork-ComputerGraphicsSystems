using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Std
{
    //Интерфейс фигуры(для задания сигнатуры)
    interface Interface_Figure
    {
        //возврат экстремумов фигуры
        int getMaxY();
        int getMinY();
        //возврат массива левых и правых
        List<int> getLpL(int Y);
        List<int> getLpR(int Y);
        //самоотрисовка фигуры
        void DrawFigure();
        //применить к фигуре операцию
        void runOperation(double[,] center, double[,] operation);
        //проверить лежит ли данная точка внутри фигуры
        bool pointInside(Point p);
        Point getCenter();
        bool isFigure();
    }
}
