using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    public class GetCountTypeFiguresCommand : ICommand
    {
        List<IFigure> Figures = new List<IFigure>();
        public GetCountTypeFiguresCommand(List<IFigure> figures) {
            Figures = figures;
        }
        public string Name => "GetCountTypeFigures()";
        
        public async void Execute(string data = "", int indexFigure = -1)
        {
            List<string> namedFigure = new List<string>();
            foreach (var figures in this.Figures)
            {
                namedFigure.Add(figures.Name);
            }
            var count = namedFigure.GroupBy(e => e);
            foreach (var figure in count) 
            {
                Console.WriteLine($"Количество {figure.Key}`s => {figure.Count()}");
            }
        }
    }
}
