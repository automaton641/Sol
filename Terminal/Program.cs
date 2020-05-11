using System;
using Senses;
namespace Terminal
{
    class Program
    {
        void OnMouse(object sender, MouseEventArgs eventArgs)
        {
            Console.WriteLine("OnMouse");
        }
        void Run()
        {
            Console.WriteLine("Hello Terminal!");
            Window window = new Window("Terminal", 1280, 720);
            Container container = new Container(Orientation.Vertical, window.Theme);
            TextWidget textWidget = new TextWidget("Hello Terminal", true, window.Theme);
            container.Add(textWidget);
            TextWidget textWidget1 = new TextWidget("Hello again", window.Theme);
            TextWidget textWidget2 = new TextWidget("and again", window.Theme);
            TextWidget textWidget3 = new TextWidget("again1 again2 again3 again4 again5 again6 again7 again8 "
                , false, window.Theme);
            Scroller scroller = new Scroller(textWidget3, window.Theme);
            Container container1 = new Container(Orientation.Horizontal, window.Theme);
            container1.Add(textWidget1);
            container1.Add(textWidget2);
            container1.Add(scroller);
            container.Add(container1);
            window.Widget = container;
            window.Mouse += OnMouse;
            window.Show();
        }
        static void Main(string[] args)
        {
            Program program =  new Program();
            program.Run();
        }
    }
}
