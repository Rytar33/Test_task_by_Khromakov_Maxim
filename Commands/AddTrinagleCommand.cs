using System;
using System.Collections.Generic;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Добавление треугольника </summary>
    public class AddTrinagleCommand : ICommand
    {
        /// <summary> Лист фигур в оперативной памяти </summary>
        private List<IFigure> Figures = new List<IFigure>();
        /// <summary> Конструктор команды </summary>
        /// <param name="figures">Принимает лист фигур</param>
        public AddTrinagleCommand(List<IFigure> figures) => Figures = figures;
        public string Name => "AddTrinagle";
        /// <summary> Выполнение команды "Добавление треугольника" </summary>
        /// <param name="data">Информация о фигуре</param>
        public async void Execute(string data)
        {
            string[] datas = data.Split(' ');
            var Side = (a: Convert.ToDouble(datas[0]), b: Convert.ToDouble(datas[1]), c: Convert.ToDouble(datas[2]));
            this.Figures.Add(new Trinagle(Side.a, Side.b, Side.c));
        }
    }
}
