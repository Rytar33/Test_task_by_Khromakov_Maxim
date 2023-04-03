using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Round : IFigure
    {
        private double Radius { get; set; } // ������ �����
        public Round(double radius) => this.Radius = radius;

        public void PrintFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID ������: {id}\n"
                + "������: ����\n"
                + $"������ �����: {Radius}\n"
                + $"��������: {Math.Round(GetPerimeter(), 2)}\n"
                + $"�������: {Math.Round(GetArea(), 2)}\n"
                + "===============================");
        }
        public double GetArea() => Math.PI * Math.Pow(Radius, 2); // ��������� ������� �����
        public double GetPerimeter() => 2 * Math.PI * Radius; // ��������� ��������� �����
    }
}