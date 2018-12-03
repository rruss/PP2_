using Qwerty;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwerty
{
    class Window
    {
        public DirectoryInfo Dinfo;
        public string path;
        public int index;

        public Window(DirectoryInfo dinfo, string path, int index)
        {
            Dinfo = dinfo;
            this.path = path;
            this.index = index;
        }

        public void Process(int a)
        {
            this.index += a;
            if (this.index < 0)
            {
                this.index = Dinfo.GetFileSystemInfos().Length - 1;
            }

            if (this.index >= Dinfo.GetFileSystemInfos().Length)
            {
                index = 0;
            }
        }
    }
    class Far
    {
        public Far(string path)
        {
            this.activewindow = new Window(path, 0);
        }
        Stack<Window> activewindow = new Stack<Window>;
        DirectoryInfo Dinfo = new DirectoryInfo(activewindow.path);
        DirectoryInfo[] x = Dinfo.GetDirectories();

        public DirectoryInfo Dinfo { get => Dinfo; set => Dinfo = value; }

        
}
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 40);
            Far far = new Far(@"C:\");
        }
    }
}
