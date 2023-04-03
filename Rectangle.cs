using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Rectangle : IFigure
    {
        private double Horizontally { get; set; } // �������������� �������
        private double Vertically { get; set; } // ������������ �������
        public Rectangle(double horizontally, double vertically)
        {
            this.Horizontally = horizontally;
            this.Vertically = vertically;
        }
        public void PrintFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID ������: {id}\n"
                + "������: �������������\n"
                + "\t������� ������\n"
                + $"�� �����������: {Horizontally}\n"
                + $"�� ���������: {Vertically}\n"
                + $"��������: {Math.Round(GetPerimeter(), 2)}\n"
                + $"�������: {Math.Round(GetArea(), 2)}\n"
                + "===============================");
        }
        public double GetArea() => Horizontally * Vertically; // ��������� ������� ��������������
        public double GetPerimeter() => (2 * Horizontally) + (2 * Vertically); // ��������� ��������� ��������������

    }
}