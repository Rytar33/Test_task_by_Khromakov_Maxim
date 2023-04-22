using System;
using System.Collections.Generic;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Обновление информации в фигуре </summary>
    public class UpdateFigureCommand : ICommand
    {
        List<IFigure> Figures = new List<IFigure>();
        public UpdateFigureCommand(List<IFigure> figures) { 
            Figures = figures;
        }
        public string Name => "UpdateFigure";
        /// <summary> Выполнение команды "Обновление информации в фигуре" </summary>
        /// <param name="data">Новая информация о фигуре</param>
        /// <param name="indexFigure">Индекс фигуры</param>
        public async void Execute(string data, int indexFigure)
        {
            string[] side = data.Split(' ');
            List<double> sides = new List<double>();
            foreach (var figure in side)
            {
                if (figure.IndexOf('|') != -1) break; // Если встретиться разделитель между информацией о фигуре и индексом, цикл завершает работу
                sides.Add(Convert.ToDouble(figure));
            }
            AddNewInformationAboutFigure(sides, this.Figures[indexFigure].Name, indexFigure); // Добавление новой информации о фигуре
        }
        /// <summary> Запись фигуры в лист всех фигур в память </summary>
        /// <param name="sides">Лист размера всех вводимых сторон фигуры</param>
        /// <param name="type">Тип фигуры</param>
        /// <param name="index">Индекс фигуры</param>
        private void AddNewInformationAboutFigure(List<double> sides, string type, int index)
        {
            switch (type)
            {
                case "Trinagle":
                    this.Figures[index] = new Trinagle(sides[0], sides[1], sides[2]);
                    break;
                case "Rectangle":
                    this.Figures[index] = new Rectangle(sides[0], sides[1]);
                    break;
                case "Square":
                    this.Figures[index] = new Square(sides[0]);
                    break;
                case "Round":
                    this.Figures[index] = new Round(sides[0]);
                    break;
            }
        }
    }
}
