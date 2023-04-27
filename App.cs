using System;
using System.Collections.Generic;
using System.Linq;
using Test_task_by_Khromakov_Maxim.Commands;
using Test_task_by_Khromakov_Maxim.Figures;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary> Приложение </summary>
    public class App
    {
        /// <summary> Список фигур </summary>
        private List<IFigure> Figures = new List<IFigure>();
        /// <summary> Список команд для нашего консольного приложения </summary>
        private List<ICommand> Commands = new List<ICommand>();
        /// <summary> Конструктор который хранит в себе все доступные команды </summary>
        public App() {
            Commands.Add(new AddTrinagleCommand(this.Figures));
            Commands.Add(new AddRectangleCommand(this.Figures));
            Commands.Add(new AddRoundCommand(this.Figures));
            Commands.Add(new AddSquareCommand(this.Figures));
            Commands.Add(new GetAllFigureCommand(this.Figures));
            Commands.Add(new GetCountTypeFiguresCommand(this.Figures));
            Commands.Add(new PullingOutFiguresFromFileCommand(this.Figures));
            Commands.Add(new PushChangeIntoFileCommand(this.Figures));
            Commands.Add(new UpdateFigureCommand(this.Figures));
        }
        /// <summary> Метод который запускает приложение в бесконечный цикл </summary>
        public void Run() {
            do {
                Console.Clear();
                var command = EnterCommand();
                Commands.FirstOrDefault(com => com.Name == command.nameCommand)?.Execute(command.data);
                Console.Write("Нажмите чтобы продолжить: ");
                Console.ReadKey();
            } while(true);
        }
        /// <summary> Метод благодаря которому вводим команду </summary>
        /// <returns>Возвращает: Имя команды, стороны фигуры, индекс фигуры</returns>
        private (string nameCommand, string data) EnterCommand()
        {
            Console.WriteLine("Введите команду");
            var text = Console.ReadLine();
            if (text[^2] == '(' && text[^1] == ')') { // Метод выполняется когда команда не принимает информацию о фигуре
                text = text.Remove(text.Length - 2);
                return (nameCommand: text, data: null);
            }
            string[] textSp = text.Split(": ");
            var KeyValueInd = (name: textSp[0], data: textSp[1]);
            return (nameCommand: KeyValueInd.name, data: KeyValueInd.data);
        }
    }
}
