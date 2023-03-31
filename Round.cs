using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Round : Figure
    {
        private double Radius { get; set; } // Радиус круга
        public Round(double radius) => this.Radius = radius;

        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Круг\n"
                + $"Радиус круга: {Radius}\n"
                + $"Периметр: {Math.Round(Perimeter(), 2)}\n"
                + $"Площадь: {Math.Round(Area(), 2)}\n"
                + "===============================");
        }
        public override double Area() => Math.PI * Math.Pow(Radius, 2); // Получение площади круга
        public override double Perimeter() => 2 * Math.PI * Radius; // Получение периметра круга
    }
}