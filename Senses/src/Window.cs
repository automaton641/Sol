
namespace Senses
{
    public class Window
    {
        internal bool shouldPaint = true;
        internal MonoGameInterface monoGameInterface;
        internal Widget widget;
        internal Theme theme;
        internal PixelDrawer pixelDrawer;
        public Window(string title, int width, int height)
        {
            theme = new Theme();
            monoGameInterface = new MonoGameInterface();
            monoGameInterface.window = this;
            monoGameInterface.size = new Size(width, height);
        }
        internal void Draw()
        {
            widget?.Draw(pixelDrawer);
        }
        public int Width
        {
            get {return size.width;}
        }
        public int Height
        {
            get {return size.height;}
        }
        internal Size size
        {
            get {return monoGameInterface.size;}
        }
        public Theme Theme
        {
            get {return theme;}
        }
        public void Show()
        {
            monoGameInterface.Run();
        }
        public Widget Widget
        {
            set
            {
                widget = value;
                widget.window = this;
                widget.Arrange(size, new Position());
            }
        }
        public void Repaint()
        {
            shouldPaint = true;
        }
    }
}