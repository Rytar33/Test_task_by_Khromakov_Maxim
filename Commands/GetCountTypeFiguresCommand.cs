using System;
using System.Collections.Generic;
using System.Linq;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Получение количества фигур </summary>
    public class GetCountTypeFiguresCommand : ICommand
    {
        /// <summary> Лист фигур в оперативной памяти </summary>
        private List<IFigure> Figures = new List<IFigure>();
        /// <summary> Конструктор команды </summary>
        /// <param name="figures">Принимает лист фигур</param>
        public GetCountTypeFiguresCommand(List<IFigure> figures) => Figures = figures;
        public string Name => "GetCountTypeFigures";
        /// <summary> Выполнение команды "Получение количества фигур" </summary>
        public async void Execute(string data = null)
        {
            List<string> namedFigure = new List<string>();
            this.Figures.ForEach(figures => namedFigure.Add(figures.Name)); // Добавление в новый лист, название всех типов фигуры которые встречаются
            var count = namedFigure.GroupBy(e => e); // Группировка названий фигур которые встречаются в листе
            foreach (var figure in count) 
            {
                Console.WriteLine($"Количество {figure.Key}`s => {figure.Count()}");
            }
        }
    }
}
