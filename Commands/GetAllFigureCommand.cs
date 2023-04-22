using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    public class GetAllFigureCommand : ICommand
    {
        private List<IFigure> Figures = new List<IFigure>();
        public GetAllFigureCommand(List<IFigure> figures) {
            Figures = figures;
        }
        public string Name => "GetAllFigure()";
        public async void Execute(string data = "", int indexFigure = -1)
        {
            if (this.Figures.Count != 0)
            {
                foreach (var item in this.Figures)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
