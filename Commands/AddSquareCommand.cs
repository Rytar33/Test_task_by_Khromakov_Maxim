using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    public class AddSquareCommand : ICommand
    {
        private List<IFigure> Figures = new List<IFigure>();
        public AddSquareCommand(List<IFigure> figures) {
            Figures = figures;
        }
        public string Name => "AddSquare";

        public async void Execute(string data, int indexFigure = -1)
        {
            var EverySide = Convert.ToDouble(data);
            this.Figures.Add(new Square(EverySide));
        }
    }
}
