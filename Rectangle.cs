using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Rectangle : IFigure
    {
        private double Horizontally { get; set; } // Горизонтальная сторона
        private double Vertically { get; set; } // Вертикальная сторона
        public Rectangle(double horizontally, double vertically)
        {
            this.Horizontally = horizontally;
            this.Vertically = vertically;
        }
        public void PrintFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Прямоугольник\n"
                + "\tРазмеры сторон\n"
                + $"По горизонтали: {Horizontally}\n"
                + $"По вертикали: {Vertically}\n"
                + $"Периметр: {Math.Round(GetPerimeter(), 2)}\n"
                + $"Площадь: {Math.Round(GetArea(), 2)}\n"
                + "===============================");
        }
        public double GetArea() => Horizontally * Vertically; // Получение площади прямоугольника
        public double GetPerimeter() => (2 * Horizontally) + (2 * Vertically); // Получение периметра прямоугольника

    }
}