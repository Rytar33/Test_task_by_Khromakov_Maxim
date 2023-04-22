using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_task_by_Khromakov_Maxim.Commands;
using Test_task_by_Khromakov_Maxim.Figures;
using static System.Net.Mime.MediaTypeNames;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary>
    /// Приложение
    /// </summary>
    public class App
    {
        /// <summary>
        /// Список фигур
        /// </summary>
        private List<IFigure> Figures = new List<IFigure>();
        /// <summary>
        /// Список команд для нашего консольного приложения
        /// </summary>
        private List<ICommand> Commands = new List<ICommand>();
        /// <summary>
        /// Конструктор который хранит в себе все доступные команды
        /// </summary>
        public App() {
            Commands.Add(new AddTrinagleCommand(this.Figures));
            Commands.Add(new AddRectangleCommand(this.Figures));
            Commands.Add(new AddRoundCommand(this.Figures));
            Commands.Add(new AddSquareCommand(this.Figures));
            Commands.Add(new GetAllFigureCommand(this.Figures));
            Commands.Add(new GetCountTypeFiguresCommand(this.Figures));
            Commands.Add(new GetFiguresFromFileCommand(this.Figures));
            Commands.Add(new PushChangeIntoFileCommand(this.Figures));
            Commands.Add(new UpdateFigureCommand(this.Figures));
        }
        /// <summary>
        /// Метод который запускает приложение в бесконечный цикл
        /// </summary>
        public void Run()
        {
            do
            {
                Console.Clear();
                var command = EnterCommand();
                Commands.FirstOrDefault(com => com.Name == command.nameCommand)?.Execute(command.data, command.index);
                Console.Write("Нажмите чтобы продолжить: ");
                Console.ReadKey();
            } while(true);
        }
        /// <summary>
        /// Метод благодаря которому вводим команду
        /// </summary>
        /// <returns>Возвращает: Имя команды, стороны фигуры, индекс фигуры</returns>
        private (string nameCommand, string data, int index) EnterCommand()
        {
            var text = Console.ReadLine();
            if (text[^2] == '(' && text[^1] == ')') return (nameCommand: text, data: "", index: -1);
            string[] textSp = text.Split(": ");
            if (text.IndexOf('|') == -1) {
                var KeyAndValue = (name: textSp[0], data: textSp[1]);
                return (nameCommand: KeyAndValue.name, data: KeyAndValue.data, index: -1);
            }
            var KeyValueInd = (name: textSp[0], data: textSp[1], index: textSp[1].Split(" | ")[1]);
            return (nameCommand: KeyValueInd.name, data: KeyValueInd.data, index: int.Parse(KeyValueInd.index));
        }
    }
}
