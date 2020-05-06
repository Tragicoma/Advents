using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2015
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //Task5();
            //Task5pt2();
            Console.WriteLine(HasDouble("aaxaa"));
        }

        static void Task5pt2()
        {
            string filePath = @"D:\Jauna mape\C#_Maaciibas\Advente\Advents\Advent2015\input_strings.txt";
            List<string> vaardi = File.ReadAllLines(filePath).ToList();

            Console.WriteLine("total names on the list: " + vaardi.Count);
            foreach (string vards in vaardi.ToList())
            {

                if (HasDouble(vards))
                {
                    vaardi.Remove(vards);
                }
                
                   
            }
            Console.WriteLine("names on the list after sorting: " + vaardi.Count);


        }

        static bool HasDouble(string word)
        {
            return Regex.IsMatch(word, @".*([a-z].*/1).*");
        }
        static bool  HasNoun(string word) //noskaidro vai vaardaa ir 3 patskani
        {
            return Regex.IsMatch(word, @".*[aeiou]{1,}.*[aeiou]{1,}.*[aeiou]{1,}.*");
        }
        
        static bool HasTriple(string s) //funkcija 5.uzd, lai noskaidrotu vai ir 3x viens un tas pats burts
        {
            for (int i = 1; i < s.Length; i++)
                if (s[i] == s[i - 1])
                {
                    return true;
                }
            return false;

        }
        static void Task5()
        {
            string filePath = @"D:\Jauna mape\C#_Maaciibas\Advente\Advents\Advent2015\input_strings.txt";
            List<string> vaardi = File.ReadAllLines(filePath).ToList();

            Console.WriteLine("total names on the list: " + vaardi.Count);
            
            foreach (string vards in vaardi.ToList())
            {
                
                if(vards.Contains("ab") || vards.Contains("cd") || vards.Contains("xy") || vards.Contains("pq"))
                {
                    vaardi.Remove(vards);
                }
                else if(!HasTriple(vards))
                {
                    vaardi.Remove(vards);
                }
                else if (!HasNoun(vards))
                {
                    vaardi.Remove(vards);
                }
            }
            Console.WriteLine("names on the list after sorting: " + vaardi.Count);

        }
        static void Task3()
        {
            string filePath = @"D:\Jauna mape\C#_Maaciibas\Advente\Advents\Advent2015\input_bultinas.txt";
            string bultinas = File.ReadAllText(filePath);
            int x = 0, y = 0;
            List<string> coordinates = new List<string>();


            foreach(char ch in bultinas)
            {
                if (ch == '>')
                    x++;
                else if (ch == '<')
                    x--;
                else if (ch == '^')
                    y++;
                else if (ch == 'v')
                    y--;
                //pieliek katru poziiciju, kur bija ZSV
                coordinates.Add(x + ", " + y);
               
            }
            //atrod unikaalaas poziicijas, pataisa par listu, jo savaadaak nezinu kaa :D
            IEnumerable<string> uniqueHauses = coordinates.Distinct();
            List<string> unique = new List<string>();
            unique = uniqueHauses.ToList();

            Console.WriteLine("Number of houses Santa visited: " + coordinates.Count);
            Console.WriteLine("Number of UNIQUE houses Santa visited: " + unique.Count);
            Console.WriteLine("___________");
            Console.WriteLine("x: " + x);
            Console.WriteLine("y: " + y);

            int a = 0, b=0, c=0, d=0, i=0;
            List<string> santasRoute = new List<string>();
            foreach (char ch in bultinas)
            {
                i++;
                //ja bultinjas poziicija ir paara sk., tad pieskaita pirmajam veciitim, ja nepaara - robo-veciitim
                //visas koordinaatas liek vienaa listaa, kur veelaak atlasa unikaalaas
                if (i % 2 == 0)
                {
                    if (ch == '>')
                        a++;
                    else if (ch == '<')
                        a--;
                    else if (ch == '^')
                        b++;
                    else if (ch == 'v')
                        b--;
                    santasRoute.Add(a + ", " + b);
                }

                else
                {
                    if (ch == '>')
                        c++;
                    else if (ch == '<')
                        c--;
                    else if (ch == '^')
                        d++;
                    else if (ch == 'v')
                        d--;
                    santasRoute.Add(c + ", " + d);
                }
            }
            uniqueHauses = santasRoute.Distinct();
            unique = uniqueHauses.ToList();
            Console.WriteLine("Number of UNIQUE houses Santas visited: " + unique.Count);

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
