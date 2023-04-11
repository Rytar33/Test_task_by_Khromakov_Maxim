using System;
using System.Collections.Generic;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary>Квадрат</summary>
    class Square : IFigure
    {
        private static List<double> SidesSquare { get; set; }
        private double SizeOfAllSides = SidesSquare[0];
        /// <summary>
        /// Конструктор квадрата
        /// </summary>
        /// <param name="sizeOfAllSides">Все 4 стороны квадрата</param>
        public Square(List<double> sidesSquare) : base(sidesSquare) { }
        /// <summary>
        /// Вывод квадрата и его параметров сразу в консоль
        /// </summary>
        /// <param name="id">Индентификатор квадрата</param>
        public override void PrintFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Квадрат\n"
                + $"Размер каждой стороны: {SizeOfAllSides}\n"
                + $"Периметр: {Math.Round(GetPerimeter(), 2)}\n"
                + $"Площадь: {Math.Round(GetArea(), 2)}\n"
                + "===============================");
        }
        /// <summary>
        /// Метод, благодаря которому мы получаем площадь квадрата
        /// </summary>
        /// <returns>Возвращает площадь квадрата по формуле (1 сторона в квадрате)</returns>
        public override double GetArea() => Math.Pow(SizeOfAllSides, 2);
        /// <summary>
        /// Метод, благодаря которому мы получаем периметр квадрата
        /// </summary>
        /// <returns>Возвращает периметр квадрата суммируя все стороны</returns>
        public override double GetPerimeter() => SizeOfAllSides * 4;
    }
}