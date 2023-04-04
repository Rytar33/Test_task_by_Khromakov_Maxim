namespace Test_task_by_Khromakov_Maxim
{
    /// <summary> »нтерфейс фигуры </summary>
    interface IFigure
    {
        /// <summary> ћетод, благодар¤ которому мы выводим фигуру в консоль </summary>
        /// <param name="ID">»ндентификатор фигуры</param>
        public void PrintFigure(int ID);
        /// <summary> ћетод, благодар¤ которому мы получаем плошадь фигуры </summary>
        public double GetArea();
        /// <summary> ћетод, благодар¤ которому мы получаем периметр фигуры </summary>
        public double GetPerimeter();
    }
}