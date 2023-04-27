using System;
using System.Collections.Generic;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Добавление круга </summary>
    public class AddRoundCommand : ICommand
    {
        /// <summary> Лист фигур в оперативной памяти </summary>
        private List<IFigure> Figures = new List<IFigure>();
        /// <summary> Конструктор команды </summary>
        /// <param name="figures">Принимает лист фигур</param>
        public AddRoundCommand(List<IFigure> figures) => Figures = figures;
        public string Name => "AddRound";
        /// <summary> Выполнение команды "Добавление круга" </summary>
        /// <param name="data">Информация о фигуре</param>
        public async void Execute(string data)
        {
            var Radius = Convert.ToDouble(data);
            this.Figures.Add(new Round(Radius));
        }
    }
}
