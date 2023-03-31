using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Rectangle : Figure
    {
        private double horizontally { get; set; } // Горизонтальная сторона
        private double vertically { get; set; } // Вертикальная сторона
        public Rectangle(double horizontally, double vertically)
        {
            this.horizontally = horizontally;
            this.vertically = vertically;
        }
        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Прямоугольник\n"
                + "\tРазмеры сторон\n"
                + $"По горизонтали: {horizontally}\n"
                + $"По вертикали: {vertically}\n"
                + $"Периметр: {Math.Round(Perimeter(), 2)}\n"
                + $"Площадь: {Math.Round(Area(), 2)}\n"
                + "===============================");
        }
        public override double Area() => horizontally * vertically; // Получение площади прямоугольника
        public override double Perimeter() => (2 * horizontally) + (2 * vertically); // Получение периметра прямоугольника

    }
}