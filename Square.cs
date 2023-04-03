using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Square : IFigure
    {
        private double SizeOfAllSides { get; set; } // ������ ���� ������ ��������
        public Square(double sizeOfAllSides) => this.SizeOfAllSides = sizeOfAllSides;

        public void PrintFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID ������: {id}\n"
                + "������: �������\n"
                + $"������ ������ �������: {SizeOfAllSides}\n"
                + $"��������: {Math.Round(GetPerimeter(), 2)}\n"
                + $"�������: {Math.Round(GetArea(), 2)}\n"
                + "===============================");
        }
        public double GetArea() => Math.Pow(SizeOfAllSides, 2); // ��������� ������� ��������
        public double GetPerimeter() => SizeOfAllSides * 4; // ��������� ��������� ��������

    }
}