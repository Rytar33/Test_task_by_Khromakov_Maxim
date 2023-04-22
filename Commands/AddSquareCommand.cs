using System;
using System.Collections.Generic;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Добавление квадрата </summary>
    public class AddSquareCommand : ICommand
    {
        private List<IFigure> Figures = new List<IFigure>();
        public AddSquareCommand(List<IFigure> figures) {
            Figures = figures;
        }
        public string Name => "AddSquare";
        /// <summary> Выполнение команды "Добавление квадрата" </summary>
        /// <param name="data">Информация о фигуре</param>
        public async void Execute(string data, int indexFigure = -1)
        {
            var EverySide = Convert.ToDouble(data);
            this.Figures.Add(new Square(EverySide));
        }
    }
}
