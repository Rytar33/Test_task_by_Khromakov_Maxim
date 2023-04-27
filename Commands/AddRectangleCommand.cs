using System;
using System.Collections.Generic;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Добавление прямоугольника </summary>
    public class AddRectangleCommand : ICommand
    {
        /// <summary> Лист фигур в оперативной памяти </summary>
        private List<IFigure> Figures = new List<IFigure>();
        /// <summary> Конструктор команды </summary>
        /// <param name="figures">Принимает лист фигур</param>
        public AddRectangleCommand(List<IFigure> figures) => Figures = figures;
        public string Name => "AddRectangle";
        /// <summary> Выполнение команды "Добавление прямоугольника" </summary>
        /// <param name="data">Информация о фигуре</param>
        public async void Execute(string data)
        {
            string[] datas = data.Split(' ');
            var Side = (h: Convert.ToDouble(datas[0]), v: Convert.ToDouble(datas[1]));
            this.Figures.Add(new Rectangle(Side.h, Side.v));
        }
    }
}
