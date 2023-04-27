using System;
using System.Collections.Generic;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Получение всех фигур </summary>
    public class GetAllFigureCommand : ICommand
    {
        /// <summary> Лист фигур в оперативной памяти </summary>
        private List<IFigure> Figures = new List<IFigure>();
        /// <summary> Конструктор команды </summary>
        /// <param name="figures">Принимает лист фигур</param>
        public GetAllFigureCommand(List<IFigure> figures) => Figures = figures;
        public string Name => "GetAllFigure";
        /// <summary> Выполнение команды "Получение всех фигур" </summary>
        public async void Execute(string data = null)
        {
            if (this.Figures.Count != 0) this.Figures.ForEach(fig => Console.WriteLine(fig)); // Выполняется, только если лист фигур не пуст
        }
    }
}
