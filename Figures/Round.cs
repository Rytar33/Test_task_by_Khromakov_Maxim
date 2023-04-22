using System;
using Test_task_by_Khromakov_Maxim.Figures;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary> Круг </summary>
    class Round : IFigure
    {
        /// <summary> Радиус </summary>
        private double Radius { get; set; }
        public string Name => "Round";
        public string Data => $"{Radius}";
        /// <summary> Конструктор круга </summary>
        /// <param name="radius">Радиус круга</param>
        public Round(double radius) => this.Radius = radius;
        /// <summary> Вывод круга и его параметров сразу в консоль </summary>
        public override string ToString()
        {
            return "===============================\n"
                + "Фигура: Круг\n"
                + $"Радиус круга: {Radius}\n"
                + $"Периметр: {Math.Round(GetPerimeter(), 2)}\n"
                + $"Площадь: {Math.Round(GetArea(), 2)}\n"
                + "===============================";
        }
        /// <summary> Метод, благодаря которому мы получаем площадь круга </summary>
        /// <returns>Возвращает площадь круга по формуле (Число ПИ * радиус в квадрате)</returns>
        public double GetArea() => Math.PI * Math.Pow(Radius, 2);
        /// <summary> Метод, благодаря которому мы получаем периметр круга </summary>
        /// <returns>Возвращает периметр круга по формуле (2 * число ПИ * радиус)</returns>
        public double GetPerimeter() => 2 * Math.PI * Radius;
    }
}