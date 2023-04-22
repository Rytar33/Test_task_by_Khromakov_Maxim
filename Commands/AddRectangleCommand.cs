using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    public class AddRectangleCommand : ICommand
    {
        private List<IFigure> Figures = new List<IFigure>();
        public AddRectangleCommand(List<IFigure> figures) { 
            Figures = figures;
        }
        public string Name => "AddRectangle";

        public async void Execute(string data, int indexFigure = -1)
        {
            string[] datas = data.Split(' ');
            var Side = (h: Convert.ToDouble(datas[0]), v: Convert.ToDouble(datas[1]));
            this.Figures.Add(new Rectangle(Side.h, Side.v));
        }
    }
}
