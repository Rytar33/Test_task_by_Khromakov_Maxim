namespace Test_task_by_Khromakov_Maxim.Figures
{
    /// <summary> Интерфейс фигуры </summary>
    public interface IFigure
    {
        /// <summary> Имя фигуры </summary>
        string Name { get; }
        /// <summary> Стороны фигуры </summary>
        string Data { get; }
        /// <summary> Метод, благодаря которому мы получаем плошадь фигуры </summary>
        double GetArea();
        /// <summary> Метод, благодаря которому мы получаем периметр фигуры </summary>
        double GetPerimeter();
    }
}
