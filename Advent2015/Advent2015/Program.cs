using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Advent2015
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            Task2();
        }

        
        static void Task2()
        {
            string fp = @"D:\Jauna mape\C#_Maaciibas\Advente\Advents\Advent2015\box_dimensions.txt";
            List<string> dimensions = new List<string>();
            List<GiftBox> boxes = new List<GiftBox>();
            dimensions = File.ReadAllLines(fp).ToList();

            int sumWrapper = 0;
            int sumRibbon = 0;

            foreach (string lines in dimensions)
            {
                string[] items = lines.Split('x');
                GiftBox box = new GiftBox(Convert.ToInt32(items[0]), Convert.ToInt32(items[1]), Convert.ToInt32(items[2]));
                boxes.Add(box);
            }
            
            foreach(GiftBox box in boxes)
            {
                int a = box.length,b = box.height, c = box.width;

                int[] parameters = { a, b, c };
                int longest = parameters.Max();
                List<int> usables = new List<int>();
                usables = parameters.ToList();
                usables.Remove(longest);
                int ribbon = 2 * usables[0] + 2 *usables[1];
                Console.WriteLine("Ribbon: " + ribbon);
                int[] sides = {a*b,b*c,c*a};
                int smallest = sides.Min();
                int boxTotal = (2*a*b + 2*b*c + 2*a*c) + smallest ;
               
                sumWrapper = sumWrapper + boxTotal;
                sumRibbon = sumRibbon + a*b*c + ribbon;
            }
            Console.WriteLine("total amount for wrapping paper: " + sumWrapper);
            Console.WriteLine("total amount for ribbon: " + sumRibbon);
        }
        
        static void Task1()
        {
            string fp = @"D:\Jauna mape\C#_Maaciibas\Advente\Advents\Advent2015\input_iekavas.txt";
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
