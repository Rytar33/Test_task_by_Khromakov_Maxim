using System;
using System.Threading;
using System.Collections.Generic;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary>
    /// Основной класс Program, который запускает приложение
    /// </summary>
    class Program
    {
        static void Main()
        {
            Loading();
            bool isMainMenu = true;
            do
            {
                Clear();
                bool isCreateFigure = true, isPrintFigure = true, isChangeFigure = true;
                WriteLine(
                                "\t\tМеню\n" +
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
                                        }
                                        catch (Exception) // Если введена строка, то выдаёт ошибку и возвращает заново переписывать
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
                                            if (createChoise == "Rectangle" && sizeSide[0] == sizeSide[1]) createChoise = "Square";
                                            int ID = new WriteInformation()
                                                .PutEnd("figures.txt", createChoise, sizeSide.ToArray(), shortNameSide);
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
                                                default:
                                                    break;
                                            }
                                            ClickToContinue(isCreateFigure = false, "Succses");
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
                    case "2": // Вывод фигур по...
                        do
                        {
                            Clear();
                            WriteLine("1) По ID\n" + "2) По типам(работает с багами)\n" + "3) Все\n" + "4) Назад");
                            Enter("как вы бы хотели вывести фигуры: ", true);
                            string choiseType = ReadLine();
                            switch (choiseType)
                            {
                                case "1": // ..ID
                                    Clear();
                                    Enter("ID");
                                    int id;
                                    try
                                    {
                                        id = int.Parse(ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        ClickToContinue(typeLog: "Error", anotherText: "Вы ввели НЕ числовое значение! ");
                                        continue;
                                        throw;
                                    }
                                    new WriteInformation().Print("figures.txt", "By ID", $"{id}");
                                    ClickToContinue(isPrintFigure = false, "Succses");
                                    break;
                                case "2": // ..типам
                                    Clear();
                                    Enter("тип на английском (Round, Square, Rectangle, Trinagle)", true);
                                    string type = ReadLine();
                                    new WriteInformation().Print("figures.txt", "Type", type);
                                    ClickToContinue(isPrintFigure = false, "Succses");
                                    break;
                                case "3": // Все
                                    new WriteInformation().Print("figures.txt", "All");
                                    ClickToContinue(isPrintFigure = false, "Succses");
                                    break;
                                case "4": // Назад
                                    isPrintFigure = false;
                                    break;
                                default:
                                    ClickToContinue(typeLog: "Error", anotherText: "Вы ввели неверное значение! ");
                                    break;
                            }
                        } while (isPrintFigure);
                        break;
                    case "3": // Обновление какой то фигуры
                        do
                        {
                            Clear();
                            WriteInformation wii = new WriteInformation();
                            wii.Print("figures.txt", "All"); // Предоставление пользователю список фигур, которые он может изменить
                            Enter("ID фигуры которую вы бы хотели изменить");
                            int id = int.Parse(ReadLine());
                            List<double> sizeSides = new List<double>();
                            Clear();
                            Enter("тип фигуры на который вы бы хотели поменять(по англ)", true);
                            string typeName = ReadLine();
                            string[] nameKeyFigure = EnterFigure(typeName, sizeSides);
                            wii.Update("figures.txt", id, typeName, sizeSides, nameKeyFigure);
                            wii.Print("figures.txt", "By ID", $"{id}");
                            ClickToContinue(isChangeFigure = false, "Succses");

                        } while (isChangeFigure);
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
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        /// <summary> Условная загрузка приложения </summary>
        static void Loading()
        {
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
        }
        /// <summary>
        /// Ввод информации сторон фигур
        /// </summary>
        /// <param name="typeFigure">Тип фигуры</param>
        /// <param name="sizeSides">Стороны фигур</param>
        /// <returns>Возвращает укороченное название сторон в массиве для того, чтобы записать в файл стороны фигуры</returns>
        static string[] EnterFigure(string typeFigure, List<double> sizeSides)
        {
            List<string> shortNameSide = new List<string>();
            switch (typeFigure)
            {
                case "Trinagle":
                    Enter("левую сторону");
                    sizeSides.Add(double.Parse(ReadLine()));
                    shortNameSide.Add("LS");
                    Enter("правую сторону");
                    sizeSides.Add(double.Parse(ReadLine()));
                    shortNameSide.Add("RS");
                    Enter("основание");
                    sizeSides.Add(double.Parse(ReadLine()));
                    shortNameSide.Add("BS");
                    break;
                case "Square":
                    Enter("размер всех 4-х сторон");
                    sizeSides.Add(double.Parse(ReadLine()));
                    shortNameSide.Add("AS");
                    break;
                case "Rectangle":
                    Enter("размер по горизонтали");
                    sizeSides.Add(double.Parse(ReadLine()));
                    Enter("размер по вертикале");
                    sizeSides.Add(double.Parse(ReadLine()));
                    if (sizeSides[0] == sizeSides[1]) shortNameSide.Add("AS");
                    else
                    {
                        shortNameSide.Add("HZ");
                        shortNameSide.Add("VC");
                    }
                    break;
                case "Round":
                    Enter("окружность");
                    sizeSides.Add(double.Parse(ReadLine()));
                    shortNameSide.Add("R");
                    break;
                default:
                    ClickToContinue(typeLog: "Error", anotherText: "Вы ввели не существующую фигуру! ");
                    break;
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