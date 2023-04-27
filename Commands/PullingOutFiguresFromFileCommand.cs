using System;
using System.Collections.Generic;
using System.IO;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Вытаскивание и запись в лист фигур всей информации из файла о фигурах, которые в нём хранятся </summary>
    public class PullingOutFiguresFromFileCommand : ICommand
    {
        /// <summary> Лист фигур в оперативной памяти </summary>
        private List<IFigure> Figures = new List<IFigure>();
        /// <summary> Конструктор команды </summary>
        /// <param name="figures">Принимает лист фигур</param>
        public PullingOutFiguresFromFileCommand(List<IFigure> figures) => Figures = figures;
        public string Name => "PullingOutFiguresFromFile";
        /// <summary> Выполнение команды "Вытащить и записать в лист фигур из файла" </summary>
        public async void Execute(string data = null)
        {
            Console.Write("Как только вы продолжите, все фигуры удаляться из памяти и заменяться из файла. Продолжить?(Y/N): ");
            if (Console.ReadLine() != "Y") return;
            this.Figures.Clear(); // Очищение памяти фигур
            using StreamReader rd = new StreamReader("figures.txt"); // Читание файла фигур
            string line, type = "", border = "=========="; 
            while ((line = rd.ReadLine()) != null) {
                string[] keyItem = line.Split(": "); // Разделяем строку на ключ и значение
                if (line == border) continue; // Чтобы не было вызова исключения, ставим такую затычку
                else if (line != border) {
                    if (keyItem[0] == "Type") { 
                        // Когда ключ будет "Тип фигуры", то он запоминает тип значения, переходя на следующую строку
                        type = keyItem[1];
                        line = rd.ReadLine();
                        keyItem = line.Split(": ");
                    }
                    
                    List<double> sides = new List<double>();
                    List<string> datas = new List<string>(keyItem[1].Split(' ')); // Разделение значений фигуры
                    datas.ForEach(itemSide => sides.Add(double.Parse(itemSide)));
                    AddFigure(sides, type); // Добавление фигуры в лист
                }
            }
        }
        /// <summary> Запись фигуры в лист всех фигур в память </summary>
        /// <param name="sides">Лист размера всех вводимых сторон фигуры</param>
        /// <param name="type">Тип фигуры</param>
        private void AddFigure(List<double> sides, string type)
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