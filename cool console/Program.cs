using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace cool_console
{
    class Program
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);

        static void Main(string[] args)
        {
            var handle = GetStdHandle(-11);
            int mode;
            GetConsoleMode(handle, out mode);
            SetConsoleMode(handle, mode | 0x4);
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            Thread TitleThreading = new Thread(TitleThread), WritingThreading = new Thread(WritingThread);
            TitleThreading.Start();
            WritingThreading.Start();
        }

        static void TitleThread()
        {
            List<Char> LoadingCharList = new List<Char>(){'|', Convert.ToChar(@"\") , '—', '/'};
            String Text = "Writing";
            String TitleText = String.Empty;
            Boolean mode = true;
            Int16 LetterNumber = 0, LoadingCharNumber = 0;

            while (true)
            {
                if(mode){LetterNumber++;if (Text.Length<=LetterNumber){mode=false;} }else{LetterNumber--;if (LetterNumber<=1){mode=true;}}
                LoadingCharNumber++;
                if (LoadingCharNumber == LoadingCharList.Count) { LoadingCharNumber = 0; }
                TitleText = Text.Substring(0, LetterNumber);
                TitleText = TitleText.PadRight(Text.Length + 5, ' ');
                TitleText += LoadingCharList[LoadingCharNumber];
                Console.Title = TitleText;
                Thread.Sleep(100);
            }
        }

        static void WritingThread()
        {
            Int16 Gap = 0, timer = 0;
            Boolean mode = true;

            while (true)
            {
#if DEBUG
                break;
#endif
                if (mode) {
                    Gap++;
                    if (Console.WindowWidth <= Gap) 
                    {
                        mode = false;
                        Console.ForegroundColor = (ConsoleColor)NumberGen(false);
                        timer++;
                    }
                } 
                else 
                { 
                    Gap--; 
                    if (Gap <= 0) 
                    {
                        mode = true;
                        Console.ForegroundColor = (ConsoleColor)NumberGen(false);
                        timer++;
                    }
                }

                if (timer >= 10)
                {
                    if (Gap >= (Console.WindowWidth+3)/2)
                    {
                        break;
                    }
                }

                Console.WriteLine(@"\|/".PadLeft(Gap, ' '));
                Thread.Sleep(10);
            }
            Gap = 0;
            timer = 0;
            String SecondPhase = String.Empty;

            while (true)
            {
#if DEBUG
                break;
#endif
                if (mode)
                {
                    Gap++;
                    if (Console.WindowWidth <= Gap+10)
                    {
                        mode = false;
                        Console.ForegroundColor = (ConsoleColor)NumberGen(false);
                        timer++;
                    }
                }
                else
                {
                    Gap--;
                    if (Gap <= 0)
                    {
                        mode = true;
                        Console.ForegroundColor = (ConsoleColor)NumberGen(false);
                        timer++;
                    }
                }

                if (timer >= 10)
                {
                    SecondPhase = @"O-O-OO-O-O".Insert(5, new String('=', Gap));
                }
                else
                {
                    SecondPhase = @"O-O-OO-O-O".Insert(5, new String(' ', Gap));
                }

                if (timer >= 21)
                {
                    break;
                }

                Console.SetCursorPosition((Console.WindowWidth - SecondPhase.Length)/2, Console.CursorTop);
                Console.WriteLine(SecondPhase);
                Thread.Sleep(5);
            }

            timer = 0;
            SecondPhase = String.Empty;
            Gap = 0;

            while (true)
            {
#if DEBUG
                break;
#endif
                SecondPhase = new String('=', Console.WindowWidth-1);
                StringBuilder strbld = new StringBuilder(SecondPhase);

                if (SecondPhase.Length % 2 == 0)
                {
                    for (int AddCounter=0; AddCounter <= Gap; AddCounter++)
                    {
                        strbld[(strbld.Length / 2) - AddCounter] = ' ';
                        strbld[(strbld.Length / 2) + AddCounter] = ' ';
                    }
                }
                else
                {
                    for (int AddCounter = 0; AddCounter <= Gap; AddCounter++)
                    {
                        strbld[(strbld.Length / 2)+1 - AddCounter] = ' ';
                        strbld[(strbld.Length / 2) + AddCounter] = ' ';
                    }
                }

                if (mode)
                {
                    Gap++;
                    if (strbld.Length / 2 <= Gap+1)
                    {
                        mode = false;
                        Console.ForegroundColor = (ConsoleColor)NumberGen(false);
                        timer++;
                    }
                }
                else
                {
                    Gap--;
                    if (Gap <= 0)
                    {
                        mode = true;
                        Console.ForegroundColor = (ConsoleColor)NumberGen(false);
                        timer++;
                    }
                }

                if(timer >= 11)
                {
                    break;
                }

                Console.WriteLine(strbld);
                Thread.Sleep(10);
            }

            Gap = Convert.ToInt16(Console.WindowWidth);
            timer = 0;
            mode = true;
            SecondPhase = String.Empty;

            while (true)
            {
#if DEBUG
                break;
#endif
                if (mode)
                {
                    Gap++;
                    if (Console.WindowWidth-2 <= Gap)
                    {
                        mode = false;
                        Console.ForegroundColor = (ConsoleColor)NumberGen(false);
                        timer++;
                    }
                }
                else
                {
                    Gap--;
                    if (Gap <= 0)
                    {
                        mode = true;
                        Console.ForegroundColor = (ConsoleColor)NumberGen(false);
                        timer++;
                    }
                }

                if (timer >= 10)
                {
                    break;
                }

                SecondPhase = @"".Insert(0, new String('=', Gap));

                Console.SetCursorPosition((Console.WindowWidth - SecondPhase.Length) / 2, Console.CursorTop);
                Console.WriteLine(SecondPhase);
                Thread.Sleep(5);
            }

            int R=255, G=0, B=0, SolidColours = 15;
            String Character = String.Empty;
            Gap = 0; timer = 0;
            Boolean AddSubColor = true;

            while (true)
            {
#if DEBUG
                break;
#endif
                if (R > 0 && B == 0){
                    R--;
                    G++;
                }
                if (G > 0 && R == 0)
                {
                    G--;
                    B++;
                }
                if (B > 0 && G == 0)
                {
                    R++;
                    B--;
                }
                //R = NumberGen(true);
                //Thread.Sleep(8);
                //G = NumberGen(true)-R;
                //Thread.Sleep(8);
                //B = 255-R-G;

                if (timer <= 5)
                {
                    Character = "\x1b[38;2;" + SolidColours + ";" + SolidColours + ";" + SolidColours + "m";
                }
                else if (timer <=14)
                {

                    Character = "\x1b[38;2;" + R + ";" + G + ";" + B + "m";
                }
                else
                {
                    break;
                }
                
                if (mode)
                {
                    Gap++;
                    if (Console.WindowWidth - 2 <= Gap+Character.Length)
                    {
                        mode = false;
                        timer++;
                    }
                }
                else
                {
                    Gap--;
                    if (Gap <= 0)
                    {
                        mode = true;
                        timer++;
                    }
                }

                if (AddSubColor)
                {
                    SolidColours++;
                    if (255 <= SolidColours)
                    {
                        AddSubColor = false;
                    }
                }
                else
                {
                    SolidColours--;
                    if (0 >= SolidColours)
                    {
                        AddSubColor = true;
                    }
                }

                
                //Console.Write("\x1b[38;2;" + R + ";" + G + ";" + B + "m■█■");
                
                Character += new String(Convert.ToChar('█'), Gap);

                Console.SetCursorPosition((Console.WindowWidth - Gap) / 2, Console.CursorTop);
                Console.WriteLine(Character);

                Thread.Sleep(5);
            }

            Character = String.Empty;
            Gap = 0; timer = 0;

            while (true)
            {
#if DEBUG
                break;
#endif
                if (R > 0 && B == 0)
                {
                    R--;
                    G++;
                }
                if (G > 0 && R == 0)
                {
                    G--;
                    B++;
                }
                if (B > 0 && G == 0)
                {
                    R++;
                    B--;
                }

                Character = "\x1b[38;2;" + R + ";" + G + ";" + B + "m";

                if (timer <= 2400)
                {
                    Character += new String(Convert.ToChar('█'), Console.WindowWidth);
                }
                else if (timer <= 4800)
                {
                    Character += String.Concat(Enumerable.Repeat("█■", Console.WindowWidth/2-2));
                    Character += "|";
                }
                else
                {
                    break;
                }

                

                //Console.SetCursorPosition(Console.WindowWidth / 2, Console.CursorTop);
                Console.WriteLine(Character);
                timer++;
                Thread.Sleep(5);
            }

            Character = String.Empty;
            Gap = 0; timer = 0;

            while (true)
            {
                if (R > 0 && B == 0)
                {
                    R--;
                    G++;
                }
                if (G > 0 && R == 0)
                {
                    G--;
                    B++;
                }
                if (B > 0 && G == 0)
                {
                    R++;
                    B--;
                }

                Character = "\x1b[38;2;" + R + ";" + G + ";" + B + "m";
                Character += new String(Convert.ToChar('█'), 50);

                if (mode)
                {
                    Gap++;
                    if (Console.WindowWidth <= Gap + Character.Length)
                    {
                        mode = false;
                        timer++;
                    }
                }
                else
                {
                    Gap--;
                    if (Gap <= 0)
                    {
                        mode = true;
                        timer++;
                    }
                }

                

                Console.SetCursorPosition((Console.WindowWidth - Gap) / 2, Console.CursorTop);
                Console.WriteLine(Character);
                Thread.Sleep(5);
            }
        }

        static int NumberGen(bool RGB)
        {
            int number;
            Random rnd = new Random();
            if (!RGB)
            {
                number = rnd.Next(0, 12);
                while (true)
                {
                    if (number == 0 || number == 7)
                    {
                        number = rnd.Next(0, 12);
                    }
                    else
                    {
                        return number;
                    }
                }
            }
            else
            {
                number = rnd.Next(0, 256);
                return number;
            }
        }
    }
}
