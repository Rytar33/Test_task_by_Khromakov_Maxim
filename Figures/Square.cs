using System;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary>Квадрат</summary>
    class Square : IFigure
    {
        /// <summary> Размер всех 4-х сторон </summary>
        private double SizeOfAllSides { get; set; }
        /// <summary> Название фигуры квадрата </summary>
        public string Name => "Square";
        /// <summary> Все стороны квадрата </summary>
        public string Data => $"{SizeOfAllSides}";
        /// <summary> Конструктор квадрата </summary>
        /// <param name="sizeOfAllSides">Все 4 стороны квадрата</param>
        public Square(double sizeOfAllSides) => this.SizeOfAllSides = sizeOfAllSides;
        /// <summary> Вывод квадрата и его параметров сразу в консоль </summary>
        public override string ToString()
        {
            return "===============================\n"
                + "Фигура: Квадрат\n"
                + $"Размер каждой стороны: {SizeOfAllSides}\n"
                + $"Периметр: {Math.Round(GetPerimeter(), 2)}\n"
                + $"Площадь: {Math.Round(GetArea(), 2)}\n"
                + "===============================";
        }
        /// <summary> Метод, благодаря которому мы получаем площадь квадрата </summary>
        /// <returns>Возвращает площадь квадрата по формуле (1 сторона в квадрате)</returns>
        public double GetArea() => Math.Pow(SizeOfAllSides, 2);
        /// <summary> Метод, благодаря которому мы получаем периметр квадрата </summary>
        /// <returns>Возвращает периметр квадрата суммируя все стороны</returns>
        public double GetPerimeter() => SizeOfAllSides * 4;
    }
}