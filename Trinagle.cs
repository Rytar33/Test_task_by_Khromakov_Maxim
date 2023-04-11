using System;
using System.Collections.Generic;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary> Треугольник </summary>
    class Trinagle : IFigure
    {
        private static List<double> SidesTrinagle { get; set; }
        private double LeftSide = SidesTrinagle[0];
        private double RightSide = SidesTrinagle[0];
        private double BaseSide = SidesTrinagle[0];

        /// <summary>
        /// Конструктор треугольника
        /// </summary>
        /// <param name="leftSide">Левая сторона треугольника</param>
        /// <param name="rightSide">Правая сторона треугольника</param>
        /// <param name="baseSide">Основание треугольника</param>
        public Trinagle(List<double> sidesTrinagle) : base(sidesTrinagle) { }
        /// <summary>
        /// Вывод треугольника и его параметров сразу в консоль
        /// </summary>
        /// <param name="id">Индентификатор треугольника</param>
        public override void PrintFigure(int id)
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

        /// <summary>
        /// Метод, благодаря которому мы получаем площадь треугольника
        /// </summary>
        /// <returns>Возвращает по формуле площадь треугольника (Корень из половины периметра * на (половина периметра - каждая из сторон) * ...)</returns>
        public override double GetArea()
        {
            double halfPer = GetPerimeter() * 0.5;
            return Math.Sqrt(halfPer * (halfPer - LeftSide) * (halfPer - RightSide) * (halfPer - BaseSide));
        }

        /// <summary>
        /// Метод, благодаря которому мы получаем периметр треугольника
        /// </summary>
        /// <returns>Возвращает сумму всех сторон треугольника</returns>
        public override double GetPerimeter() => LeftSide + RightSide + BaseSide;
        /// <summary>
        /// Метод, благодаря которому мы получаем тип треугольника
        /// </summary>
        /// <returns>Возвращает тип треугольника (Равносторонний, Равнобедренный, Разносторонний)</returns>
        public string GetTypeTrinagle()
            => ((LeftSide == RightSide) && (RightSide == BaseSide) && (LeftSide == BaseSide))
                ? "Равносторонний" // Если все стороны треугольника равны - выведет "Равносторонний"
                : ((LeftSide == RightSide) && (LeftSide != BaseSide) && (RightSide != BaseSide))
                ? "Равнобедренный" // Если у треугольника равна только левая и правая часть - выведете "Равнобедренный"
                : "Разносторонний"; // Иначе - "Разносторонний"
    }
}