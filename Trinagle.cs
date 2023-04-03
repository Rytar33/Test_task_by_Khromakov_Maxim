using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Trinagle : IFigure
    {
        private double LeftSide { get; set; } // Левая сторона треугольника
        private double RightSide { get; set; } // Правая сторона треугольника
        private double BaseSide { get; set; } // Основание треугольника
        public Trinagle(double leftSide, double rightSide, double baseSide)
        {
            this.LeftSide = leftSide;
            this.RightSide = rightSide;
            this.BaseSide = baseSide;
        }
        public void PrintFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Треугольник\n"
                + "\tРазмеры каждых сторон\n"
                + $"Левая сторона: {LeftSide}\n"
                + $"Правая сторона: {RightSide}\n"
                + $"Нижняя сторона: {BaseSide}\n"
                + $"Тип треугольника: {GetTypeTrinagle()}\n"
                + $"Периметр: {Math.Round(GetPerimeter(), 2)}\n"
                + $"Площадь: {Math.Round(GetArea(), 2)}\n"
                + "===============================");
        }
        // Получение площади треугольника
        public double GetArea()
        {
            double halfPer = GetPerimeter() * 0.5;
            return Math.Sqrt(halfPer * (halfPer - LeftSide) * (halfPer - RightSide) * (halfPer - BaseSide));
        }
        public double GetPerimeter() 
            => LeftSide + RightSide + BaseSide; // Получение периметра треугольника
        public string GetTypeTrinagle()
            => ((LeftSide == RightSide) && (RightSide == BaseSide) && (LeftSide == BaseSide))
                ? "Равносторонний" // Если все стороны треугольника равны - выведет "Равносторонний"
                : ((LeftSide == RightSide) && (LeftSide != BaseSide) && (RightSide != BaseSide))
                ? "Равнобедренный" // Если у треугольника равна только левая и правая часть - выведете "Равнобедренный"
                : "Разносторонний"; // Иначе - "Разносторонний"
    }
}