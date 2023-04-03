using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Trinagle : IFigure
    {
        private double LeftSide { get; set; } // ����� ������� ������������
        private double RightSide { get; set; } // ������ ������� ������������
        private double BaseSide { get; set; } // ��������� ������������
        public Trinagle(double leftSide, double rightSide, double baseSide)
        {
            this.LeftSide = leftSide;
            this.RightSide = rightSide;
            this.BaseSide = baseSide;
        }
        public void PrintFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID ������: {id}\n"
                + "������: �����������\n"
                + "\t������� ������ ������\n"
                + $"����� �������: {LeftSide}\n"
                + $"������ �������: {RightSide}\n"
                + $"������ �������: {BaseSide}\n"
                + $"��� ������������: {GetTypeTrinagle()}\n"
                + $"��������: {Math.Round(GetPerimeter(), 2)}\n"
                + $"�������: {Math.Round(GetArea(), 2)}\n"
                + "===============================");
        }
        // ��������� ������� ������������
        public double GetArea()
        {
            double halfPer = GetPerimeter() * 0.5;
            return Math.Sqrt(halfPer * (halfPer - LeftSide) * (halfPer - RightSide) * (halfPer - BaseSide));
        }
        public double GetPerimeter() 
            => LeftSide + RightSide + BaseSide; // ��������� ��������� ������������
        public string GetTypeTrinagle()
            => ((LeftSide == RightSide) && (RightSide == BaseSide) && (LeftSide == BaseSide))
                ? "��������������" // ���� ��� ������� ������������ ����� - ������� "��������������"
                : ((LeftSide == RightSide) && (LeftSide != BaseSide) && (RightSide != BaseSide))
                ? "��������������" // ���� � ������������ ����� ������ ����� � ������ ����� - �������� "��������������"
                : "��������������"; // ����� - "��������������"
    }
}