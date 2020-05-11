using System;

namespace Senses
{
    public class Window
    {
        public event EventHandler<MouseEventArgs> Mouse;
        internal bool shouldPaint = true;
        internal MonoGameInterface monoGameInterface;
        internal Widget widget;
        internal Theme theme;
        internal PixelDrawer pixelDrawer;
        internal SMouseState mouseState;
        public Window(string title, int width, int height)
        {
            theme = new Theme();
            mouseState = new SMouseState();
            monoGameInterface = new MonoGameInterface();
            monoGameInterface.window = this;
            monoGameInterface.size = new Size(width, height);
        }
        internal void MouseStateUpdate(Button button, SButtonState state)
        {
            mouseState.dictionary[button] = state;
            OnMouse(new MouseEventArgs(button, state));
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
        protected virtual void OnMouse(MouseEventArgs eventArgs)
        {
            EventHandler<MouseEventArgs> handler = Mouse;
            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }
        public void Repaint()
        {
            shouldPaint = true;
        }
    }
}