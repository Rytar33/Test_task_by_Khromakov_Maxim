using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    public class AddRoundCommand : ICommand
    {
        private List<IFigure> Figures = new List<IFigure>();
        public AddRoundCommand(List<IFigure> figures) {
            Figures = figures;
        }
        public string Name => "AddRound";

        public async void Execute(string data, int indexFigure = -1)
        {
            var Radius = Convert.ToDouble(data);
            this.Figures.Add(new Round(Radius));
        }
    }
}
