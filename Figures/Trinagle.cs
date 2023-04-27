using System;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary> Треугольник </summary>
    class Trinagle : IFigure
    {
        /// <summary> Размер левой стороны </summary>
        private double LeftSide { get; set; }
        /// <summary> Размер правой стороны </summary>
        private double RightSide { get; set; }
        /// <summary> Размер основание </summary>
        private double BaseSide { get; set; }
        /// <summary> Название фигуры треугольника </summary>
        public string Name => "Trinagle";
        /// <summary> Все стороны треугольника </summary>
        public string Data => $"{LeftSide} {RightSide} {BaseSide}";
        /// <summary> Конструктор треугольника </summary>
        /// <param name="leftSide">Левая сторона треугольника</param>
        /// <param name="rightSide">Правая сторона треугольника</param>
        /// <param name="baseSide">Основание треугольника</param>
        public Trinagle(double leftSide, double rightSide, double baseSide)
        {
            this.LeftSide = leftSide;
            this.RightSide = rightSide;
            this.BaseSide = baseSide;
        }
        /// <summary> Вывод треугольника и его параметров сразу в консоль </summary>
        public override string ToString()
        {
            return "===============================\n"
                + "Фигура: Треугольник\n"
                + "\tРазмеры каждых сторон\n"
                + $"Левая сторона: {LeftSide}\n"
                + $"Правая сторона: {RightSide}\n"
                + $"Нижняя сторона: {BaseSide}\n"
                + $"Периметр: {Math.Round(GetPerimeter(), 2)}\n"
                + $"Площадь: {Math.Round(GetArea(), 2)}\n"
                + "===============================";
        }
        /// <summary> Метод, благодаря которому мы получаем площадь треугольника </summary>
        /// <returns>Возвращает по формуле площадь треугольника (Корень из половины периметра * на (половина периметра - каждая из сторон) * ...)</returns>
        public double GetArea()
        {
            double halfPer = GetPerimeter() * 0.5;
            return Math.Sqrt(halfPer * (halfPer - LeftSide) * (halfPer - RightSide) * (halfPer - BaseSide));
        }

        /// <summary> Метод, благодаря которому мы получаем периметр треугольника </summary>
        /// <returns>Возвращает сумму всех сторон треугольника</returns>
        public double GetPerimeter() => LeftSide + RightSide + BaseSide;
    }
}