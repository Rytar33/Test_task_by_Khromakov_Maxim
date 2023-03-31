using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Square : Figure
    {
        private double SizeSides { get; set; } // Размер всех 4-х сторон квадрата
        public Square(double sizeSides) => this.SizeSides = sizeSides;

        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Квадрат\n"
                + $"Размер каждой стороны: {SizeSides}\n"
                + $"Периметр: {Math.Round(Perimeter(), 2)}\n"
                + $"Площадь: {Math.Round(Area(), 2)}\n"
                + "===============================");
        }
        public override double Area() => Math.Pow(SizeSides, 2); // Получение площади квадрата
        public override double Perimeter() => SizeSides * 4; // Получение периметра квадрата

    }
}