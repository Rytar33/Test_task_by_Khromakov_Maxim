using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Square : IFigure
    {
        private double SizeOfAllSides { get; set; } // Размер всех сторон квадрата
        public Square(double sizeOfAllSides) => this.SizeOfAllSides = sizeOfAllSides;

        public void PrintFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Квадрат\n"
                + $"Размер каждой стороны: {SizeOfAllSides}\n"
                + $"Периметр: {Math.Round(GetPerimeter(), 2)}\n"
                + $"Площадь: {Math.Round(GetArea(), 2)}\n"
                + "===============================");
        }
        public double GetArea() => Math.Pow(SizeOfAllSides, 2); // Получение площади квадрата
        public double GetPerimeter() => SizeOfAllSides * 4; // Получение периметра квадрата

    }
}