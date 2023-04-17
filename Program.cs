using System;
using System.Threading;
using System.Collections.Generic;
using static System.Console;
using System.Reflection;

namespace Test_task_by_Khromakov_Maxim
{
    enum Figures
    {
        Square,
        Rectangle,
        Trinagle,
        Round
    }
    enum ShortNameFigures
    { 
        Square_AS,
        Rectangle_HZ,
        Rectangle_VC,
        Trinagle_LS,
        Trinagle_RS,
        Trinagle_BS,
        Round_R
    }
    /// <summary>
    /// Основной класс Program, который запускает приложение
    /// </summary>
    class Program
    {
        static void Main() {
            //Type figure = Type.GetType("Test_task_by_Khromakov_Maxim." + "IFigure");
            //if (figure is not null)
            //{
            //    MethodInfo rectangle = figure.GetMethod("PrintFigure", new Type[] { typeof(int) });
            //    string result = rectangle.Invoke(null, new object[] { 4 }).ToString();
            //    WriteLine(result);
            //}
            Loading();
            bool isMainMenu = true;
            string file = "figures.txt";
            do {
                Clear();
                PrintMenu(new string[] { "Создание новой фигуры", "Просмотр текущих фигур", "Обновление данных списка фигур", "Выход из цикла" }, true);
                WriteLine();
                Log();
                Write("Выбрать из этого списка: ");
                string choise = ReadLine();
                switch (choise) {
                    case "1": // Создание фигуры
                        CreateFigure(file);
                        break;
                    case "2": // Вывод фигур(ы)...
                        PrintFigure(file);
                        break;
                    case "3": // Обновление какой то фигуры
                        UpdateFile(file);
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
            if(closeOrComeBack == "Back") {
                Clear();
                Main();
            }
        }
        /// <summary> Условная загрузка приложения </summary>
        static void Loading()
        {
            CursorVisible = false;
            Log();
            Write("Loading");
            int i = 0;
            while (i < 3) {
                Thread.Sleep(500);
                Write(".");
                i++;
            }
            WriteLine();
            Thread.Sleep(300);
            Title = "Figure management system";
            Log("Succses");
            Write("Loading completed!");
            Thread.Sleep(1500);
            CursorVisible = true;
        }
        /// <summary>
        /// Метод, который показывает по индентификатору фигуру
        /// </summary>
        /// <param name="fi">Вызов класса File Interaction</param>
        /// <returns>Возвращает текст, который выводит текст с успешным завершением цикла</returns>
        static string FigureIDShow(FileInteraction fi)
        {
            Enter("ID");
            int id = -1;
            try {
                id = int.Parse(ReadLine());
                if (!fi.IsIDAtFile(id)) {
                    ClickToContinue(typeLog: "Error", anotherText: "Вы ввели несуществующий индентификатор! ");
                    return "";
                }
            }
            catch (FormatException) {
                ClickToContinue(typeLog: "Error", anotherText: "Вы ввели НЕ числовое значение! ");
                return "";
            }
            fi.Print("By ID", $"{id}");
            return "Фигура успешно выведена! ";
        }
        /// <summary>
        /// Метод, который показывает по типу фигуры все фигуры
        /// </summary>
        /// <param name="fi">Вызов класса File Interaction</param>
        /// <returns>Возвращает текст, который выводит текст с успешным завершением цикла</returns>
        static string FigureTypeShow(FileInteraction fi) {
            string listFigure = string.Join(", ", Enum.GetNames(typeof(Figures)));
            Enter($"тип на английском ({listFigure})", true);
            string type = ReadLine();
            if (!fi.IsType(type)) {
                ClickToContinue(typeLog: "Error", anotherText: "Вы ввели несуществующую фигуру! ");
                return "";
            }
            fi.Print("Type", type);
            return $"{type}`s успешно выведены! ";
        }
        /// <summary>
        /// Ввод информации сторон фигур
        /// </summary>
        /// <param name="typeFigure">Тип фигуры</param>
        /// <param name="sizeSides">Стороны фигур</param>
        /// <returns>Возвращает укороченное название сторон в массиве для того, чтобы записать в файл стороны фигуры</returns>
        static string[] EnterFigure(string typeFigure, List<double> sizeSides) {
            List<string> longNameSideRu = null;
            switch (typeFigure) {
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
            foreach (string name in longNameSideRu) {
                Enter(name);
                sizeSides.Add(double.Parse(ReadLine()));
            }
            return ParseIntoShortName(typeFigure, sizeSides);
        }
        /// <summary>
        /// Метод который создаёт фигуру
        /// </summary>
        /// <param name="file">Ссылка на файл с "базой данных" фигур</param>
        static void CreateFigure(string file)
        {
            bool isCreateFigure = true;
            do {
                Clear();
                List<string> listFigure = new List<string>(Enum.GetNames(typeof(Figures)));
                listFigure.Add("Назад");
                PrintMenu(listFigure.ToArray());
                Enter("тип фигуры какой вы бы хотели создать (полное название)", true);
                string createChoise = ReadLine();
                switch (createChoise) {
                    case "Trinagle":
                    case "Round":
                    case "Rectangle":
                    case "Square": // Создание фигур
                        do {
                            Clear();
                            Log("Succses");
                            Write($"Вы выбрали {createChoise}.\n");
                            Thread.Sleep(400);
                            List<double> sizeSide = new List<double>();
                            string[] shortNameSide;
                            try {
                                shortNameSide = EnterFigure(createChoise, sizeSide);
                                if (createChoise == "Rectangle" && sizeSide[0] == sizeSide[1]) createChoise = "Square";
                            }
                            catch (FormatException) { // Если введена строка, то выдаёт ошибку и возвращает заново переписывать
                                ClickToContinue(typeLog: "Error", anotherText: "Вы ввели НЕ числовое значение! ");
                                continue;
                            }
                            if (LessThanOrEqualToZero(sizeSide)) {
                                int ID = new FileInteraction(file)
                                    .PutEnd(createChoise, sizeSide.ToArray(), shortNameSide);
                                IFigure figure = createChoise switch {
                                    "Trinagle" => new Trinagle(sizeSide[0], sizeSide[1], sizeSide[2]),
                                    "Rectangle" => new Rectangle(sizeSide[0], sizeSide[1]),
                                    "Square" => new Square(sizeSide[0]),
                                    "Round" => new Round(sizeSide[0]),
                                    _ => null
                                };
                                figure?.PrintFigure(ID);
                                ClickToContinue(isCreateFigure = false, "Succses", "Фигура успешна создана! ");
                            }
                        } while (isCreateFigure);
                        break;
                    case "Назад": // Возвращение назад
                        isCreateFigure = false;
                        break;
                    default:
                        ClickToContinue(typeLog: "Error", anotherText: "Вы ввели неверный тип фигуры! ");
                        break;
                }
            } while (isCreateFigure);
        }
        /// <summary>
        /// Метод, который распечатывает фигуры, и их информацию
        /// </summary>
        /// <param name="file">Ссылка на файл с "базой данных" фигур</param>
        static void PrintFigure(string file) {
            bool isPrintFigure = true;
            do {
                Clear();
                PrintMenu(new string[] { "По ID", "По типам фигур(работает с багами)", "Все", "Назад" });
                Enter("как вы бы хотели вывести фигуры", true);
                string leftText = "", choiseType = ReadLine();
                FileInteraction fi = new FileInteraction(file);
                bool error = false;
                Clear();
                switch (choiseType) {
                    case "1": // ..по ID
                        leftText = FigureIDShow(fi);
                        break;
                    case "2": // ..по типам
                        leftText = FigureTypeShow(fi);
                        break;
                    case "3": // Все
                        fi.Print("All");
                        leftText = "Все фигуры успешно выведены! ";
                        break;
                    case "4": // Назад
                        isPrintFigure = false;
                        break;
                    default:
                        ClickToContinue(typeLog: "Error", anotherText: "Вы ввели неверное значение! ");
                        error = true;
                        break;
                }
                if (!error && leftText.Length != 0) isPrintFigure = false;
                if (!isPrintFigure && choiseType != "4") ClickToContinue(isPrintFigure, "Succses", leftText);
            } while (isPrintFigure);
        }
        /// <summary>
        /// Метод который обновляет фигуру по индентификатору
        /// </summary>
        /// <param name="file">Ссылка на файл с "базой данных" фигур</param>
        static void UpdateFile(string file) {
            bool isChangeFigure = true;
            do {
                Clear();
                FileInteraction fi = new FileInteraction(file);
                fi.Print("All"); // Предоставление пользователю список фигур, которые он может изменить
                Enter("ID фигуры которую вы бы хотели изменить");
                int id = -1;
                try {
                    id = int.Parse(ReadLine());
                    if (!fi.IsIDAtFile(id)) {
                        ClickToContinue(typeLog: "Error", anotherText: "Вы ввели несуществующий индентификатор! ");
                        continue;
                    }
                }
                catch (FormatException) { // Если введена строка, то выдаёт ошибку и возвращает заново переписывать
                    ClickToContinue(typeLog: "Error", anotherText: "Вы ввели НЕ числовое значение! ");
                    continue;
                }
                List<double> sizeSides = new List<double>();
                string listFigure = string.Join(", ", Enum.GetNames(typeof(Figures)));
                Enter($"тип фигуры на который вы бы хотели поменять({listFigure})", true);
                string typeName = ReadLine();
                if (!fi.IsType(typeName)) {
                    ClickToContinue(typeLog: "Error", anotherText: "Вы ввели несуществующую фигуру! ");
                    continue;
                }
                string[] nameKeyFigure = EnterFigure(typeName, sizeSides);
                if(LessThanOrEqualToZero(sizeSides)) {
                    Clear();
                    fi.Update(id, typeName, sizeSides, nameKeyFigure);
                    fi.Print("By ID", $"{id}");
                    ClickToContinue(isChangeFigure = false, "Succses", "Фигура успешно обновлена! ");
                }
            } while (isChangeFigure);
        }
        /// <summary>
        /// Метод который выводит в консоль меню
        /// </summary>
        /// <param name="menuList">Массив строк, благодаря которому по каждому индексу выводит меню</param>
        /// <param name="isMainMenu">Необязатаельный параметр, который проверяет, является ли меню основным</param>
        static void PrintMenu(string[] menuList, bool isMainMenu = false)
        {
            if (isMainMenu) {
                WriteLine("\t\tМеню");
                menuList = AlignBorderAcrossColumns(menuList);
            }
            for (int i = 0; i < menuList.Length; i++)
            {
                if (!isMainMenu) WriteLine($"{i + 1}) {menuList[i]}");
                else WriteLine($"{i + 1}\t| {menuList[i]} |");
            }
        }
        /// <summary>
        /// Метод, который перерабатывает столбцы и выравнивает их отступы от самой длинной строки
        /// </summary>
        /// <param name="anyListInf">Строки с каким либо текстом</param>
        /// <returns>Возвращает переработанный строковый массив</returns>
        private static string[] AlignBorderAcrossColumns(string[] anyListInf)
        {
            string maxLengthLine = "";
            for (int i = 0; i < anyListInf.Length; i++)
            {
                if (anyListInf[i].Length >= maxLengthLine.Length) maxLengthLine = anyListInf[i];
            }
            for (int i = 0; i < anyListInf.Length; i++)
            {
                if (anyListInf[i].Length < maxLengthLine.Length)
                {
                    int resultProbel = maxLengthLine.Length - anyListInf[i].Length;
                    while (resultProbel > 0)
                    {
                        anyListInf[i] += ' ';
                        resultProbel--;
                    }
                }
            }
            return anyListInf;
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
        static bool LessThanOrEqualToZero(List<double> sizeSides)
        {
            foreach (double item in sizeSides)
            {
                if (item <= 0)
                {
                    ClickToContinue(typeLog: "Error", anotherText: "Сторона фигуры не может быть равна или быть меньше 0! ");
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Логирование - когда была отправлена та или инная информация в консоль, с отчётом датой и временем вплоть до секунд
        /// </summary>
        /// <param name="type">Тип логов - необязательный параметр который окрашивает логирование в определённый цвет под разные типы: (стандартный - серый; Error - красный; Warning - желтый; Succses - зелёный)</param>
        static void Log(string type = "")
        {
            var getForegroundColor = type switch {
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