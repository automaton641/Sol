using System;
using Senses;

namespace Tile
{
    class Program
    {
        static void Main(string[] args)
        {
            Application application = new Application();
            Window window = new Window("Tile", 1280, 720);
            application.Window = window;
            application.Run();
        }
    }
}
