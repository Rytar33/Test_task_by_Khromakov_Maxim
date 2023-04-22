using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    public class UpdateFigureCommand : ICommand
    {
        List<IFigure> Figures = new List<IFigure>();
        public UpdateFigureCommand(List<IFigure> figures) { 
            Figures = figures;
        }
        public string Name => "UpdateFigure";
        public async void Execute(string data, int indexFigure)
        {
            string[] side = data.Split(' ');
            List<double> sides = new List<double>();
            foreach (var figure in side)
            {
                if (figure.IndexOf('|') != -1) break;
                sides.Add(Convert.ToDouble(figure));
            }
            PrintFigure(sides, this.Figures[indexFigure].Name, indexFigure);
        }
        private void PrintFigure(List<double> sides, string type, int index)
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
