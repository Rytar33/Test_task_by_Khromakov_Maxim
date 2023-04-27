using System;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary> Прямоугольник </summary>
    class Rectangle : IFigure
    {
        /// <summary> Размер горизонтальной стороны </summary>
        private double Horizontally { get; set; }
        /// <summary> Размер вертикальной стороны </summary>
        private double Vertically { get; set; }
        /// <summary> Название фигуры прямоугольника </summary>
        public string Name => "Rectangle";
        /// <summary> Все стороны прямоугольника </summary>
        public string Data => $"{Horizontally} {Vertically}";
        /// <summary> Конструктор прямоугольника </summary>
        /// <param name="horizontally">Горизонтальные сторона прямоугольника</param>
        /// <param name="vertically">Вертикальная сторона прямоугольника</param>
        public Rectangle(double horizontally, double vertically)
        {
            this.Horizontally = horizontally;
            this.Vertically = vertically;
        }
        /// <summary> Вывод прямоугольника и его параметров сразу в консоль </summary>
        public override string ToString()
        {
            return "===============================\n"
                + "Фигура: Прямоугольник\n"
                + "\tРазмеры сторон\n"
                + $"По горизонтали: {Horizontally}\n"
                + $"По вертикали: {Vertically}\n"
                + $"Периметр: {Math.Round(GetPerimeter(), 2)}\n"
                + $"Площадь: {Math.Round(GetArea(), 2)}\n"
                + "===============================";
        }
        /// <summary> Метод, благодаря которому мы получаем площадь прямоугольника </summary>
        /// <returns>Возвращает площадь прямоугольника, умножая горизонтальную сторону и вертикальную между собой</returns>
        public double GetArea() => Horizontally * Vertically;
        /// <summary> Метод, благодаря которому мы получаем периметр прямоугольника </summary>
        /// <returns>Возвращает периметр прямоугольника по формуле (2 * горизонтальную сторону) + (2 * вертикальную сторону)</returns>
        public double GetPerimeter() => (2 * Horizontally) + (2 * Vertically);
    }
}