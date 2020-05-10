using System;
using Senses;
namespace Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Terminal!");
            Window window = new Window("Terminal", 1280, 720);
            Container container = new Container(Orientation.Vertical, window.Theme);
            TextWidget textWidget = new TextWidget("Hello Terminal", window.Theme);
            container.Add(textWidget);
            TextWidget textWidget1 = new TextWidget("Hello again", window.Theme);
            TextWidget textWidget2 = new TextWidget("and again", window.Theme);
            Container container1 = new Container(Orientation.Horizontal, window.Theme);
            container1.Add(textWidget1);
            container1.Add(textWidget2);
            container.Add(container1);
            window.Widget = container;
            window.Show();
        }
    }
}
