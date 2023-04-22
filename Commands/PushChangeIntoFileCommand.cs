using System;
using System.Collections.Generic;
using System.IO;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Сохранить изменение в файл о фигурах </summary>
    public class PushChangeIntoFileCommand : ICommand
    {
        List<IFigure> Figures = new List<IFigure>();
        public PushChangeIntoFileCommand(List<IFigure> figures) {
            Figures = figures;
        }
        public string Name => "PushChangeIntoFile()";
        /// <summary> Выполнение команды "Сохранить изменения в файл" </summary>
        public async void Execute(string data = "", int indexFigure = -1)
        {
            Console.Write("Как только вы продолжите, все фигуры удаляться из файла и заменяться из памяти в файле. Продолжить?(Y/N): ");
            if (Console.ReadLine() != "Y") return;
            using (StreamWriter wr = new StreamWriter("figures.txt", false)) // Запись в файл
            {
                string border = "=========="; // Граница между фигурами
                foreach (var figures in this.Figures)
                {
                    wr.WriteLine(border);
                    wr.WriteLine($"Type: {figures.Name}");
                    wr.WriteLine($"Side data: {figures.Data}");
                    wr.WriteLine(border);
                }
            }
        }
    }
}
