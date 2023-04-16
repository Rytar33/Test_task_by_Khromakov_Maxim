using System;
using System.Threading;
using System.Collections.Generic;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    enum Figures
    {
        Square,
        Rectangle,
        Trinagle,
        Round
    }
    /// <summary>
    /// Основной класс Program, который запускает приложение
    /// </summary>
    class Program
    {
        enum ShortNameFigures { Square_AS, Rectangle_HZ, Rectangle_VC, Trinagle_LS, Trinagle_RS, Trinagle_BS, Round_R }
        static void Main()
        {
            Loading();
            bool isMainMenu = true;
            string file = "figures.txt";
            do
            {
                Clear();
                bool isCreateFigure = true, isPrintFigure = true, isChangeFigure = true;
                //Type figure = Type.GetType("Test_task_by_Khromakov_Maxim." + "Trinagle");
                //if(figure is not null)
                //{
                //    MethodInfo rectangle = figure.GetMethod("PrintFigure", new Type[] { typeof (int) });
                //    string result = rectangle.Invoke(null, new object[] { 4 }).ToString();
                //    WriteLine(result);
                //}
                WriteLine(      "\t\tМеню\n" +
                    "1\t| Создание новой фигуры\t\t |\n" +
                    "2\t| Просмотр текущих фигур\t |\n" +
                    "3\t| Обновление данных списка фигур |\n" +
                    "4\t| Выход из цикла\t\t |\n");
                Write("Выбрать из этого списка: ");
                string choise = ReadLine();
                switch (choise)
                {
                    case "1": // Создание фигуры
                        do
                        {
                            Clear();
                            WriteLine("1) Треугольник\n" + "2) Квадрат\n" + "3) Прямоугольник\n" + "4) Круг\n" + "5) Назад");
                            Enter("тип фигуры какой вы бы хотели создать (на англ)", true);
                            string createChoise = ReadLine();
                            switch (createChoise)
                            {
                                case "Trinagle":
                                case "Round":
                                case "Rectangle":
                                case "Square": // Создание фигур
                                    do
                                    {
                                        Clear();
                                        Log("Succses");
                                        Write($"Вы выбрали {createChoise}.\n");
                                        Thread.Sleep(400);
                                        bool isNotZero = true;
                                        List<double> sizeSide = new List<double>();
                                        string[] shortNameSide;
                                        try
                                        {
                                            shortNameSide = EnterFigure(createChoise, sizeSide);
                                            if (createChoise == "Rectangle" && sizeSide[0] == sizeSide[1]) createChoise = "Square";
                                        }
                                        catch (FormatException) // Если введена строка, то выдаёт ошибку и возвращает заново переписывать
                                        {
                                            ClickToContinue(typeLog: "Error", anotherText: "Вы ввели НЕ числовое значение! ");
                                            continue;
                                            throw;
                                        }
                                        foreach (double item in sizeSide)
                                        {
                                            if (item <= 0)
                                            {
                                                LessThanOrEqualToZero();
                                                isNotZero = false;
                                                break;
                                            }
                                        }
                                        if (isNotZero)
                                        {
                                            int ID = new WriteInformation()
                                                .PutEnd(file, createChoise, sizeSide.ToArray(), shortNameSide);
                                            switch (createChoise)
                                            {
                                                case "Trinagle":
                                                    new Trinagle(sizeSide[0], sizeSide[1], sizeSide[2]).PrintFigure(ID);
                                                    break;
                                                case "Rectangle":
                                                    new Rectangle(sizeSide[0], sizeSide[1]).PrintFigure(ID);
                                                    break;
                                                case "Square":
                                                    new Square(sizeSide[0]).PrintFigure(ID);
                                                    break;
                                                case "Round":
                                                    new Round(sizeSide[0]).PrintFigure(ID);
                                                    break;
                                            }
                                            ClickToContinue(isCreateFigure = false, "Succses", "Фигура успешна создана! ");
                                        }

                                    } while (isCreateFigure);
                                    break;
                                case "5": // Возвращение назад
                                    isCreateFigure = false;
                                    break;
                                default:
                                    ClickToContinue(typeLog: "Error", anotherText: "Вы ввели неверный тип фигуры! ");
                                    break;
                            }
                        } while (isCreateFigure);
                        break;
                    case "2": // Вывод фигур(ы)...
                        do
                        {
                            Clear();
                            WriteLine("1) По ID\n" + "2) По типам(работает с багами)\n" + "3) Все\n" + "4) Назад");
                            Enter("как вы бы хотели вывести фигуры", true);
                            string choiseType = ReadLine();
                            WriteInformation wr = new WriteInformation();
                            string leftText = "";
                            bool error = false;
                            switch (choiseType)
                            {
                                case "1": // ..по ID
                                    Clear();
                                    Enter("ID");
                                    int id;
                                    try
                                    {
                                        id = int.Parse(ReadLine());
                                        if (!wr.IsIDAtFile(file, id))
                                        {
                                            ClickToContinue(typeLog: "Error", anotherText: "Вы ввели несуществующий индентификатор! ");
                                            continue;
                                        }
                                    }
                                    catch (FormatException ex)
                                    {
                                        ClickToContinue(typeLog: "Error", anotherText: $"Вы ввели НЕ числовое значение!({ex.Message}) ");
                                        continue;
                                        throw;
                                    }
                                    wr.Print(file, "By ID", $"{id}");
                                    leftText = "Фигура успешно выведена! ";
                                    break;
                                case "2": // ..по типам
                                    Clear();
                                    string listFigure = string.Join(", ", Enum.GetNames(typeof(Figures)));
                                    Enter($"тип на английском ({listFigure})", true);
                                    string type = ReadLine();
                                    if (!wr.IsType(type))
                                    {
                                        ClickToContinue(typeLog: "Error", anotherText: "Вы ввели несуществующую фигуру! ");
                                        continue;
                                    }
                                    wr.Print(file, "Type", type);
                                    leftText = $"{type}`s успешно выведены! ";
                                    break;
                                case "3": // Все
                                    wr.Print(file, "All");
                                    leftText = "Все фигуры успешно выведены! ";
                                    break;
                                case "4": // Назад
                                    break;
                                default:
                                    ClickToContinue(typeLog: "Error", anotherText: "Вы ввели неверное значение! ");
                                    error = true;
                                    break;
                            }
                            if(!error) isPrintFigure = false;
                            if (!isPrintFigure && choiseType != "4") ClickToContinue(isPrintFigure, "Succses", leftText);
                        } while (isPrintFigure);
                        break;
                    case "3": // Обновление какой то фигуры
                        UpdateFile(file, isChangeFigure);
                        break;
                    case "4": // Выход из меню
                        Clear();
                        isMainMenu = false;
                        break;
                    default:
                        ClickToContinue(typeLog: "Error", anotherText: "Вы ввели неверное значение! ");
                        break;
                }
            } while (isMainMenu);
            Log();
            WriteLine("Вы вышли из цикла.");
            Thread.Sleep(500);
            Log();
            Write("Хотите завершить программу(Close/or any symbol), или вернуться назад(Back)?: "); // Завершение работы, или начать сначало
            string closeOrComeBack = ReadLine();
            switch (closeOrComeBack)
            {
                case "Back":
                    Clear();
                    Main();
                    break;
                case "Close":
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        /// <summary> Условная загрузка приложения </summary>
        static void Loading()
        {
            CursorVisible = false;
            Log();
            Write("Loading");
            int i = 0;
            while (i < 3)
            {
                Thread.Sleep(500);
                Write(".");
                i++;
            }
            WriteLine();
            Thread.Sleep(300);
            Log("Succses");
            Write("Loading completed!");
            Thread.Sleep(1500);
            CursorVisible = true;
        }

        /// <summary>
        /// Ввод информации сторон фигур
        /// </summary>
        /// <param name="typeFigure">Тип фигуры</param>
        /// <param name="sizeSides">Стороны фигур</param>
        /// <returns>Возвращает укороченное название сторон в массиве для того, чтобы записать в файл стороны фигуры</returns>
        static string[] EnterFigure(string typeFigure, List<double> sizeSides)
        {
            List<string> longNameSideRu = new();
            switch (typeFigure)
            {
                case "Trinagle":
                    longNameSideRu = new List<string>() { "левую сторону", "правую сторону", "основание" };
                    break;
                case "Square":
                    longNameSideRu = new List<string>() { "размер всех 4-х сторон" };
                    break;
                case "Rectangle":
                    longNameSideRu = new List<string>() { "размер по горизонтали", "размер по вертикале" };
                    break;
                case "Round":
                    longNameSideRu = new List<string>() { "окружность" };
                    break;
                default:
                    ClickToContinue(typeLog: "Error", anotherText: "Вы ввели не существующую фигуру! ");
                    break;
            }
            foreach (string name in longNameSideRu)
            {
                Enter(name);
                sizeSides.Add(double.Parse(ReadLine()));
            }
            return ParseIntoShortName(typeFigure, sizeSides);
        }
        static void UpdateFile(string file, bool cickle)
        {
            do
            {
                Clear();
                WriteInformation wr = new WriteInformation();
                wr.Print(file, "All"); // Предоставление пользователю список фигур, которые он может изменить
                Enter("ID фигуры которую вы бы хотели изменить");
                int id = int.Parse(ReadLine());
                if (!wr.IsIDAtFile(file, id))
                {
                    ClickToContinue(typeLog: "Error", anotherText: "Вы ввели несуществующий индентификатор! ");
                    continue;
                }
                List<double> sizeSides = new List<double>();
                string listFigure = string.Join(", ", Enum.GetNames(typeof(Figures)));
                Enter($"тип фигуры на который вы бы хотели поменять({listFigure})", true);
                string typeName = ReadLine();
                if (!wr.IsType(typeName))
                {
                    ClickToContinue(typeLog: "Error", anotherText: "Вы ввели несуществующую фигуру! ");
                    continue;
                }
                string[] nameKeyFigure = EnterFigure(typeName, sizeSides);
                Clear();
                wr.Update(file, id, typeName, sizeSides, nameKeyFigure);
                wr.Print(file, "By ID", $"{id}");
                ClickToContinue(cickle = false, "Succses", "Фигура успешно обновлена! ");
            } while (cickle);
        }

        /// <summary>
        /// Конвертация в укороченные имена сторон фигур
        /// </summary>
        /// <param name="typeFigure">Тип фигуры</param>
        /// <param name="sizeSides">Стороны фигур</param>
        /// <returns>Возвращает укороченное название сторон в массиве</returns>
        private static string[] ParseIntoShortName(string typeFigure, List<double> sizeSides)
        {
            List<string> shortNameSide = new List<string>();
            if (typeFigure == "Rectangle" && sizeSides[0] == sizeSides[1]) typeFigure = "Square";
            string[] allNameFigures = Enum.GetNames(typeof(ShortNameFigures));
            foreach (string item in allNameFigures)
            {
                string[] splitName = item.Split("_");
                if (splitName[0] == typeFigure) shortNameSide.Add(splitName[1]);
            }
            return shortNameSide.ToArray();
        }
        /// <summary>
        /// Просьба ввода какой либо информации
        /// </summary>
        /// <param name="textEnter">Обязательный параметр, который описывает что нужно ввести</param>
        /// <param name="isTheBeginning">Выбирает делать ли отступ на следующую строку, или же нет (false - да | true - нет) (параметр необязателен)</param>
        static void Enter(string textEnter, bool isTheBeginning = false)
        {
            if (!isTheBeginning) WriteLine();
            Log();
            Write($"Введите {textEnter}: ");
        }
        /// <summary>
        /// Нажмите чтобы продолжить - метод который объявляеться перед очищением консоли. (все параметры необязательные)
        /// </summary>
        /// <param name="isWork">Булевое значение, которое останавливает цикл в приложении</param>
        /// <param name="typeLog">Тип лога - просто выводит тип лога</param>
        /// <param name="anotherText">Дополнительная информация перед записем в консоль "Нажмите чтобы продолжить: "</param>
        static void ClickToContinue(bool isWork = false, string typeLog = "", string anotherText = "")
        {
            WriteLine();
            Log($"{typeLog}");
            Write($"{anotherText}Нажмите чтобы продолжить: ");
            ReadKey();
        }
        /// <summary>
        /// Меньше или равно 0. Выводится когда одна из сторон фигур уходит в 0 и меньше
        /// </summary>
        static void LessThanOrEqualToZero()
        {
            WriteLine();
            Log("Error");
            Write("Сторона фигуры не может быть равна или быть меньше 0!");
            Thread.Sleep(2000);
        }
        /// <summary>
        /// Логирование - когда была отправлена та или инная информация в консоль, с отчётом датой и временем вплоть до секунд
        /// </summary>
        /// <param name="type">Тип логов - необязательный параметр который окрашивает логирование в определённый цвет под разные типы: (стандартный - серый; Error - красный; Warning - желтый; Succses - зелёный)</param>
        static void Log(string type = "")
        {
            var getForegroundColor = type switch
            {
                "Error" => ForegroundColor = ConsoleColor.Red,
                "Warning" => ForegroundColor = ConsoleColor.Yellow,
                "Succses" => ForegroundColor = ConsoleColor.Green,
                _ => ForegroundColor = ConsoleColor.DarkGray
            };
            Write($"[{DateTime.Now}]");
            ForegroundColor = ConsoleColor.White;
            Write(": ");
        }
    }
}