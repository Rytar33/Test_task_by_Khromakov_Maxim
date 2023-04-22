using System;
using System.Collections.Generic;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Получение всех фигур </summary>
    public class GetAllFigureCommand : ICommand
    {
        private List<IFigure> Figures = new List<IFigure>();
        public GetAllFigureCommand(List<IFigure> figures) {
            Figures = figures;
        }
        public string Name => "GetAllFigure()";
        /// <summary> Выполнение команды "Получение всех фигур" </summary>
        public async void Execute(string data = "", int indexFigure = -1)
        {
            if (this.Figures.Count != 0) // Выполняется, только если лист фигур не пуст
            {
                foreach (var item in this.Figures)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
