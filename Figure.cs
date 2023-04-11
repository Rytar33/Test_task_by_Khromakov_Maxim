using System.Collections.Generic;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary> Интерфейс фигуры </summary>
    abstract class IFigure
    {
        private List<double> Sides { get; set; }
        public IFigure(List<double> sides) => this.Sides = sides;
        /// <summary> Метод, благодаря которому мы выводим фигуру в консоль </summary>
        /// <param name="ID">Индентификатор фигуры</param>
        public abstract void PrintFigure(int ID);
        /// <summary> Метод, благодаря которому мы получаем плошадь фигуры </summary>
        public abstract double GetArea();
        /// <summary> Метод, благодаря которому мы получаем периметр фигуры </summary>
        public abstract double GetPerimeter();
    }
}