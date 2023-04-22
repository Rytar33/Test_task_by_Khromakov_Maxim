using System;
using System.Collections.Generic;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Добавление треугольника </summary>
    public class AddTrinagleCommand : ICommand
    {
        private List<IFigure> Figures = new List<IFigure>();
        public AddTrinagleCommand(List<IFigure> figures) {
            Figures = figures;
        }
        public string Name => "AddTrinagle";
        /// <summary> Выполнение команды "Добавление треугольника" </summary>
        /// <param name="data">Информация о фигуре</param>
        public async void Execute(string data, int indexFigure = -1)
        {
            string[] datas = data.Split(' ');
            var Side = (a: Convert.ToDouble(datas[0]), b: Convert.ToDouble(datas[1]), c: Convert.ToDouble(datas[2]));
            this.Figures.Add(new Trinagle(Side.a, Side.b, Side.c));
        }
    }
}
