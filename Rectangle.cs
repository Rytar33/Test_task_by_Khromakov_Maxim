using System;
using System.Collections.Generic;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary> Прямоугольник </summary>
    class Rectangle : IFigure
    {
        private static List<double> SidesRectangle { get; set; }
        private double Horizontally = SidesRectangle[0];
        private double Vertically = SidesRectangle[1];
        /// <summary> Конструктор прямоугольника </summary>
        /// <param name="horizontally">Горизонтальные сторона прямоугольника</param>
        /// <param name="vertically">Вертикальная сторона прямоугольника</param>
        public Rectangle(List<double> sidesRectangle) : base(sidesRectangle) { }
        /// <summary>
        /// Вывод прямоугольника и его параметров сразу в консоль
        /// </summary>
        /// <param name="id">Индентификатор прямоугольника</param>
        public override void PrintFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Прямоугольник\n"
                + "\tРазмеры сторон\n"
                + $"По горизонтали: {Horizontally}\n"
                + $"По вертикали: {Vertically}\n"
                + $"Периметр: {Math.Round(GetPerimeter(), 2)}\n"
                + $"Площадь: {Math.Round(GetArea(), 2)}\n"
                + "===============================");
        }
        public override double GetArea() => Horizontally * Vertically;
        /// <summary>
        /// Метод, благодаря которому мы получаем периметр прямоугольника
        /// </summary>
        /// <returns>Возвращает периметр прямоугольника по формуле (2 * горизонтальную сторону) + (2 * вертикальную сторону)</returns>
        public override double GetPerimeter() => (2 * Horizontally) + (2 * Vertically);
    }
}