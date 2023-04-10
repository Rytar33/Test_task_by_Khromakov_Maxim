using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary>Квадрат</summary>
    class Square : IFigure
    {
        private double SizeOfAllSides { get; set; }
        /// <summary>
        /// Конструктор квадрата
        /// </summary>
        /// <param name="sizeOfAllSides">Все 4 стороны квадрата</param>
        public Square(double sizeOfAllSides) => this.SizeOfAllSides = sizeOfAllSides;
        /// <summary>
        /// Вывод квадрата и его параметров сразу в консоль
        /// </summary>
        /// <param name="id">Индентификатор квадрата</param>
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
        /// <summary>
        /// Метод, благодаря которому мы получаем площадь квадрата
        /// </summary>
        /// <returns>Возвращает площадь квадрата по формуле (1 сторона в квадрате)</returns>
        public double GetArea() => Math.Pow(SizeOfAllSides, 2);
        /// <summary>
        /// Метод, благодаря которому мы получаем периметр квадрата
        /// </summary>
        /// <returns>Возвращает периметр квадрата суммируя все стороны</returns>
        public double GetPerimeter() => SizeOfAllSides * 4;
    }
}