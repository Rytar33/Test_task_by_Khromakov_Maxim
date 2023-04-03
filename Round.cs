using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Round : IFigure
    {
        private double Radius { get; set; } // Радиус круга
        public Round(double radius) => this.Radius = radius;

        public void PrintFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Круг\n"
                + $"Радиус круга: {Radius}\n"
                + $"Периметр: {Math.Round(GetPerimeter(), 2)}\n"
                + $"Площадь: {Math.Round(GetArea(), 2)}\n"
                + "===============================");
        }
        public double GetArea() => Math.PI * Math.Pow(Radius, 2); // Получение площади круга
        public double GetPerimeter() => 2 * Math.PI * Radius; // Получение периметра круга
    }
}