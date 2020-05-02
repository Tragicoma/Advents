using System;
using System.IO;

namespace Advent2015
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
        }

        static void Task1()
        {
            string fp = @"D:\Jauna mape\C#_Maaciibas\Advente\input_iekavas.txt";
            string iekavas = File.ReadAllText(fp);
            int sum = 0;
            int position = 0;
            
            foreach(char ch in iekavas)
            {
                if(ch == '(')
                {
                    sum++;
                }
                else if(ch == ')')
                {
                    sum--;
                }
                position++;
                if(sum==-1)
                {
                    Console.WriteLine("Enters the basement in position: " + position);
                }
            }

            Console.WriteLine(" amount of floors: " + sum);
        }

    }
}
