using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    public class AddTrinagleCommand : ICommand
    {
        private List<IFigure> Figures = new List<IFigure>();
        public AddTrinagleCommand(List<IFigure> figures) {
            Figures = figures;
        }
        public string Name => "AddTrinagle";

        public async void Execute(string data, int indexFigure = -1)
        {
            string[] datas = data.Split(' ');
            var Side = (a: Convert.ToDouble(datas[0]), b: Convert.ToDouble(datas[1]), c: Convert.ToDouble(datas[2]));
            this.Figures.Add(new Trinagle(Side.a, Side.b, Side.c));
        }
    }
}
