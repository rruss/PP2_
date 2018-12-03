using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Far_Manager
{

    class Program
    {
        static int CONSOLE_SIZE = 20;
        static void CurrentState(DirectoryInfo directory, int cursor, int root)
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            FileSystemInfo[] fss = directory.GetFileSystemInfos();
            int index = 0;
            
            foreach (FileSystemInfo f in fss)
            {
                if (index == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (f.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                if (index >= root && index <= root + CONSOLE_SIZE)
                {
                    FileInfo a = f as FileInfo;                    
                    Console.Write(f.Name);
                    string x = f.Name;
                    for(int i = 0; i < 58 - (f.Name.Length); ++i)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" | " + f.CreationTime);
                    index++;
                }
            }
        }
        static void Main(string[] args) {

        
            DirectoryInfo directory = new DirectoryInfo(@"D:\");
            int root = 0;
            int cursor = 0;
            CurrentState(directory, cursor, root);
            int n = directory.GetFileSystemInfos().Length;
            
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                    {
                        cursor = n - 1;
                        root = cursor - CONSOLE_SIZE;
                    }
                    if (cursor < root)
                    {
                        root--;
                    }
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == n)
                    {
                        cursor = 0;
                        root = 0;
                    }
                    if (cursor > root + CONSOLE_SIZE)
                    {
                        root++;
                    }
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    if (directory.GetFileSystemInfos()[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        directory = (DirectoryInfo)directory.GetFileSystemInfos()[cursor];
                        cursor = 0;
                        n = directory.GetFileSystemInfos().Length;
                        root = 0;
                    }
                    else
                    {

                            StreamReader sr = new StreamReader(directory.GetFileSystemInfos()[cursor].FullName);
                        try
                        {
                            string s = sr.ReadToEnd();

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.WriteLine(s);
                            Console.ReadKey();
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("Cannon open this file!");
                        }

                        finally
                        {
                                sr.Close();
                        }
                    }

                }
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    if (directory.Parent != null)
                    {
                        directory = directory.Parent;
                        cursor = 0;
                        n = directory.GetFileSystemInfos().Length;
                        root = 0;
                    }
                    else
                        break;
                }
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (directory.Parent != null)
                    {
                        directory = directory.Parent;
                        cursor = 0;
                        n = directory.GetFileSystemInfos().Length;
                        root = 0;
                    }
                    else
                        break;
                }
                CurrentState(directory, cursor, root);
            }
        }
    }
}
