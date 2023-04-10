namespace Test_task_by_Khromakov_Maxim
{
    /// <summary> Интерфейс фигуры </summary>
    interface IFigure
    {
        /// <summary> Метод, благодаря которому мы выводим фигуру в консоль </summary>
        /// <param name="ID">Индентификатор фигуры</param>
        public void PrintFigure(int ID);
        /// <summary> Метод, благодаря которому мы получаем плошадь фигуры </summary>
        public double GetArea();
        /// <summary> Метод, благодаря которому мы получаем периметр фигуры </summary>
        public double GetPerimeter();
    }
}