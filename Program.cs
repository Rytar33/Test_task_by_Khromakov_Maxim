using System;
using System.Threading;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Program
    {
        static void Main()
        {
            Log();
            Write("Loading");
            bool isMainMenu = true;
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
            do
            {
                Clear();
                bool isCreateFigure = true, isPrintFigure = true, isChangeFigure = true;
                string[] namedAllSize = { "LS", "RS", "BS", "HZ", "VC", "AS", "R" }; // Запись в начало укороченное название всех фигур 
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
                            Enter("тип фигуры какой вы бы хотели создать", true);
                            string createChoise = ReadLine();
                            switch (createChoise)
                            {
                                case "1": // Создание Треугольника
                                    do
                                    {
                                        Clear();
                                        Log("Succses");
                                        Write("Вы выбрали треугольник.\n");
                                        Thread.Sleep(400);
                                        double a, b, c;
                                        try
                                        {
                                            Enter("размер левой стороны");
                                            a = Convert.ToDouble(ReadLine());
                                            Enter("размер правой стороны");
                                            b = Convert.ToDouble(ReadLine());
                                            Enter("размер основания");
                                            c = Convert.ToDouble(ReadLine());
                                        }
                                        catch (Exception) // Если введена строка, то выдаёт ошибку и возвращает заново переписывать
                                        {
                                            ClickToContinue(typeLog: "Error", anotherText: "Вы ввели НЕ числовое значение! ");
                                            continue;
                                            throw;
                                        }
                                        if (a <= 0 || b <= 0 || c <= 0)
                                        {
                                            LessThanOrEqualToZero();
                                            continue;
                                        }
                                        else
                                        {
                                            double[] sizeTrinagle = { a, b, c };
                                            string[] shortNameSide = { namedAllSize[0], namedAllSize[1], namedAllSize[2] };
                                            int ID = new WriteInformation()
                                                .PutEnd("figures.txt", "Trinagle", sizeTrinagle, shortNameSide);
                                            new Trinagle(a, b, c)
                                                .PrintFigure(ID);
                                            ClickToContinue(isCreateFigure, "Succses");
                                        }

                                    } while (isCreateFigure);
                                    break;
                                case "2": // Создание квадрата
                                    do
                                    {
                                        Clear();
                                        Log("Succses");
                                        Write("Вы выбрали квадрат.\n");
                                        Thread.Sleep(400);
                                        double size;
                                        try
                                        {
                                            Enter("размер всех 4-х сторон");
                                            size = Convert.ToDouble(ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            ClickToContinue(typeLog: "Error", anotherText: "Вы ввели НЕ числовое значение! ");
                                            continue;
                                            throw;
                                        }
                                        if (size <= 0)
                                        {
                                            LessThanOrEqualToZero();
                                            continue;
                                        }
                                        else
                                        {
                                            double[] sizeSquare = { size };
                                            string[] shortNameSide = { namedAllSize[5] };
                                            int ID = new WriteInformation()
                                                .PutEnd("figures.txt", "Square", sizeSquare, shortNameSide);
                                            new Square(size)
                                                .PrintFigure(ID);
                                            ClickToContinue(isCreateFigure, "Succses");
                                        }
                                    } while (isCreateFigure);
                                    break;
                                case "3": // Создание Прямоугольника
                                    do
                                    {
                                        Clear();
                                        Log("Succses");
                                        Write("Вы выбрали прямоугольник.\n");
                                        Thread.Sleep(400);
                                        double vert, horiz;
                                        try
                                        {
                                            Enter("размер по вертикали");
                                            vert = Convert.ToDouble(ReadLine());
                                            Enter("размер по горизонтали");
                                            horiz = Convert.ToDouble(ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            ClickToContinue(typeLog: "Error", anotherText: "Вы ввели НЕ числовое значение! ");
                                            continue;
                                            throw;
                                        }
                                        if (vert <= 0 || horiz <= 0)
                                        {
                                            LessThanOrEqualToZero();
                                            continue;
                                        }
                                        else if (vert == horiz) // Если равны стороны, то это не прямоугольник, а квадрат
                                        {
                                            WriteLine();
                                            Log("Warning");
                                            Write("Размер по горизонтали и вертикали равны. Вы бы хотели его преобразовать в квадрат?(Да/Нет): ");
                                            string isSquare = ReadLine();
                                            switch (isSquare) // Выбор пользователя "хочет ли он квадрат - или же прямоугольник"
                                            {
                                                case "Да":
                                                    double[] sizeSquare = { vert };
                                                    string[] shortNameSide = { namedAllSize[5] };
                                                    int ID = new WriteInformation()
                                                        .PutEnd("figures.txt", "Square", sizeSquare, shortNameSide);
                                                    new Square(vert)
                                                        .PrintFigure(ID);
                                                    ClickToContinue(isCreateFigure, "Succses");
                                                    break;
                                                case "Нет":
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        else // Если всё нормально, то пользователь получает прямоугольник
                                        {
                                            double[] sizeRectangle = { vert, horiz };
                                            string[] shortNameSide = { namedAllSize[3], namedAllSize[4] };
                                            int ID = new WriteInformation()
                                                .PutEnd("figures.txt", "Rectangle", sizeRectangle, shortNameSide);
                                            new Rectangle(vert, horiz)
                                                .PrintFigure(ID);
                                            ClickToContinue(isCreateFigure, "Succses");
                                        }
                                    } while (isCreateFigure);
                                    break;
                                case "4": // Создание круга
                                    do
                                    {
                                        Clear();
                                        Log("Succses");
                                        Write("Вы выбрали круг.\n");
                                        Thread.Sleep(400);
                                        double radius;
                                        try
                                        {
                                            Enter("радиус круга");
                                            radius = Convert.ToDouble(ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            ClickToContinue(typeLog: "Error", anotherText: "Вы ввели НЕ числовое значение! ");
                                            continue;
                                            throw;
                                        }
                                        if (radius <= 0)
                                        {
                                            LessThanOrEqualToZero();
                                            continue;
                                        }
                                        else
                                        {
                                            double[] sizeRadius = { radius };
                                            string[] shortNameSide = { namedAllSize[6] };
                                            int ID = new WriteInformation()
                                                .PutEnd("figures.txt", "Round", sizeRadius, shortNameSide);
                                            new Round(radius)
                                                .PrintFigure(ID);
                                            ClickToContinue(isCreateFigure, "Succses");
                                        }
                                    } while (isCreateFigure);
                                    break;
                                case "5": // Возвращение назад
                                    isCreateFigure = false;
                                    break;
                                default:
                                    ClickToContinue(typeLog: "Error", anotherText: "Вы ввели неверное значение! ");
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
                                    ClickToContinue(isPrintFigure, "Succses");
                                    break;
                                case "2": // ..типам
                                    Clear();
                                    Enter("тип на английском (Round, Square, Rectangle, Trinagle)", true);
                                    string type = ReadLine();
                                    new WriteInformation().Print("figures.txt", "Type", type);
                                    ClickToContinue(isPrintFigure, "Succses");
                                    break;
                                case "3": // Все
                                    new WriteInformation().Print("figures.txt", "All");
                                    ClickToContinue(isPrintFigure, "Succses");
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
                            Clear();
                            Enter("тип фигуры на который вы бы хотели поменять(по русски)", true);
                            string typeName = ReadLine();
                            switch (typeName)
                            {
                                case "Треугольник":
                                    typeName = "Trinagle";
                                    double[] sizesTrinagle = new double[3];
                                    string[] nameKeyTrinagle = { namedAllSize[2], namedAllSize[1], namedAllSize[0] }; // Выводим всё в обратном порядке, как и с записью
                                    Enter("левую сторону");
                                    sizesTrinagle[2] = double.Parse(ReadLine());
                                    Enter("правую сторону");
                                    sizesTrinagle[1] = double.Parse(ReadLine());
                                    Enter("основание");
                                    sizesTrinagle[0] = double.Parse(ReadLine());
                                    wii.Update("figures.txt", id, typeName, sizesTrinagle, nameKeyTrinagle);
                                    wii.Print("figures.txt", "By ID", $"{id}");
                                    ClickToContinue(isChangeFigure, "Succses");
                                    break;
                                case "Квадрат":
                                    typeName = "Square";
                                    double[] sizesSquare = new double[1];
                                    string[] nameKeySquare = { namedAllSize[5] };
                                    Enter("все 4 стороны");
                                    sizesSquare[0] = double.Parse(ReadLine());
                                    wii.Update("figures.txt", id, typeName, sizesSquare, nameKeySquare);
                                    wii.Print("figures.txt", "By ID", $"{id}");
                                    ClickToContinue(isChangeFigure, "Succses");
                                    break;
                                case "Прямоугольник":
                                    typeName = "Rectangle";
                                    double[] sizesRectangle = new double[2];
                                    string[] nameKeyRectangle = { namedAllSize[4], namedAllSize[3] };
                                    Enter("размер по горизонтали");
                                    sizesRectangle[1] = double.Parse(ReadLine());
                                    Enter("размер по вертикали");
                                    sizesRectangle[0] = double.Parse(ReadLine());
                                    wii.Update("figures.txt", id, typeName, sizesRectangle, nameKeyRectangle);
                                    wii.Print("figures.txt", "By ID", $"{id}");
                                    ClickToContinue(isChangeFigure, "Succses");
                                    break;
                                case "Круг":
                                    typeName = "Round";
                                    double[] sizesRound = new double[1];
                                    string[] nameKeyRound = { namedAllSize[6] };
                                    Enter("окружность");
                                    sizesRound[0] = double.Parse(ReadLine());
                                    wii.Update("figures.txt", id, typeName, sizesRound, nameKeyRound);
                                    wii.Print("figures.txt", "By ID", $"{id}");
                                    ClickToContinue(isChangeFigure, "Succses");
                                    break;
                                default:
                                    ClickToContinue(typeLog: "Error", anotherText: "Вы ввели неверный тип! ");
                                    break;
                            }

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
        static void Enter(string textEnter, bool isTheBeginning = false)
        {
            if (!isTheBeginning) WriteLine();
            Log();
            Write($"Введите {textEnter}: ");
        }
        static void ClickToContinue(bool isWork = false, string typeLog = "", string anotherText = "")
        {
            isWork = false;
            WriteLine();
            Log($"{typeLog}");
            Write($"{anotherText}Нажмите чтобы продолжить: ");
            ReadKey();
        }
        static void LessThanOrEqualToZero()
        {
            // Если меньше или равняется 0 размер стороны фигуры
            WriteLine();
            Log("Error");
            Write("Радиус не может быть равен или быть меньше 0!");
            Thread.Sleep(2000);
        }
        static void Log(string type = "")
        {
            // Логи информации с временем и датой их отправки
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