using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Trinagle : Figure
    {
        private double leftSide { get; set; } // Левая сторона треугольника
        private double rightSide { get; set; } // Правая сторона треугольника
        private double bottomSide { get; set; } // Основание треугольника
        public Trinagle(double leftSide, double rightSide, double bottomSide)
        {
            this.leftSide = leftSide;
            this.rightSide = rightSide;
            this.bottomSide = bottomSide;
        }
        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Треугольник\n"
                + "\tРазмеры каждых сторон\n"
                + $"Левая сторона: {leftSide}\n"
                + $"Правая сторона: {rightSide}\n"
                + $"Нижняя сторона: {bottomSide}\n"
                + $"Тип треугольника: {TypeTrinagle()}\n"
                + $"Периметр: {Math.Round(Perimeter(), 2)}\n"
                + $"Площадь: {Math.Round(Area(), 2)}\n"
                + "===============================");
        }
        // Получение площади треугольника
        public override double Area()
        {
            double halfPer = Perimeter() * 0.5;
            double result = Math.Sqrt(halfPer * (halfPer - leftSide) * (halfPer - rightSide) * (halfPer - bottomSide));
            return result;
        }
        public override double Perimeter() => leftSide + rightSide + bottomSide; // Получение периметра треугольника
        public string TypeTrinagle()
        {
            string message;
            if ((leftSide == rightSide) && (rightSide == bottomSide) && (leftSide == bottomSide)) message = "Равносторонний"; // Если все стороны равны, то будет истина
            else if ((leftSide == rightSide) && (leftSide != bottomSide) && (rightSide != bottomSide)) message = "Равнобедренный"; // Если равны только левая и правая часть, то будет истина
            else message = "Разносторонний"; // Иначе стороны разные
            return message;
        }
    }
}