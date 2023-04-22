using System;
using System.Collections.Generic;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Добавление круга </summary>
    public class AddRoundCommand : ICommand
    {
        private List<IFigure> Figures = new List<IFigure>();
        public AddRoundCommand(List<IFigure> figures) {
            Figures = figures;
        }
        public string Name => "AddRound";
        /// <summary> Выполнение команды "Добавление круга" </summary>
        /// <param name="data">Информация о фигуре</param>
        public async void Execute(string data, int indexFigure = -1)
        {
            var Radius = Convert.ToDouble(data);
            this.Figures.Add(new Round(Radius));
        }
    }
}
