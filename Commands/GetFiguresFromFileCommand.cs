using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    public class GetFiguresFromFileCommand : ICommand
    {
        List<IFigure> Figures = new List<IFigure>();
        public GetFiguresFromFileCommand(List<IFigure> figures)
        {
            Figures = figures;
        }
        public string Name => "GetFiguresFromFile()";
        public async void Execute(string data = "", int indexFigure = -1)
        {
            Console.Write("Как только вы продолжите, все фигуры удаляться из ОЗУ и заменяться из файла. Продолжить?(Y/N): ");
            if (Console.ReadLine() != "Y") return;
            this.Figures.Clear();
            using StreamReader rd = new StreamReader("figures.txt");
            string line, type = "", border = "==========";
            while ((line = rd.ReadLine()) != null)
            {
                string[] keyItem = line.Split(": ");
                if (line == border) continue; // Чтобы не было вызова ошибки, ставим такую затычку
                else if (line != border)
                {
                    if (keyItem[0] == "Type") {
                        type = keyItem[1];
                        line = rd.ReadLine();
                        keyItem = line.Split(": ");
                    } 
                    List<double> sides = new List<double>();
                    string[] datas = keyItem[1].Split(' ');
                    foreach (string s in datas)
                    {
                        sides.Add(double.Parse(s));
                    }
                    PrintFigure(sides, type);
                }
            }
        }
        private void PrintFigure(List<double> sides, string type)
        {
            switch (type)
            {
                case "Trinagle":
                    this.Figures.Add(new Trinagle(sides[0], sides[1], sides[2]));
                    break;
                case "Rectangle":
                    this.Figures.Add(new Rectangle(sides[0], sides[1]));
                    break;
                case "Square":
                    this.Figures.Add(new Square(sides[0]));
                    break;
                case "Round":
                    this.Figures.Add(new Round(sides[0]));
                    break;
            }
        }
    }
}
