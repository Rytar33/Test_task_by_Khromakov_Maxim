namespace Test_task_by_Khromakov_Maxim.Commands
{
    /// <summary> Интерфейс команды </summary>
    public interface ICommand
    {
        /// <summary> Название команды </summary>
        string Name { get; }
        /// <summary> Метод выполнения команды </summary>
        /// <param name="data">Стороны фигуры</param>
        void Execute(string data = "");
    }
}
