using System;
using System.Collections;
using System.IO;
using System.Threading;

namespace shuffle
{
    class Program
    {
        ArrayList a = new ArrayList();
        string name,choice;
        int arrlisstcount, showhere, optionshow, shufflestyle, keypresshere, presscount, score, instructplace;
        static int ft=0;
        ConsoleKey press;
        Boolean shufflethis;

        private void readscore()
        {
            using (StreamReader read=new StreamReader("C:/Users/Pranker/Documents/Visual Studio 2015/Projects/shuffle/shuffle/scorefile.txt"))
            {
                string l;
                if ((l=read.ReadLine())!=null)
                {
                    name = l;
                }
                if ((l = read.ReadLine()) != null)
                {
                    score = Convert.ToInt32(l);
                }
            }
        }

        Program()
        {
            shufflethis = true;
            presscount = 0;
            readscore();
            startdetails();
            Console.Write("Want To Play ?? 1.Yes    2.No : ");
            if (ft != 1)
            {
                choice = Console.ReadLine();
                Console.WriteLine("\n\n");
                showhere = Console.CursorTop;
                optioncheck();
            }
            else
            {
                Console.WriteLine("\n\n");
                showhere = Console.CursorTop;
                startgame();
            }
        }

        private void startdetails()
        {
            Console.WriteLine("Player With The Highest Score Is : " + name + "\n\n");
            Console.WriteLine("Key Strokes Used By " + name + " is " + score + "\n\n");
            optionshow = Console.CursorTop;
        }

        private void optioncheck()
        {
            if (choice.Equals("1"))
            {
                startgame();
            }
            else if (choice.Equals("2"))
            {
                closegame();
            }
            else
            {
                Console.SetCursorPosition(0, optionshow);
                Console.Write("Wrong Input OOOPS!!!    Want To Try Again And Play The Game ?? 1.Yes    2.No :  \b");
                choice = Console.ReadLine();
                optioncheck();
            }
        }

        private void startgame()
        {
            addtolist();
            displaygame();
        }

        private void displaygame()
        {
            arrdisp();
            Console.Write("\n");
            instructplace = Console.CursorTop;
            instructions();
            keypresshere= Console.CursorTop;
            keypressed();
        }

        private void instructions()
        {
            Console.SetCursorPosition(0, instructplace);
            Console.Write("Press -- (L or Left Arrow for Left)\nPress -- (R or Right Arrow for Right)\nPress -- (U or Up Arrow for Up)\nPress -- (D or Down Arrow for Down)\nPress -- (E To Evaluate)");
        }

        private void arrdisp()
        {
            int counter = 0;
            Console.SetCursorPosition(0, showhere);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(a[counter] + "    ");
                    counter++;
                }
                Console.WriteLine("\n");
            }
        }

        private void zeroplace()
        {
            arrlisstcount = a.IndexOf(0);
        }

        private void keypressed()
        {
            press = Console.ReadKey(true).Key;
            if (press.Equals(ConsoleKey.L) || press.Equals(ConsoleKey.LeftArrow))
            {
                zeroplace();
                if (arrlisstcount.Equals(0) || arrlisstcount.Equals(3) || arrlisstcount.Equals(6))
                { }
                else
                {
                    shufflestyle = 1;
                    disparrayonscreen();
                }
                setkeyposition();
            }
            else if (press.Equals(ConsoleKey.R) || press.Equals(ConsoleKey.RightArrow))
            {
                zeroplace();
                if (arrlisstcount.Equals(2) || arrlisstcount.Equals(5) || arrlisstcount.Equals(8))
                { }
                else
                {
                    shufflestyle = 2;
                    disparrayonscreen();
                }
                setkeyposition();
            }
            else if (press.Equals(ConsoleKey.U) || press.Equals(ConsoleKey.UpArrow))
            {
                zeroplace();
                if (arrlisstcount.Equals(0) || arrlisstcount.Equals(1) || arrlisstcount.Equals(2))
                { }
                else
                {
                    shufflestyle = 3;
                    disparrayonscreen();
                }
                setkeyposition();
            }
            else if (press.Equals(ConsoleKey.D) || press.Equals(ConsoleKey.DownArrow))
            {
                zeroplace();
                if (arrlisstcount.Equals(6) || arrlisstcount.Equals(7) || arrlisstcount.Equals(8))
                { }
                else
                {
                    shufflestyle = 4;
                    disparrayonscreen();
                }
                setkeyposition();
            }
            else if (press.Equals(ConsoleKey.E))
            {
                if (evaluate())
                {
                    correct();
                }
                else
                {
                    notcorrect();
                }
            }
            else
            {
                if (press.Equals(ConsoleKey.M))
                {
                    string x;
                    x = Console.ReadLine();
                    if (x.Equals("Make Me Win"))
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine("\b");
                        }
                        shufflethis = false;
                        Console.Clear();
                        startdetails();
                        Console.Write("Want To Play ?? 1.Yes    2.No : ");
                        startgame();
                    }
                    else
                    {
                        instructions();
                        Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
                        setkeyposition();
                    }
                }
                else
                {
                    setkeyposition();
                }
            }
        }

        private void correct()
        {
            Console.WriteLine("\n\nThis Is Correctly Arranged :) ... You Completed it in " + presscount + " Key Strokes And Where "+pecentage()+"% Correct");
            if (presscount<score)
            {
                Console.Write("\n\nYou Are The New High Scorer, Congrats :D  Please Enter Your Name : ");
                name = Console.ReadLine();
                savescorer();
                Console.WriteLine("Thank You :D Your Score Has been saved.");
                midstart();
            }
            else
            {
                Console.WriteLine("\n\nStill "+name+" Used Less number Of Key Strokes.");
                midstart();
            }
        }

        private void savescorer()
        {
            using (StreamWriter write=new StreamWriter("C:/Users/Pranker/Documents/Visual Studio 2015/Projects/shuffle/shuffle/scorefile.txt"))
            {
                write.WriteLine(name);
                write.WriteLine(presscount);
            }
        }

        private void midstart()
        {
            Console.Write("\n\nWant To Play Again ? 1.Yes 2.No : ");
            choice = Console.ReadLine();
            if (choice.Equals("1"))
            {
                ft = 1;
                Console.Clear();
                new Program();
            }
            else if (choice.Equals("2"))
            {
                closegame();
            }
            else
            {
                Console.Clear();
                startdetails();
                optioncheck();
            }
        }

        private void notcorrect()
        {
            Console.WriteLine("\n\nAwwwww Sorry :'( It Is Not correctly Arranged. You Used " + presscount + " Key Strokes And Where "+pecentage()+"% Correct");
            midstart();
        }

        private int pecentage()
        {
            int counter = 0,percent=0;
            for (int i = 1; i < 9; i++)
            {
                if (Convert.ToInt32(a[counter]).Equals(i))
                {
                    percent++;
                }
                counter++;
            }
            return (int)(((float)percent / (float)counter) * 100);
        }

        private void disparrayonscreen()
        {
            swap(arrlisstcount);
            arrdisp();
            presscount++;
        }

        private Boolean evaluate()
        {
            Boolean b = false;
            int x=0;
            for (int i = 0; i < 8; i++)
            {
                if (Convert.ToInt32(a[i]).Equals(i+1))
                {
                    x++;
                }
            }
            if (x.Equals(8))
            {
                b = true;
            }
            return b;
        }

        private void setkeyposition()
        {
            Console.SetCursorPosition(24, keypresshere);
            keypressed();
        }

        private void swap(int num)
        {
            int x=num;
            if (shufflestyle.Equals(1))
            {
                x = num - 1;
            }
            if (shufflestyle.Equals(2))
            {
                x = num + 1;
            }
            if (shufflestyle.Equals(3))
            {
                x = num - 3;
            }
            if (shufflestyle.Equals(4))
            {
                x = num + 3;
            }
            int t = Convert.ToInt32(a[num]);
            a[num] = a[x];
            a[x] = t;
        }

        private void closegame()
        {
            Console.Write("\n\nThe Game Will Close In : ");
            for (int i = 5; i > 0; i--)
            {
                Console.SetCursorPosition(25, Console.CursorTop);
                Console.Write(i);
                Thread.Sleep(1000);
            }
        }

        private void addtolist()
        {
            a.Clear();
            for (int i = 0; i < 9; i++)
            {
                a.Add(i);
            }
            if (shufflethis)
            {
                a = ShuffleArrayList(a);
            }
            else
            {
                a.RemoveAt(0);
                a.Add(0);
            }
        }

        private ArrayList ShuffleArrayList(ArrayList source)
        {
            ArrayList sortedList = new ArrayList();
            Random generator = new Random();

            while (source.Count > 0)
            {
                int position = generator.Next(source.Count);
                sortedList.Add(source[position]);
                source.RemoveAt(position);
            }

            return sortedList;
        }

        static void Main(string[] args)
        {
            Program done = new Program();
        }
    }
}
