using static System.Console;
using System.IO;
using System.Collections.Generic;

namespace Test_task_by_Khromakov_Maxim 
{
    // ������ � ��������� ������ (��, ���������� �� ����)
    class WriteInformation
    {
        // �������� ����� ������ � ����� �����
        public int PutEnd(string path, string typeFigure, double[] sizeSides, string[] nameSides)
        {
            int id = 0;
            using (StreamReader rd = new StreamReader(path)) // ������ �����
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    string[] words = line.Split(": "); // ��������� ������ �� ���� � ��������
                    if (words[0] == "ID")
                    {
                        int newId = int.Parse(words[1]);
                        id = newId; // ���������� ��� ID, ���� �� ����� �� ����������
                    }
                }
            }
            using (StreamWriter wr = new StreamWriter(path, true)) // ������ � ����
            {
                id++; // ����������� ID
                wr.WriteLine("==========");
                wr.WriteLine($"ID: {id}");
                wr.WriteLine($"Type: {typeFigure}");
                for (int i = 0; i < sizeSides.Length; i++)
                {
                    wr.WriteLine($"{nameSides[i]}: {sizeSides[i]}"); // ���������� � ����� �������� ������ ������
                }
                wr.WriteLine("==========");
            }
            return id; //���������� ID, ����� ����� ����� ���� ����� �����������
        }
        // ����� �� ����� ����������
        public void Print(string path, string by, string IDorType)
        {
            List<string> data = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    data.Add(line); // ���������� �� ����� � ���� ��� ����������
                }
            }

            using (StreamReader rd = new StreamReader(path))
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    string[] words = line.Split(": "); // ��������� �� ����� � ��������
                    switch (by)
                    {
                        case "By ID": // ���� �� ID
                            if (words[0] == "ID")
                            {
                                int ID = int.Parse(words[1]);
                                int searchByID = int.Parse(IDorType);
                                if (ID == searchByID)
                                {
                                    int indID = 0;
                                    for (int i = 0; i < data.Count; i++)
                                    {
                                        string[] splWords = data[i].Split(": ");
                                        if (data[i] == "==========") continue;
                                        if (IDorType == splWords[1] && splWords[0] == "ID") // ������� ��� ID ������� �� ������
                                        {
                                            indID = i; // � ������ ����������, ���������� � ��������� �������
                                            break;
                                        }
                                    }
                                    string[] typeName = data[indID + 1].Split(": "); // ��������� ������� ���� ��� ������ � ID ������
                                    List<double> infSide = new List<double>();
                                    for (int ind = indID + 2; data[ind] != "=========="; ind++)
                                    {
                                        string[] sides = data[ind].Split(": ");
                                        infSide.Add(double.Parse(sides[1])); // ��������� � ���� ����������
                                        if (data[ind + 1] == "==========")
                                        {
                                            //var result = typeName[1] switch
                                            //{
                                            //    "Trinagle" => new Trinagle(infSide[0], infSide[1], infSide[2]).PrintFigure(searchByID),
                                            //    "Square" => new Square(infSide[0]).PrintFigure(searchByID),
                                            //    "Rectangle" => new Rectangle(infSide[0], infSide[1]).PrintFigure(searchByID),
                                            //    "Round" => new Round(infSide[0]).PrintFigure(searchByID),
                                            //    _ => throw new System.Exception("��")
                                            //};
                                            switch (typeName[1])
                                            {
                                                case "Trinagle":
                                                    new Trinagle(infSide[0], infSide[1], infSide[2])
                                                        .PrintFigure(searchByID);
                                                    break;
                                                case "Square":
                                                    new Square(infSide[0])
                                                        .PrintFigure(searchByID);
                                                    break;
                                                case "Rectangle":
                                                    new Rectangle(infSide[0], infSide[1])
                                                        .PrintFigure(searchByID);
                                                    break;
                                                case "Round":
                                                    new Round(infSide[0])
                                                        .PrintFigure(searchByID);
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "Type": // ����� �� ���� ������
                            if (words[0] == "Type")
                            {
                                if (words[1] == IDorType)
                                {
                                    int id = 0;
                                    int countFigure = 0;
                                    while ((line = rd.ReadLine()) != null)
                                    {
                                        string[] keyItem = line.Split(": ");
                                        if (line == "==========") continue;
                                        else if (keyItem[0] == "ID") id = int.Parse(keyItem[1]);
                                        else if (keyItem[0] == "Type" && keyItem[1] == IDorType)
                                        {
                                            line = rd.ReadLine();
                                            keyItem = line.Split(": ");
                                            switch (IDorType)
                                            {
                                                case "Square":
                                                    double size = double.Parse(keyItem[1]);
                                                    new Square(size)
                                                        .PrintFigure(id);
                                                    countFigure++;
                                                    break;
                                                case "Rectangle":
                                                    double sizeHz = double.Parse(keyItem[1]);
                                                    line = rd.ReadLine();
                                                    keyItem = line.Split(": ");
                                                    double sizeVc = double.Parse(keyItem[1]);
                                                    new Rectangle(sizeHz, sizeVc)
                                                        .PrintFigure(id);
                                                    countFigure++;
                                                    break;
                                                case "Trinagle":
                                                    double sizeR = double.Parse(keyItem[1]);
                                                    line = rd.ReadLine();
                                                    keyItem = line.Split(": ");
                                                    double sizeL = double.Parse(keyItem[1]);
                                                    line = rd.ReadLine();
                                                    keyItem = line.Split(": ");
                                                    double sizeB = double.Parse(keyItem[1]);
                                                    new Trinagle(sizeR, sizeL, sizeB)
                                                        .PrintFigure(id);
                                                    countFigure++;
                                                    break;
                                                case "Round":
                                                    double radius = double.Parse(keyItem[1]);
                                                    new Round(radius)
                                                        .PrintFigure(id);
                                                    countFigure++;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                    WriteLine($"Count {IDorType}'s: {countFigure}");
                                }
                            }
                            break;
                        default:
                            WriteLine("����� �������� ���!");
                            ReadKey();
                            break;
                    }
                }
            }
        }
        public void Print(string path, string by) // ���������� ������ ������, ������� ������� �� �� �����
        {
            using (StreamReader rd = new StreamReader(path))
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    switch (by)
                    {
                        case "All": // ����� �����
                            int Id = 0;
                            string type = "";
                            int[] countFigures = new int[4];
                            while ((line = rd.ReadLine()) != null)
                            {
                                string[] keyItem = line.Split(": ");
                                if (line == "==========") continue; // ����� �� ���� ������ ������, ������ ����� �������
                                else if (keyItem[0] == "ID") Id = int.Parse(keyItem[1]); // ���������� ������ ��� ID
                                else if (keyItem[0] == "Type") type = keyItem[1]; // ��� �� � ��� ������
                                else if (line != "==========")
                                {
                                    //for (int i = 0; line != "=========="; i++)
                                    //{
                                    //    double[] sides = 
                                    //    if(i == 0)
                                    //    {

                                    //        continue;
                                    //    }
                                    //}
                                    switch (type)
                                    {
                                        case "Square":
                                            double size = double.Parse(keyItem[1]);
                                            new Square(size)
                                                .PrintFigure(Id);
                                            countFigures[0]++;
                                            break;
                                        case "Rectangle":
                                            double sizeHz = double.Parse(keyItem[1]);
                                            line = rd.ReadLine(); // ������� �� ��������� ������
                                            keyItem = line.Split(": ");
                                            double sizeVc = double.Parse(keyItem[1]);
                                            new Rectangle(sizeHz, sizeVc)
                                                .PrintFigure(Id);
                                            countFigures[1]++;
                                            break;
                                        case "Trinagle":
                                            double sizeR = double.Parse(keyItem[1]);
                                            line = rd.ReadLine();
                                            keyItem = line.Split(": ");
                                            double sizeL = double.Parse(keyItem[1]);
                                            line = rd.ReadLine();
                                            keyItem = line.Split(": ");
                                            double sizeB = double.Parse(keyItem[1]);
                                            new Trinagle(sizeR, sizeL, sizeB)
                                                .PrintFigure(Id);
                                            countFigures[2]++;
                                            break;
                                        case "Round":
                                            double radius = double.Parse(keyItem[1]);
                                            new Round(radius)
                                                .PrintFigure(Id);
                                            countFigures[3]++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            WriteLine($"���-�� ���������: {countFigures[0]};\n"
                                    + $"���-�� ���������������: {countFigures[1]};\n"
                                    + $"���-�� �������������: {countFigures[2]};\n"
                                    + $"���-�� ������: {countFigures[3]};");
                            break;
                        default:
                            WriteLine("����� �������� ���!");
                            ReadKey();
                            break;
                    }
                }
            }
        }
        public void Update(string path, int ID, string type, double[] newSizeSides, string[] nameKey)
        {
            List<string> data = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    data.Add(line);
                }
            }
            for (int i = 0; i < data.Count; i++)
            {
                string[] keyInf = data[i].Split(": ");
                if (keyInf[0] == "ID" && int.Parse(keyInf[1]) == ID)
                {
                    int next = i;
                    while (data[i] != "==========")
                    {
                        data.RemoveAt(next);

                    }
                    for (int j = 0; j < nameKey.Length; j++)
                    {
                        data.Insert(i, $"{nameKey[j]}: {newSizeSides[j]}");
                    }
                    data.Insert(i, $"Type: {type}");
                    data.Insert(i, $"ID: {ID}");
                    break;
                }
            }
            using (StreamWriter wr = new StreamWriter(path, false))
            {
                for (int i = 0; i < data.Count; i++)
                {
                    wr.WriteLine(data[i]);
                }
            }
        }
    }
}