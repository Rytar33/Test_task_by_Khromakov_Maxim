using System;
using System.Collections.Generic;
using System.IO;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Сохранить изменение в файл о фигурах </summary>
    public class PushChangeIntoFileCommand : ICommand
    {
        /// <summary> Лист фигур в оперативной памяти </summary>
        private List<IFigure> Figures = new List<IFigure>();
        /// <summary> Конструктор команды </summary>
        /// <param name="figures">Принимает лист фигур</param>
        public PushChangeIntoFileCommand(List<IFigure> figures) => Figures = figures;
        public string Name => "PushChangeIntoFile";
        /// <summary> Выполнение команды "Сохранить изменения в файл" </summary>
        public async void Execute(string data = null)
        {
            Console.Write("Как только вы продолжите, все фигуры удаляться из файла и заменяться из памяти в файле. Продолжить?(Y/N): ");
            if (Console.ReadLine() != "Y") return;
            using (StreamWriter wr = new StreamWriter("figures.txt", false)) // Запись в файл
            {
                string border = "=========="; // Граница между фигурами
                this.Figures.ForEach(figures => wr.WriteLine(border + $"\nType: {figures.Name}\n" + $"Side data: {figures.Data}\n" + border));
            }
        }
    }
}
